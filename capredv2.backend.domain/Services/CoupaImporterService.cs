using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using capredv2.backend.domain.DomainEntities.Enums;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.ExtensionMethods;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;
using Newtonsoft.Json;

namespace capredv2.backend.domain.Services
{
	public class CoupaImporterService : ICoupaImporterService
	{
		private readonly ICoupaImporterRepository _coupaImporterRepository;
		private readonly IProjectInvoiceRepository _projectInvoiceRepository;
		private readonly IProjectPurchaseOrderRepository _projectPurchaseOrderRepository;
		private readonly IProjectRequisitionRepository _projectRequisitionRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CoupaImporterService(ICoupaImporterRepository coupaImporterRepository,
									IProjectInvoiceRepository projectInvoiceRepository,
									IProjectPurchaseOrderRepository projectPurchaseOrderRepository,
									IProjectRequisitionRepository projectRequisitionRepository,
									IUnitOfWork unitOfWork)
		{
			_coupaImporterRepository = coupaImporterRepository ?? throw new ArgumentNullException(nameof(coupaImporterRepository));
			_projectInvoiceRepository = projectInvoiceRepository ?? throw new ArgumentNullException(nameof(projectInvoiceRepository));
			_projectPurchaseOrderRepository = projectPurchaseOrderRepository ?? throw new ArgumentNullException(nameof(projectPurchaseOrderRepository));
			_projectRequisitionRepository = projectRequisitionRepository ?? throw new ArgumentNullException(nameof(projectRequisitionRepository));
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public CoupaImporterJobDefinitionDTO CreateInvoiceImportJobDefinition(Guid projectId, MemoryStream memoryStream, string fileName)
		{
			var invoiceList = CsvExtensionMethods.GetCsvValues<InvoiceDTO>(memoryStream);

			if (invoiceList == null) return null;

			var coupaImporter = SetCoupaImporterJobDefinitionDTO(invoiceList, projectId, fileName, FileType.Invoice);
			var result = _coupaImporterRepository.Add(CoupaImporterJobDefinition.MapFromDomainEntity(coupaImporter));
			return CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity(result);
		}

		public CoupaImporterJobDefinitionDTO CreatePurchaseOrderImportJobDefinition(Guid projectId, MemoryStream memoryStream, string fileName)
		{
			var purchaseOrderList = CsvExtensionMethods.GetCsvValues<PurchaseOrderDTO>(memoryStream);

			if (purchaseOrderList == null) return null;

			var coupaImporter = SetCoupaImporterJobDefinitionDTO(purchaseOrderList, projectId, fileName, FileType.PurchaseOrder);
			var result = _coupaImporterRepository.Add(CoupaImporterJobDefinition.MapFromDomainEntity(coupaImporter));
			return CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity(result);
		}

		public CoupaImporterJobDefinitionDTO CreateRequisitionImportJobDefinition(Guid projectId, MemoryStream memoryStream, string fileName)
		{
			var requisitionList = CsvExtensionMethods.GetCsvValues<RequisitionDTO>(memoryStream);

			if (requisitionList == null) return null;

			var coupaImporter = SetCoupaImporterJobDefinitionDTO(requisitionList, projectId, fileName, FileType.Requisition);
			var result = _coupaImporterRepository.Add(CoupaImporterJobDefinition.MapFromDomainEntity(coupaImporter));
			return CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity(result);
		}

		public CoupaImporterJobDefinitionDTO ProcessInvoiceImportJob(Guid jobDefinitionId)
		{
			var jobDefinition = _coupaImporterRepository.Get(jobDefinitionId);

			var allInvoices = new List<InvoiceDTO>();
			var invoiceHeaders = new List<InvoiceHeader>();

			if (jobDefinition == null) return null;

			_unitOfWork.AutoDetectChanges(false);

			// Here we use 1000 records batch so that we can reduce the number of loops.
			var noOfRotation = jobDefinition.CoupaImporterJobDefinitionDetails.Count() / 1000;
			noOfRotation += jobDefinition.CoupaImporterJobDefinitionDetails.Count() % 1000 > 0 ? 1 : 0;

			for (var i = 0; i < noOfRotation; i++)
			{
				var strCoupaImporterJobDefinitionDetails = "[ ";
				strCoupaImporterJobDefinitionDetails += string.Join(", ", jobDefinition.CoupaImporterJobDefinitionDetails
					.Skip(i * 1000).Take(1000).Select(x => x.RawContent));
				strCoupaImporterJobDefinitionDetails += " ]";

				// Convert the RawContent to Invoice Header
				invoiceHeaders.AddRange(JsonConvert.DeserializeObject<List<InvoiceHeader>>(strCoupaImporterJobDefinitionDetails));
				// Convert the RawContent to InvoiceDTO
				allInvoices.AddRange(JsonConvert.DeserializeObject<List<InvoiceDTO>>(strCoupaImporterJobDefinitionDetails));
			}

			// In every InvoiceHeader Entity ProjectId is added
			invoiceHeaders.ForEach(i => { i.ProjectId = jobDefinition.ProjectId; i.Id = Guid.NewGuid(); });

			// Grouping InvoiceHeaders in terms of Unique combination of Supplier & InvoiceNumber
			invoiceHeaders = invoiceHeaders.GroupBy(i => new { i.InvoiceNumber, i.Supplier }).Select(x => x.First()).ToList();

			foreach (var objInvoiceHeader in invoiceHeaders)
			{
				// Allocate all line items for a invoice header + InvoiceHeaderId added in every associated Line Items.
				objInvoiceHeader.InvoiceLineItems = allInvoices.Where(x => x.Supplier == objInvoiceHeader.Supplier && x.InvoiceNumber == objInvoiceHeader.InvoiceNumber)
					.Select(x => InvoiceLineItem.MapFromDomainEntity(InvoiceDTO.MapToInvoiceLineItemDTO(x))).ToList();
				objInvoiceHeader.InvoiceLineItems.ToList().ForEach(x => x.InvoiceHeaderId = objInvoiceHeader.Id);

				_projectInvoiceRepository.Add(objInvoiceHeader);
			}

			// At last update all job definition details records
			jobDefinition.CoupaImporterJobDefinitionDetails.ToList().ForEach(c => { c.IsProcessed = true; c.IsSuccessful = true; });
			_coupaImporterRepository.UpdateAllJobDefinitionDetail(jobDefinitionId, jobDefinition.CoupaImporterJobDefinitionDetails);

			jobDefinition.Status = (int)CoupaImporterStatus.Processed;
			_coupaImporterRepository.Update(jobDefinitionId, jobDefinition);

			_unitOfWork.SaveChanges();
			_unitOfWork.AutoDetectChanges(true);

			return CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity(jobDefinition);
		}

		public CoupaImporterJobDefinitionDTO ProcessPurchaseOrderImportJob(Guid jobDefinitionId)
		{
			var jobDefinition = _coupaImporterRepository.Get(jobDefinitionId);

			if (jobDefinition == null) return null;

			_unitOfWork.AutoDetectChanges(false);

			var pOHeaders = new List<POHeader>();
			var purchaseOrders = new List<PurchaseOrderDTO>();

			// Here we use 1000 records batch so that we can reduce the number of loops.
			var noOfRotation = jobDefinition.CoupaImporterJobDefinitionDetails.Count() / 1000;
			noOfRotation += jobDefinition.CoupaImporterJobDefinitionDetails.Count() % 1000 > 0 ? 1 : 0;

			for (var i = 0; i < noOfRotation; i++)
			{
				var strCoupaImporterJobDefinitionDetails = "[ ";
				strCoupaImporterJobDefinitionDetails += string.Join(", ", jobDefinition.CoupaImporterJobDefinitionDetails
					.Skip(i * 1000).Take(1000).Select(x => x.RawContent));
				strCoupaImporterJobDefinitionDetails += " ]";

				// Convert the RawContent to POHeader
				pOHeaders.AddRange(JsonConvert.DeserializeObject<List<POHeader>>(strCoupaImporterJobDefinitionDetails));
				// Convert the RawContent to PurchaseOrderDTO
				purchaseOrders.AddRange(JsonConvert.DeserializeObject<List<PurchaseOrderDTO>>(strCoupaImporterJobDefinitionDetails));
			}

			// In every InvoiceHeader Entity ProjectId is added
			pOHeaders.ForEach(i => { i.ProjectId = jobDefinition.ProjectId; i.Id = Guid.NewGuid(); });

			// Grouping InvoiceHeaders in terms of Unique combination of Supplier & InvoiceNumber
			pOHeaders = pOHeaders.GroupBy(i => new { i.PurchaseOrderNumber, i.Supplier }).Select(x => x.First()).ToList();

			foreach (var objPoHeader in pOHeaders)
			{
				// Allocate all line items for a invoice header + InvoiceHeaderId added in every associated Line Items.
				objPoHeader.POLineItems = purchaseOrders.Where(x => x.Supplier == objPoHeader.Supplier && x.PurchaseOrderNumber == objPoHeader.PurchaseOrderNumber)
					.Select(x => POLineItem.MapFromDomainEntity(PurchaseOrderDTO.MapToPOLineItemDTO(x))).ToList();
				objPoHeader.POLineItems.ToList().ForEach(x => { x.POHeaderId = objPoHeader.Id; x.Id = Guid.NewGuid(); });

				_projectPurchaseOrderRepository.Add(objPoHeader);
			}

			// At last update all job definition details records
			jobDefinition.CoupaImporterJobDefinitionDetails.ToList().ForEach(c => { c.IsProcessed = true; c.IsSuccessful = true; });
			_coupaImporterRepository.UpdateAllJobDefinitionDetail(jobDefinitionId, jobDefinition.CoupaImporterJobDefinitionDetails);

			jobDefinition.Status = (int)CoupaImporterStatus.Processed;
			_coupaImporterRepository.Update(jobDefinitionId, jobDefinition);

			_unitOfWork.SaveChanges();
			_unitOfWork.AutoDetectChanges(true);

			return CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity(jobDefinition);

		}
		// Import Requisition
		public CoupaImporterJobDefinitionDTO ProcessRequisitionImportJob(Guid jobDefinitionId)
		{
			var jobDefinition = _coupaImporterRepository.Get(jobDefinitionId);

			if (jobDefinition == null) return null;

			_unitOfWork.AutoDetectChanges(false);
			var requisitionHeaders = new List<RequisitionHeader>();
			var listOfRequisitionDTO = new List<RequisitionDTO>();

			// Here we use 1000 records batch so that we can reduce the number of loops.
			var noOfRotation = jobDefinition.CoupaImporterJobDefinitionDetails.Count() / 1000;
			noOfRotation += jobDefinition.CoupaImporterJobDefinitionDetails.Count() % 1000 > 0 ? 1 : 0;

			for (var i = 0; i < noOfRotation; i++)
			{
				var strCoupaImporterJobDefinitionDetails = "[ ";
				strCoupaImporterJobDefinitionDetails += string.Join(", ", jobDefinition.CoupaImporterJobDefinitionDetails
					.Skip(i * 1000).Take(1000).Select(x => x.RawContent));
				strCoupaImporterJobDefinitionDetails += " ]";

				// Convert the RawContent to RequisitionHeader
				requisitionHeaders.AddRange(JsonConvert.DeserializeObject<List<RequisitionHeader>>(strCoupaImporterJobDefinitionDetails));
				// Convert the RawContent to RequisitionDTO
				listOfRequisitionDTO.AddRange(JsonConvert.DeserializeObject<List<RequisitionDTO>>(strCoupaImporterJobDefinitionDetails));
			}

			// In every InvoiceHeader Entity ProjectId is added
			requisitionHeaders.ForEach(i => { i.ProjectId = jobDefinition.ProjectId; i.Id = Guid.NewGuid(); });

			// Grouping InvoiceHeaders in terms of Unique combination of Supplier & InvoiceNumber
			requisitionHeaders = requisitionHeaders.GroupBy(i => new { i.RequisitionNumber, i.Supplier }).Select(x => x.First()).ToList();

			foreach (var objRequisition in requisitionHeaders)
			{
				// Allocate all line items for a invoice header + InvoiceHeaderId added in every associated Line Items.
				objRequisition.RequisitionLineItems = listOfRequisitionDTO.Where(x => x.Supplier == objRequisition.Supplier && x.RequisitionNumber == objRequisition.RequisitionNumber.ToString())
					.Select(x => RequisitionLineItem.MapFromDomainEntity(RequisitionDTO.MapToRequisitionLineItemDTO(x))).ToList();
				objRequisition.RequisitionLineItems.ToList().ForEach(x => { x.RequisitionHeaderId = objRequisition.Id; x.Id = Guid.NewGuid(); });

				_projectRequisitionRepository.Add(objRequisition);
			}

			// At last update all job definition details records
			jobDefinition.CoupaImporterJobDefinitionDetails.ToList().ForEach(c => { c.IsProcessed = true; c.IsSuccessful = true; });
			_coupaImporterRepository.UpdateAllJobDefinitionDetail(jobDefinitionId, jobDefinition.CoupaImporterJobDefinitionDetails);

			jobDefinition.Status = (int)CoupaImporterStatus.Processed;
			_coupaImporterRepository.Update(jobDefinitionId, jobDefinition);

			_unitOfWork.SaveChanges();
			_unitOfWork.AutoDetectChanges(true);

			return CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity(jobDefinition);

		}

		public CoupaImporterJobDefinitionDTO SetCoupaImporterJobDefinitionDTO<T>(IEnumerable<T> dataList, Guid projectId, string fileName, FileType fileType) where T : new()
		{
			var coupaImporter = new CoupaImporterJobDefinitionDTO
			{
				FileName = fileName,
				Status = CoupaImporterStatus.Pending,
				TimeStamp = DateTime.UtcNow,
				ProjectId = projectId,
				FileType = fileType.ToString(),
				CoupaImporterJobDefinitionDetails = dataList.Select((line, index) => new CoupaImporterJobDefinitionDetailDTO
				{
					IsProcessed = false,
					IsSuccessful = null,
					RawContent = JsonConvert.SerializeObject(line),
					LineNumber = index + 1
				}).ToList()
			};
			return coupaImporter;
		}
	}
}
