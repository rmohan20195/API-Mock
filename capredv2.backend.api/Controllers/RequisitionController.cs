using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace capredv2.backend.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class RequisitionController : Controller
    {
        private readonly IProjectRequisitionService _projectRequistionService;
        private readonly IUnitOfWork _unitOfWork;

        public RequisitionController(IProjectRequisitionService projectRequistionService, IUnitOfWork unitOfWork)
        {
            _projectRequistionService = projectRequistionService ?? throw new ArgumentNullException(nameof(projectRequistionService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetHeaders(Guid projectId, int pageNumber, int pageSize)
        {
            var requisitionList = _projectRequistionService.GetHeaders(projectId, pageNumber, pageSize);

            if (requisitionList == null)
                return NotFound();

            return Ok(requisitionList);
        }

        [HttpGet]
        [Route("GetListItems")]
        public IActionResult GetListItems(Guid requisitionHeaderId)
        {
            var requisitionLineItems = _projectRequistionService.GetLineItems(requisitionHeaderId);

            if (requisitionLineItems == null)
                return NotFound();

            return Ok(requisitionLineItems);
        }

        [HttpPost]
        [Route("AddLineItem")]
        public IActionResult AddLineItem([FromBody]RequisitionLineItemDTO entries)
        {
            if (entries == null) return BadRequest("Required data not supplied.");

            var reqLineItem = _projectRequistionService.AddLineItem(entries);

            _unitOfWork.SaveChanges();
            return Ok(reqLineItem);
        }
    }
}