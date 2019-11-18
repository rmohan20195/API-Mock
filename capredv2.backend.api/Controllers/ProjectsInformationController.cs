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
    public class ProjectsInformationController : Controller
    {
        private readonly IProjectInformationService _projectInformationService;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsInformationController(IProjectInformationService projectInformationService,
            IUnitOfWork unitOfWork)
        {
            _projectInformationService = projectInformationService ??
                                         throw new ArgumentNullException(nameof(projectInformationService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        // GET /api/ProjectsInformation?id=2509d0dc-fa61-48a5-8650-684592539742
        [HttpGet]
        [Route("")]
        public IActionResult Get(Guid id)
        {
            var projectInformationDTO = _projectInformationService.Get(id);

            if (projectInformationDTO == null)
                return NotFound();

            return Ok(projectInformationDTO);
        }

        // PUT /api/ProjectsInformation?id=2509d0dc-fa61-48a5-8650-684592539742
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProjectInformationDTO projectInformationDTO)
        {
            if (projectInformationDTO == null)
            {
                return BadRequest("Could not convert the content of the Body to a Project Information.");
            }

            _projectInformationService.Update(id, projectInformationDTO);

            var response = await _unitOfWork.SaveChangesAsync();

            if (response == 0)
                return NotFound();

            return NoContent();
        }
    }
}
