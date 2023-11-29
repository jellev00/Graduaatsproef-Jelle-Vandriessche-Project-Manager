using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Models;
using ProjectManager.BL.Models;
using ProjectManager.BL.Managers;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ProjectManager.BL.Managers.ProjectManager _projectManager;

        public ProjectController(ProjectManager.BL.Managers.ProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        // The ~ character in the route template specifies that the route should be relative to the application root.
        [HttpGet("~/api/user/{UserID}/[controller]")]
        public ActionResult<List<Project>> GetProjectByUserID(int UserID)
        {
            try
            {
                List<Project> projects = _projectManager.GetAllProjects(UserID);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProjectDTO> AddProject([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                var project = new Project(projectDTO.UserId, projectDTO.Name, projectDTO.Description);
                _projectManager.AddProject(project);

                var createdProjectDTO = new ProjectDTO(project.UserId, project.Name, project.Description);

                return CreatedAtAction(nameof(GetProjectByUserID), new { ProjectId = project.ProjectId }, createdProjectDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{projectID}")]
        public ActionResult DeleteProject(int projectID)
        {
            try
            {
                if (!_projectManager.ProjectExists(projectID))
                {
                    return NotFound();
                }
                else
                {
                    _projectManager.DeleteProject(projectID);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
