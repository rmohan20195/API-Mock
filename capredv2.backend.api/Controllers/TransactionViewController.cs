using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace capredv2.backend.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionViewController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IProjectPurchaseOrderService _projectPurchaseOrderService;
        private readonly IProjectRequisitionService _projectRequistionService;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionViewController(IProjectService projectService, IProjectPurchaseOrderService projectPurchaseOrderService, IProjectRequisitionService projectRequistionService, IUnitOfWork unitOfWork)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            _projectPurchaseOrderService = projectPurchaseOrderService ?? throw new ArgumentNullException(nameof(projectPurchaseOrderService));
            _projectRequistionService = projectRequistionService ?? throw new ArgumentNullException(nameof(projectRequistionService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        // GET /api/TransactionView/TransactionCollection?projectId=2509d0dc-fa61-48a5-8650-684592539742&pageNumber=1&pageSize=10
        [HttpGet]
        [Route("TransactionCollection")]
        public IActionResult TransactionCollection(Guid projectId, int pageNumber, int pageSize)
        {
            var response = _projectService.GetTransaction(projectId, pageNumber, pageSize);
            return Ok(response);
        }

        // GET /api/TransactionView/TransactionDetails?poHeaderId=2509d0dc-fa61-48a5-8650-684592539742&reqHeaderId=2509d0dc-fa61-48a5-8650-684592539742
        [HttpGet]
        [Route("TransactionDetails")]
        public IActionResult TransactionDetails(Guid poHeaderId, Guid reqHeaderId)
        {
            var reqs = _projectRequistionService.GetLineItems(reqHeaderId);
            var pos = _projectPurchaseOrderService.GetLineItems(poHeaderId);
            return Ok(new { reqs, pos });
        }

        [HttpPost]
        // GET /api/TransactionView/ManualEntry
        [Route("ManualEntry")]
        public IActionResult ManualEntry([FromBody]ManualEntryDTO entries)
        {
            if (entries == null || entries.pOHeaderDTO == null || entries.requisitionHeaderDTO == null) return BadRequest("Required data not supplied.");

            var reqs = _projectRequistionService.Add(entries.requisitionHeaderDTO);
            var pos = _projectPurchaseOrderService.Add(entries.pOHeaderDTO);

            _unitOfWork.SaveChanges();
            return Ok(new { reqs, pos });
        }

    }
}