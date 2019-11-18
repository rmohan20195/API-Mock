using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using capredv2.backend.domain.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace capredv2.backend.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class CoupaImporterController : Controller
    {
        private readonly ICoupaImporterService _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public CoupaImporterController(ICoupaImporterService coupaImporterService, IUnitOfWork unitOfWork, IBackgroundJobClient backgroundJobClient)
        {
            _service = coupaImporterService ?? throw new ArgumentNullException(nameof(coupaImporterService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
        }

        // POST /api/CoupaImporter/upload-invoice?projectId=4d75753e-618d-4067-9019-f91a64407bca
        [HttpPost]
        [Route("upload-invoice")]
        public async Task<IActionResult> UploadInvoice(Guid projectId)
        {
                if (Request.Form.Files.Count == 0)
                {
                    return new UnsupportedMediaTypeResult();
                }

                var file = Request.Form.Files[0];

                if (!file.ContentType.Contains("text/csv") && !file.ContentType.Contains("ms-excel"))
                {
                    return new UnsupportedMediaTypeResult();
                }

                if (file.Length == 0)
                {
                    return new UnsupportedMediaTypeResult();
                }

                CoupaImporterJobDefinitionDTO jobDefinitionDTO;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    jobDefinitionDTO = _service.CreateInvoiceImportJobDefinition(projectId, memoryStream, file.FileName);
                    if (jobDefinitionDTO == null)
                    {
                        return BadRequest(
                            "An error occurred while uploading the file, please try again or contact the system administrator.");
                    }
                }

               await _unitOfWork.SaveChangesAsync();

            // Enqueue background job to import all data in Invoice table
            _backgroundJobClient.Enqueue(() => _service.ProcessInvoiceImportJob(jobDefinitionDTO.Id));
                return Ok(jobDefinitionDTO);
        }

   

        // POST /api/CoupaImporter/upload-purchase-order?projectId=4d75753e-618d-4067-9019-f91a64407bca
        [HttpPost]
        [Route("upload-purchase-order")]
        public async Task<IActionResult> UploadPurchaseOrder(Guid projectId)
        {
            var file = Request.Form.Files[0];

            if (!file.ContentType.Contains("text/csv") && !file.ContentType.Contains("ms-excel"))
            {
                return new UnsupportedMediaTypeResult();
            }

            if (file.Length == 0)
            {
                return new UnsupportedMediaTypeResult();
            }

            CoupaImporterJobDefinitionDTO jobDefinitionDTO;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                jobDefinitionDTO = _service.CreatePurchaseOrderImportJobDefinition(projectId, memoryStream, file.FileName);
                if (jobDefinitionDTO == null)
                {
                    return BadRequest(
                        "An error occurred while uploading the file, please try again or contact the system administrator.");
                }
            }
            await _unitOfWork.SaveChangesAsync();
            // Enqueue background job to import all data in Purchase Order table
            _backgroundJobClient.Enqueue(() => _service.ProcessPurchaseOrderImportJob(jobDefinitionDTO.Id));
            return Ok(jobDefinitionDTO);
        }

        // POST /api/CoupaImporter/upload-requisition?projectId=4d75753e-618d-4067-9019-f91a64407bca
        [HttpPost]
        [Route("upload-requisition")]
        public async Task<IActionResult> UploadRequisition(Guid projectId)
        {
            if (Request.Form.Files.Count == 0)
            {
                return new UnsupportedMediaTypeResult();
            }

            var file = Request.Form.Files[0];

            if (!file.ContentType.Contains("text/csv") && !file.ContentType.Contains("ms-excel"))
            {
                return new UnsupportedMediaTypeResult();
            }

            if (file.Length == 0)
            {
                return new UnsupportedMediaTypeResult();
            }

            CoupaImporterJobDefinitionDTO jobDefinitionDTO;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                jobDefinitionDTO = _service.CreateRequisitionImportJobDefinition(projectId, memoryStream, file.FileName);
                if (jobDefinitionDTO == null)
                {
                    return BadRequest(
                        "An error occurred while uploading the file, please try again or contact the system administrator.");
                }
            }
            await _unitOfWork.SaveChangesAsync();

            // Enqueue background job to import all data in Requisition table
            _backgroundJobClient.Enqueue(() => _service.ProcessRequisitionImportJob(jobDefinitionDTO.Id));
            return Ok(jobDefinitionDTO);
        }
    }
}

