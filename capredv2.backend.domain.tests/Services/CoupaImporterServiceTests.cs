using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using capredv2.backend.domain.DomainEntities.Enums;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services;
using capredv2.backend.domain.Services.Interfaces;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.Services
{
    [TestFixture]
    public class CoupaImporterServiceTests
    {
        private ICoupaImporterRepository _coupaImporterRepository;
        private ICoupaImporterService _service;
        private IUnitOfWork _unitOfWork;
        private IProjectInvoiceRepository _projectInvoiceRepository;
        private IProjectPurchaseOrderRepository _projectPurchaseOrderRepository;
        private IProjectRequisitionRepository _projectRequisitionRepository;

        [SetUp]
        public void Setup()
        {
            _coupaImporterRepository = Substitute.For<ICoupaImporterRepository>();
            _projectPurchaseOrderRepository = Substitute.For<IProjectPurchaseOrderRepository>();
            _projectInvoiceRepository = Substitute.For<IProjectInvoiceRepository>();
            _projectRequisitionRepository = Substitute.For<IProjectRequisitionRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _service = new CoupaImporterService(_coupaImporterRepository, _projectInvoiceRepository, _projectPurchaseOrderRepository, _projectRequisitionRepository, _unitOfWork);
        }

        [Test]
        public void CreateInstance_OmittingRepository_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterService(null,  _projectInvoiceRepository, _projectPurchaseOrderRepository, _projectRequisitionRepository, _unitOfWork));

            //Assert
            StringAssert.Contains("coupaImporterRepository", ex.Message);
        }

        [Test]
        public void CreateInstance_OmittingInvoiceRepository_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterService(_coupaImporterRepository, null, _projectPurchaseOrderRepository, _projectRequisitionRepository, _unitOfWork));

            //Assert
            StringAssert.Contains("projectInvoiceRepository", ex.Message);
        }


        [Test]
        public void CreateInstance_OmittingPurchaseOrderRepository_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterService(_coupaImporterRepository, _projectInvoiceRepository, null, _projectRequisitionRepository, _unitOfWork));

            //Assert
            StringAssert.Contains("projectPurchaseOrderRepository", ex.Message);
        }

        [Test]
        public void CreateInstance_OmittingRequisitionRepository_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterService(_coupaImporterRepository,  _projectInvoiceRepository, _projectPurchaseOrderRepository, null, _unitOfWork));

            //Assert
            StringAssert.Contains("projectRequisitionRepository", ex.Message);
        }

        [Test]
        public void CreateInstance_OmittingUnitOfWork_ThrowArgumentNullException()
        {

            //Act
            // ReSharper disable once ObjectCreationAsStatement
            var ex = Assert.Throws<ArgumentNullException>(() => new CoupaImporterService(_coupaImporterRepository, _projectInvoiceRepository, _projectPurchaseOrderRepository, _projectRequisitionRepository, null));

            //Assert
            StringAssert.Contains("unitOfWork", ex.Message);
        }

        [Test]
        public void CreateInvoiceImportJobDefinition_StreamAndFileName_ReturnValidCoupaImporterJobDefinitionDTO()
        {
            //Arrange
            var projectId = new Guid("4d75753e-618d-4067-9019-f91a64407bca");
            var jobDefinition = new CoupaImporterJobDefinition
            {
                Id = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4"),
                FileName = "fileTest.csv",
                Status = (int)CoupaImporterStatus.Pending,
                TimeStamp = DateTime.UtcNow,
                ProjectId = projectId
            };

            _coupaImporterRepository.Add(Arg.Is<CoupaImporterJobDefinition>(c => c.FileName == jobDefinition.FileName && c.ProjectId == projectId))
                .Returns(jobDefinition);

            //Act
            var result = _service.CreateInvoiceImportJobDefinition(projectId, ValidCsv(), "fileTest.csv");

            //Assert
            Assert.AreEqual(jobDefinition.Id, result.Id);
        }
        [Test]
        public void CreatePurchaseOrderImportJobDefinition_StreamAndFileName_ReturnValidCoupaImporterJobDefinitionDTO()
        {
            //Arrange
            var projectId = new Guid("4d75753e-618d-4067-9019-f91a64407bca");
            var jobDefinition = new CoupaImporterJobDefinition
            {
                Id = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4"),
                FileName = "fileTest.csv",
                Status = (int)CoupaImporterStatus.Pending,
                TimeStamp = DateTime.UtcNow,
                ProjectId = projectId
            };

            _coupaImporterRepository.Add(Arg.Is<CoupaImporterJobDefinition>(c => c.FileName == jobDefinition.FileName && c.ProjectId == projectId))
                .Returns(jobDefinition);

            //Act
            var result = _service.CreatePurchaseOrderImportJobDefinition(projectId, ValidCsv(), "fileTest.csv");

            //Assert
            Assert.AreEqual(jobDefinition.Id, result.Id);
        }
        [Test]
        public void CreateRequisitionImportJobDefinition_StreamAndFileName_ReturnValidCoupaImporterJobDefinitionDTO()
        {
            //Arrange
            var projectId = new Guid("4d75753e-618d-4067-9019-f91a64407bca");
            var jobDefinition = new CoupaImporterJobDefinition
            {
                Id = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4"),
                FileName = "fileTest.csv",
                Status = (int)CoupaImporterStatus.Pending,
                TimeStamp = DateTime.UtcNow,
                ProjectId = projectId
            };

            _coupaImporterRepository.Add(Arg.Is<CoupaImporterJobDefinition>(c => c.FileName == jobDefinition.FileName && c.ProjectId == projectId))
                .Returns(jobDefinition);

            //Act
            var result = _service.CreateRequisitionImportJobDefinition(projectId, ValidCsv(), "fileTest.csv");

            //Assert
            Assert.AreEqual(jobDefinition.Id, result.Id);
        }


        [Test]
        public void ProcessInvoiceImportJob_JobId_ProcessEachLineOfInvoiceJobDetailsAndChangesItsStatusToProcessed()
        {
            //Arrange
            var jobDefinitionId = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4");

            var jobDefinition = new CoupaImporterJobDefinition
            {
                Id = jobDefinitionId,
                FileName = "Test.csv",
                Status = (int)CoupaImporterStatus.Pending,
                CoupaImporterJobDefinitionDetails = new List<CoupaImporterJobDefinitionDetail>
                {
                    new CoupaImporterJobDefinitionDetail
                    {
                        Id = new Guid("90d18a32-5090-4091-9c16-91dcb7983c38"),
                        IsProcessed = false,
                        IsSuccessful = null,
                        ErrorDescription = null,
                        LineNumber = 1,
                        RawContent = "{\"Id\":\"77dc1029-b2ba-4beb-a8df-7214ae3baad8\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":\"HYPOVEREINSBANK BKK\",\"PurchaseOrderNumber\":null,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}"
                    },
                    new CoupaImporterJobDefinitionDetail
                    {
                        Id = new Guid("35246731-7870-400d-a646-456e5f824df7"),
                        IsProcessed = false,
                        IsSuccessful = null,
                        ErrorDescription = null,
                        LineNumber = 2,
                        RawContent = "{\"Id\":\"e7344d8f-809c-4667-bb87-ccf1d692eaa2\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":null,\"PurchaseOrderNumber\":null,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}"
                    }
                }
            };

            _coupaImporterRepository.Get(jobDefinitionId)
                .Returns(jobDefinition);

            //Act
            var response = _service.ProcessInvoiceImportJob(jobDefinitionId);

            //Assert
            Assert.AreEqual(CoupaImporterStatus.Processed, response.Status);
            Assert.IsEmpty(response.CoupaImporterJobDefinitionDetails.Where(d => d.IsProcessed == false));

            _coupaImporterRepository.Received(1)
                .UpdateAllJobDefinitionDetail(
                    jobDefinition.Id,
                    Arg.Is<List<CoupaImporterJobDefinitionDetail>>(d => 
                                                    d.First().Id == jobDefinition.CoupaImporterJobDefinitionDetails.First().Id &&
                                                    d.First().IsSuccessful == true && d.First().IsProcessed == true));

            _coupaImporterRepository.Received(1)
                .UpdateAllJobDefinitionDetail(
                    jobDefinition.Id,
                    Arg.Is<List<CoupaImporterJobDefinitionDetail>>(d =>
                                                    d.First().Id == jobDefinition.CoupaImporterJobDefinitionDetails.First().Id &&
                                                    d.Last().IsSuccessful == true && d.Last().IsProcessed == true));

            _coupaImporterRepository.Received(1)
                .Update(jobDefinitionId,
                    Arg.Is<CoupaImporterJobDefinition>(j =>
                        j.Id == jobDefinitionId && j.Status == (int)CoupaImporterStatus.Processed));


        }
        [Test]
        public void ProcessPurchaseOrderImportJob_JobId_ProcessEachLineOfInvoiceJobDetailsAndChangesItsStatusToProcessed()
        {
            //Arrange
            var jobDefinitionId = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4");

            var jobDefinition = new CoupaImporterJobDefinition
            {
                Id = jobDefinitionId,
                FileName = "Test.csv",
                Status = (int)CoupaImporterStatus.Pending,
                CoupaImporterJobDefinitionDetails = new List<CoupaImporterJobDefinitionDetail>
                {
                    new CoupaImporterJobDefinitionDetail
                    {
                        Id = new Guid("90d18a32-5090-4091-9c16-91dcb7983c38"),
                        IsProcessed = false,
                        IsSuccessful = null,
                        ErrorDescription = null,
                        LineNumber = 1,
                        RawContent = "{\"Id\":\"77dc1029-b2ba-4beb-a8df-7214ae3baad8\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":\"HYPOVEREINSBANK BKK\",\"PurchaseOrderNumber\":12,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}"
                    },
                    new CoupaImporterJobDefinitionDetail
                    {
                        Id = new Guid("35246731-7870-400d-a646-456e5f824df7"),
                        IsProcessed = false,
                        IsSuccessful = null,
                        ErrorDescription = null,
                        LineNumber = 2,
                        RawContent = "{\"Id\":\"e7344d8f-809c-4667-bb87-ccf1d692eaa2\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":null,\"PurchaseOrderNumber\":13,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}"
                    }
                }
            };

            _coupaImporterRepository.Get(jobDefinitionId)
                .Returns(jobDefinition);

            //Act
            var response = _service.ProcessPurchaseOrderImportJob(jobDefinitionId);

            //Assert
            Assert.AreEqual(CoupaImporterStatus.Processed, response.Status);
            Assert.IsEmpty(response.CoupaImporterJobDefinitionDetails.Where(d => d.IsProcessed == false));

            _coupaImporterRepository.Received(1)
               .UpdateAllJobDefinitionDetail(
                   jobDefinition.Id,
                   Arg.Is<List<CoupaImporterJobDefinitionDetail>>(d =>
                                                   d.First().Id == jobDefinition.CoupaImporterJobDefinitionDetails.First().Id &&
                                                   d.First().IsSuccessful == true && d.First().IsProcessed == true));

            _coupaImporterRepository.Received(1)
                .UpdateAllJobDefinitionDetail(
                    jobDefinition.Id,
                    Arg.Is<List<CoupaImporterJobDefinitionDetail>>(d =>
                                                    d.First().Id == jobDefinition.CoupaImporterJobDefinitionDetails.First().Id &&
                                                    d.Last().IsSuccessful == true && d.Last().IsProcessed == true));

            _coupaImporterRepository.Received(1)
                .Update(jobDefinitionId,
                    Arg.Is<CoupaImporterJobDefinition>(j =>
                        j.Id == jobDefinitionId && j.Status == (int)CoupaImporterStatus.Processed));

        }
        [Test]
        public void ProcessRequisitionImportJob_JobId_ProcessEachLineOfPurchaseOrderJobDetailsAndChangesItsStatusToProcessed()
        {
            //Arrange
            var jobDefinitionId = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4");

            var jobDefinition = new CoupaImporterJobDefinition
            {
                Id = jobDefinitionId,
                FileName = "Test.csv",
                Status = (int)CoupaImporterStatus.Pending,
                CoupaImporterJobDefinitionDetails = new List<CoupaImporterJobDefinitionDetail>
                {
                    new CoupaImporterJobDefinitionDetail
                    {
                        Id = new Guid("90d18a32-5090-4091-9c16-91dcb7983c38"),
                        IsProcessed = false,
                        IsSuccessful = null,
                        ErrorDescription = null,
                        LineNumber = 1,
                        RawContent = "{\"Id\":\"54a85421-ab58-4fef-ae4c-ab5651501291\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"PurchaseOrderNumber\":7116,\"OrderTotal\":7630.0,\"AccountingTotal\":5608.64,\"Account\":\"6063-521-5412424-203050-SN-00000-000-000\",\"Supplier\":\"MEDIALINK PRINTING SERVICES PTE LTD\",\"OrderDate\":\"2019-05-05T00:00:00\",\"Item\":\"Q2 printing of brochures and placemats for SG Banks\",\"AccountingTotalCurrency\":\"USD\",\"Currency\":\"SGD\",\"ShippingAddress\":\"Twenty Anson, 20 Anson Road\n#18-01 Singapore 079912 Singapore\", \"ProjectDescription\":null, \"Commodity\":\"Mktg Print & Fulfillment (5412424 Print - Marketing Collateral)\", \"CostCode\":null, \"FixedAsset_CIPCategory\":null, \"TargetLocationCode\":null, \"ShipTo\":\"Andy Lim\", \"RequestedBy\":\"Andy Lim\", \"CreatedBy\":\"Doris Ma\", \"LastUpdatedBy\":\"Doris Ma\"}"
                    },
                    new CoupaImporterJobDefinitionDetail
                    {
                        Id = new Guid("35246731-7870-400d-a646-456e5f824df7"),
                        IsProcessed = false,
                        IsSuccessful = null,
                        ErrorDescription = null,
                        LineNumber = 2,
                        RawContent = "{\"Id\":\"97647256-c8f1-4065-babb-670e7943a04b\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"PurchaseOrderNumber\":7117,\"OrderTotal\":16100.0,\"AccountingTotal\":2052.22,\"Account\":\"6063-521-5412424-203050-SN-00000-000-000\",\"Supplier\":\"HETERMEDIA SERVICES LIMITED\",\"OrderDate\":\"2019-05-05T00:00:00\",\"Item\":\"Quarterly Update of Marketing Collaterals - Q2\",\"AccountingTotalCurrency\":\"USD\",\"Currency\":\"HKD\",\"ShippingAddress\":\"Twenty Anson, 20 Anson Road\\n#18-01\nSingapore 079912\nSingapore\",\"ProjectDescription\":null,\"Commodity\":\"Mktg Print & Fulfillment (5412424 Print - Marketing Collateral)\",\"CostCode\":null,\"FixedAsset_CIPCategory\":null,\"TargetLocationCode\":null,\"ShipTo\":\"Andy Lim\",\"RequestedBy\":\"Andy Lim\",\"CreatedBy\":\"Karen Leung\",\"LastUpdatedBy\":\"Karen Leung\"}"
                    }
                }
            };

            _coupaImporterRepository.Get(jobDefinitionId)
                .Returns(jobDefinition);

            //Act
            var response = _service.ProcessRequisitionImportJob(jobDefinitionId);

            //Assert
            Assert.AreEqual(CoupaImporterStatus.Processed, response.Status);
            Assert.IsEmpty(response.CoupaImporterJobDefinitionDetails.Where(d => d.IsProcessed == false));

            _coupaImporterRepository.Received(1)
                .UpdateAllJobDefinitionDetail(
                    jobDefinition.Id,
                    Arg.Is<List<CoupaImporterJobDefinitionDetail>>(d =>
                                                    d.First().Id == jobDefinition.CoupaImporterJobDefinitionDetails.First().Id &&
                                                    d.First().IsSuccessful == true && d.First().IsProcessed == true));

            _coupaImporterRepository.Received(1)
                .UpdateAllJobDefinitionDetail(
                    jobDefinition.Id,
                    Arg.Is<List<CoupaImporterJobDefinitionDetail>>(d =>
                                                    d.First().Id == jobDefinition.CoupaImporterJobDefinitionDetails.First().Id &&
                                                    d.Last().IsSuccessful == true && d.Last().IsProcessed == true));

            _coupaImporterRepository.Received(1)
                .Update(jobDefinitionId,
                    Arg.Is<CoupaImporterJobDefinition>(j =>
                        j.Id == jobDefinitionId && j.Status == (int)CoupaImporterStatus.Processed));
        }

        [Test]
        public void SetCoupaImporterJobDefinitionDTO_ReturnValidEntity()
        {
            //Arrange
            var projectId = Guid.NewGuid();
            var coupaImporterJobDefinitionDTO = new CoupaImporterJobDefinitionDTO()
            {
                FileName = "test.csv",
                Status = CoupaImporterStatus.Pending,
                TimeStamp = DateTime.UtcNow,
                ProjectId = projectId,
                CoupaImporterJobDefinitionDetails = ValidCoupaImporterJobDefinationDetails()
            };

            //Act
            var response = _service.SetCoupaImporterJobDefinitionDTO<InvoiceDTO>(ValidInvoiceDTOList(), projectId, "test.csv", FileType.Invoice);

            //Assert
            Assert.AreEqual(projectId, response.ProjectId);
            Assert.AreEqual(coupaImporterJobDefinitionDTO.FileName, response.FileName);
            Assert.AreEqual(coupaImporterJobDefinitionDTO.Status, response.Status);
            Assert.AreEqual(coupaImporterJobDefinitionDTO.CoupaImporterJobDefinitionDetails.Count(), response.CoupaImporterJobDefinitionDetails.Count());
            Assert.AreEqual(coupaImporterJobDefinitionDTO.CoupaImporterJobDefinitionDetails.First().RawContent, coupaImporterJobDefinitionDTO.CoupaImporterJobDefinitionDetails.First().RawContent);
            Assert.AreEqual(coupaImporterJobDefinitionDTO.CoupaImporterJobDefinitionDetails.Last().RawContent, coupaImporterJobDefinitionDTO.CoupaImporterJobDefinitionDetails.Last().RawContent);
        }

        private static MemoryStream ValidCsv()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Supplier,Account , Total");
            sb.AppendLine("6063-521-5412424-203050-SN-00000-000-000, someContentHere, 16100");
            sb.Append("804-314-5415205-421130-FY-00000-000-000, 11495");

            var bytes = Encoding.ASCII.GetBytes(sb.ToString());

            var memStream = new MemoryStream();
            memStream.Write(bytes, 0, bytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            return memStream;
        }

        private static MemoryStream InValidCsv()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Header 1, Header 2, Header 3. Header 4");
            sb.AppendLine("John Smith, someContentHere, moreDefinition. 4thData");
            sb.Append("John Smith, someContentHere2, moreDefinition2. 4thData");

            var bytes = Encoding.ASCII.GetBytes(sb.ToString());

            var memStream = new MemoryStream();
            memStream.Write(bytes, 0, bytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            return memStream;
        }

        private static IEnumerable<CoupaImporterJobDefinitionDetailDTO> ValidCoupaImporterJobDefinationDetails()
        {
            var coupaImporterJobDefinitionDetailDTO = new List<CoupaImporterJobDefinitionDetailDTO>()
            {
                new CoupaImporterJobDefinitionDetailDTO
                {
                    IsProcessed = false,
                    IsSuccessful = null,
                    RawContent = "{\"Id\":\"77dc1029-b2ba-4beb-a8df-7214ae3baad8\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":\"HYPOVEREINSBANK BKK\",\"PurchaseOrderNumber\":null,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}",
                    LineNumber = 1
                },
                new CoupaImporterJobDefinitionDetailDTO
                {
                    IsProcessed = false,
                    IsSuccessful = null,
                    RawContent = "{\"Id\":\"77dc1029-b2ba-4beb-a8df-7214ae3baad8\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":\"HYPOVEREINSBANK BKK\",\"PurchaseOrderNumber\":null,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}",
                    LineNumber = 2
                }
            };
            return coupaImporterJobDefinitionDetailDTO;
        }

        private static IEnumerable<InvoiceDTO> ValidInvoiceDTOList()
        {
            var invoiceDTOs = new List<InvoiceDTO>()
            {
                JsonConvert.DeserializeObject<InvoiceDTO>("{\"Id\":\"77dc1029-b2ba-4beb-a8df-7214ae3baad8\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":\"HYPOVEREINSBANK BKK\",\"PurchaseOrderNumber\":null,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}"),
                JsonConvert.DeserializeObject<InvoiceDTO>("{\"Id\":\"77dc1029-b2ba-4beb-a8df-7214ae3baad8\",\"ProjectId\":\"00000000-0000-0000-0000-000000000000\",\"InvoiceNumber\":null,\"Total\":0.0,\"Paid\":false,\"Account\":null,\"Supplier\":\"HYPOVEREINSBANK BKK\",\"PurchaseOrderNumber\":null,\"InvoiceDate\":\"2019-05-06T00:00:00\",\"ReceivedOrCreatedDate\":\"0001 - 01 - 01T00: 00:00\",\"Status\":\"New\",\"LocalPaymentDate\":null}"),

            };
            return invoiceDTOs;
        }
    }
}
