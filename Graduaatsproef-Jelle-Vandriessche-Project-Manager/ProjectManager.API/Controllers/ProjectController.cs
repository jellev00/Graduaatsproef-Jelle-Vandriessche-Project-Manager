using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Models;
using ProjectManager.BL.Models;
using ProjectManager.BL.Managers;
using ProjectManager.API.Models.Output;
using ProjectManager.API.Models.Input;

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

        // GET
        [HttpGet("{projectId}")]
        public ActionResult<UserOutput> GetProjectById(int projectId)
        {
            try
            {
                Project project = _projectManager.GetProjectById(projectId);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST
        [HttpPost("AddTask/{projectId}")]
        public ActionResult<ProjectTasksOutput> AddTaskToProject(int projectId, [FromBody] ProjectTasksInput tasksInput)
        {
            try
            {
                Project project = _projectManager.GetProjectById(projectId);

                ProjectTasks task = new ProjectTasks(project, tasksInput.TaskName, tasksInput.TaskDescription, tasksInput.Color);
                _projectManager.AddTaskToProject(projectId, task);

                return CreatedAtAction(nameof(GetProjectById), new { ProjectId = projectId }, task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCalendar/{projectId}")]
        public ActionResult<ProjectCalendarOutput> AddCalendarToProject(int projectId, [FromBody] ProjectCalendarInput calendarInput)
        {
            try
            {
                Project project = _projectManager.GetProjectById(projectId);

                ProjectCalendar calendar = new ProjectCalendar(project, calendarInput.Name, calendarInput.Description, calendarInput.Date);
                _projectManager.AddCalendarToProject(projectId, calendar);

                return CreatedAtAction(nameof(GetProjectById), new { ProjectId = projectId }, calendar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("Task/{projectTaskId}")]
        public ActionResult DeleteProjectTask(int projectTaskId)
        {
            try
            {
                if (!_projectManager.ProjectTasksExistsId(projectTaskId))
                {
                    return NotFound();
                }
                else
                {
                    _projectManager.DeleteProjectTask(projectTaskId);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Calendar/{projectCalendarId}")]
        public ActionResult DeleteProjectCalendar(int projectCalendarId)
        {
            try
            {
                if (!_projectManager.ProjectCalendarExistsId(projectCalendarId))
                {
                    return NotFound();
                }
                else
                {
                    _projectManager.DeleteProjectCalendar(projectCalendarId);
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
