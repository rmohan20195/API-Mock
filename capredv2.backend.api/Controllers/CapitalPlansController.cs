using System;
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
    public class CapitalPlansController : Controller
    {
        private readonly ICapitalPlanService _capitalPlanService;
        private readonly IUnitOfWork _unitOfWork;

        public CapitalPlansController(ICapitalPlanService capitalPlanService,
            IUnitOfWork unitOfWork)
        {
            _capitalPlanService = capitalPlanService ??
                                         throw new ArgumentNullException(nameof(capitalPlanService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        // GET /api/CapitalPlans?id=2509d0dc-fa61-48a5-8650-684592539742
        [HttpGet]
        [Route("")]
        public IActionResult Get(Guid id)
        {
            var projectInformationDTO = _capitalPlanService.Get(id);

            if (projectInformationDTO == null)
                return NotFound();

            return Ok(projectInformationDTO);
        }

        // PUT /api/CapitalPlans?id=2509d0dc-fa61-48a5-8650-684592539742
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CapitalPlanDTO capitalPlanDTO)
        {
            if (capitalPlanDTO == null)
            {
                return BadRequest("Could not convert the content of the Body to a Project Information.");
            }

            _capitalPlanService.Update(id, capitalPlanDTO);

            var response = await _unitOfWork.SaveChangesAsync();

            if (response == 0)
                return NotFound();

            return NoContent();
        }
    }
}
