using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Models;
using ProjectManager.BL.Models;
using ProjectManager.BL.Managers;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private UserTasksManager _userTasksManager;

        public UserTasksController(UserTasksManager userTasksManager)
        {
            _userTasksManager = userTasksManager;
        }

        [HttpGet("~/api/user/{UserID}/[controller]")]
        public ActionResult<List<UserTasks>> GetTasksByUserID(int UserID)
        {
            try
            {
                List<UserTasks> Tasks = _userTasksManager.GetAllTasks(UserID);
                return Ok(Tasks);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<UserTasksDTO> AddTask([FromBody] UserTasksDTO userTasksDTO)
        {
            try
            {
                var task = new UserTasks(userTasksDTO.UserId, userTasksDTO.TaskDescription);
                _userTasksManager.AddTask(task);

                var createdUserTasksDTO = new UserTasksDTO(task.UserId, task.TaskDescription);

                return CreatedAtAction(nameof(GetTasksByUserID), new { UserID = task.UserId }, createdUserTasksDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{userTaskID}")]
        public ActionResult DeleteProject(int userTaskID)
        {
            try
            {
                if (!_userTasksManager.TaskExists(userTaskID))
                {
                    return NotFound();
                }
                else
                {
                    _userTasksManager.DeleteTask(userTaskID);
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
