using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace capredv2.backend.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class PurchaseOrderController : Controller
    {
        private readonly IProjectPurchaseOrderService _projectPurchaseOrderService;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderController(IProjectPurchaseOrderService projectPurchaseOrderService, IUnitOfWork unitOfWork)
        {
            _projectPurchaseOrderService = projectPurchaseOrderService ?? throw new ArgumentNullException(nameof(projectPurchaseOrderService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetHeaders(Guid projectId, int pageNumber, int pageSize)
        {
            var purchaseOrderList = _projectPurchaseOrderService.GetHeaders(projectId, pageSize, pageNumber);

            if (purchaseOrderList == null)
                return NotFound();

            return Ok(purchaseOrderList);
        }

        [HttpGet]
        [Route("GetListItems")]
        public IActionResult GetListItems(Guid purchaseOrderHeaderId)
        {
            var purchaseOrderLineItems = _projectPurchaseOrderService.GetLineItems(purchaseOrderHeaderId);

            if (purchaseOrderLineItems == null)
                return NotFound();

            return Ok(purchaseOrderLineItems);
        }

        [HttpPost]
        [Route("AddLineItem")]
        public IActionResult AddLineItem([FromBody]POLineItemDTO entries)
        {
            if (entries == null) return BadRequest("Required data not supplied.");

            var poLineItem = _projectPurchaseOrderService.AddLineItem(entries);

            _unitOfWork.SaveChanges();
            return Ok(poLineItem);
        }
    }
}