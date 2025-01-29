using CharityManager.API.Model;
using CharityManager.API.Services.Implementation;
using CharityManager.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CharityManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet(Name = "GetProjects")]
        [ProducesResponseType(typeof(IEnumerable<ProjectModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();

            if (projects == null || !projects.Any())
                return NotFound("No projects found.");

            return Ok(projects);
        }

        [HttpGet("pending", Name = "GetPendingProjects")]
        [ProducesResponseType(typeof(IEnumerable<ProjectModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPendingProjects()
        {
            var projects = await _projectService.GetPendingProjectsAsync();

            if (projects == null || !projects.Any())
                return NotFound("No pending projects found.");

            return Ok(projects);
        }

        [HttpGet("{projectId}", Name = "GetProjectDetails")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProjectDetails([FromRoute] int projectId)
        {
            return Ok(_projectService.GetProjectDetails(projectId));
        }

        [HttpPost(Name = "CreateProject")]
        [ProducesResponseType(typeof(ProjectCreateRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateProject([FromBody] ProjectCreateRequest projectCreateRequest)
        {
            return Ok(_projectService.CreateProject(projectCreateRequest));
        }
    }
}
