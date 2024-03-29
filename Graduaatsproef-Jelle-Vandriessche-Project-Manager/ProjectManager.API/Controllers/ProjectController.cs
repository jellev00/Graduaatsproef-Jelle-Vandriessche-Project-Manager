﻿using Microsoft.AspNetCore.Http;
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
        [HttpPost("{projectId}/Task")]
        public ActionResult<ProjectTasksOutput> AddTaskToProject(int projectId, [FromBody] ProjectTasksInput tasksInput)
        {
            try
            {
                Project project = _projectManager.GetProjectById(projectId);

                ProjectTasks task = new ProjectTasks(project, tasksInput.TaskName, tasksInput.TaskDescription, tasksInput.Color, tasksInput.Date, false);
                _projectManager.AddTaskToProject(projectId, task);

                return CreatedAtAction(nameof(GetProjectById), new { ProjectId = projectId }, task);
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

        // UPDATE
        [HttpPut("Task/{taskId}")]
        public ActionResult UpdateTaskStatus(int taskId, [FromBody] bool newStatus)
        {
            try
            {
                // Find the task by taskId and update its status
                _projectManager.UpdateTaskStatus(taskId, newStatus);

                return Ok("Task status updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
