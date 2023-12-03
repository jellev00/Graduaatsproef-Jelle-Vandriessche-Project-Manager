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
    public class UserTasksController : ControllerBase
    {
        private UserTasksManager _userTasksManager;
        private UserManager _userManager;

        public UserTasksController(UserTasksManager userTasksManager, UserManager userManager)
        {
            _userTasksManager = userTasksManager;
            _userManager = userManager;
        }

        [HttpGet("~/api/User/{UserID}/[controller]")]
        public ActionResult<List<UserTasks>> GetTasksByUserID(int UserID)
        {
            try
            {
                if (_userManager.UserExistsID(UserID))
                {
                    List<UserTasks> Tasks = _userTasksManager.GetAllTasks(UserID);
                    return Ok(Tasks);
                }

                return NotFound($"User with ID {UserID} not found.");
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
                var task = new UserTasks(userTasksDTO.UserId, userTasksDTO.TaskName, userTasksDTO.TaskDescription, userTasksDTO.Color);
                _userTasksManager.AddTask(task);

                var createdUserTasksDTO = new UserTasksDTO(task.UserId, task.TaskName, task.TaskDescription, task.Color);

                return CreatedAtAction(nameof(GetTasksByUserID), new { UserID = task.UserId }, createdUserTasksDTO);
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
                if (!_userTasksManager.TaskExists(TaskID))
                {
                    return NotFound();
                }
                else
                {
                    _userTasksManager.DeleteTask(TaskID);
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
