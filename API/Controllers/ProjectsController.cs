using API.Dtos;
using API.Extentions;
using Domain.Models;
using Domain.Services;
using Infrastructure.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        private ProjectsService _projectsService;

        public ProjectsController(ProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedProjectDto projectDto)
        {
            Project project = projectDto.ToEntity();
            await _projectsService.AddAsync(project);

            return Ok();
        }
    }
}
