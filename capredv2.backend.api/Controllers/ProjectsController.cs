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
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IProjectService projectService, IUnitOfWork unitOfWork)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // Get /api/Projects/PagedCollection?pageNumber=1&pageSize=10&facility=search&region=search
        [HttpGet]
        [Route("PagedCollection")]
        public IActionResult PagedGet(int pageNumber, int pageSize, string facility, string region)
        {
            var response = _projectService.GetPaged(pageNumber, pageSize, facility, region);
            return Ok(response);
        }

        // GET /api/Projects?id=2509d0dc-fa61-48a5-8650-684592539742
        [HttpGet]
        [Route("")]
        public IActionResult Get(Guid id)
        {
            var projectDTO = _projectService.Get(id);

            if (projectDTO == null)
                return NotFound();

            return Ok(projectDTO);
        }

        // POST /api/Projects/PagedCollection?pageNumber=1&pageSize=10
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody]ProjectDTO projectDTO)
        {
            var response = _projectService.Add(projectDTO);

            await _unitOfWork.SaveChangesAsync();

            return Ok(response);
        }


    }
}
