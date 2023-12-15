using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Models;
using ProjectManager.BL.Models;
using ProjectManager.BL.Managers;
using System.Threading.Tasks;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        private ProjectTasksManager _projectTasksManager;
        private ProjectManager.BL.Managers.ProjectManager _projectManager;
        public ProjectTasksController(ProjectTasksManager projectTasksManager, BL.Managers.ProjectManager projectManager)
        {
            _projectTasksManager = projectTasksManager;
            _projectManager = projectManager;
        }

        [HttpGet("~/api/Project/{projectID}/[controller]")]
        public ActionResult<List<ProjectTasks>> GetTasksByProjectID(int projectID)
        {
            try
            {
                if (_projectManager.ProjectExists(projectID))
                {
                    List<ProjectTasks> Tasks = _projectTasksManager.GetAllTasks(projectID);
                    return Ok(Tasks);
                }
                return NotFound($"Project with ID {projectID} not found.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProjectTasksDTO> AddTask([FromBody] ProjectTasksDTO projectTasksDTO)
        {
            try
            {
                var task = new ProjectTasks(projectTasksDTO.ProjectId, projectTasksDTO.TaskName, projectTasksDTO.TaskDescription, projectTasksDTO.Color);
                _projectTasksManager.AddTask(task);

                var CreatedProjectTasksDTO = new ProjectTasksDTO(task.ProjectId, task.TaskName, task.TaskDescription, task.Color);
                return CreatedAtAction(nameof(GetTasksByProjectID), new { ProjectId = task.ProjectId }, CreatedProjectTasksDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{TaskID}")]
        public ActionResult DeleteTask(int TaskID)
        {
            try
            {
                if (!_projectTasksManager.TaskExists(TaskID))
                {
                    return NotFound();
                }
                else
                {
                    _projectTasksManager.DeleteTask(TaskID);
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
