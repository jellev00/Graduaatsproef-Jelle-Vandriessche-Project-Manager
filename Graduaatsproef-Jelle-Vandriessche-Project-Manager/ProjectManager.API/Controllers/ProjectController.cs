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
        private UserManager _userManager;

        public ProjectController(ProjectManager.BL.Managers.ProjectManager projectManager, UserManager userManager)
        {
            _projectManager = projectManager;
            _userManager = userManager;
        }

        // The ~ character in the route template specifies that the route should be relative to the application root.
        [HttpGet("~/api/User/{UserID}/[controller]")]
        public ActionResult<List<Project>> GetProjectByUserID(int UserID)
        {
            try
            {
                if (_userManager.UserExistsID(UserID))
                {
                    List<Project> projects = _projectManager.GetAllProjects(UserID);
                    return Ok(projects);
                }

                return NotFound($"User with ID {UserID} not found.");
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
                var project = new Project(projectDTO.UserId, projectDTO.Name, projectDTO.Description, projectDTO.Color);
                _projectManager.AddProject(project);

                var createdProjectDTO = new ProjectDTO(project.UserId, project.Name, project.Description, project.Color);

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
