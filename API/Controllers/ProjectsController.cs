using Application.Dtos.Projects;
using Application.Extentions;
using Application.Services;
using Domain.Models;
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            CreatedProjectDto? project = await _projectsService.GetAsync(id);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CreatedProjectDto> projects = await _projectsService.GetAllAsync();

            if (projects == null || projects.Count == 0)
                return NotFound();

            return Ok(projects);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Project project)
        {
            bool result = await _projectsService.UpdateAsync(id, project);

            if (result == false)
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _projectsService.DeleteAsync(id);

            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}
