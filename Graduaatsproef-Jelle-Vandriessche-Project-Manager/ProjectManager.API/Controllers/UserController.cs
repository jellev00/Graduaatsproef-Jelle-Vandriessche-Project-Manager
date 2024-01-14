using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Models.Input;
using ProjectManager.API.Models.Output;
using ProjectManager.BL.Managers;
using ProjectManager.BL.Models;

namespace ProjectManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        // GET
        [HttpGet("email/{Email}")]
        public ActionResult<UserOutput> GetUserByEmail(string Email)
        {
            try
            {
                User users = _userManager.GetUserByEmail(Email);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("id/{userId}")]
        public ActionResult<UserOutput> GetUserById(int userId)
        {
            try
            {
                User users = _userManager.GetUserById(userId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST
        [HttpPost]
        public ActionResult<UserOutput> AddUser([FromBody] UserInput userInput)
        {
            try
            {
                User user = new User(userInput.First_Name, userInput.Last_Name, userInput.Email, userInput.Password);
                _userManager.AddUser(user);

                User addedUser = _userManager.GetUserByEmail(user.Email);

                UserOutput userOutput = new UserOutput(
                    addedUser.UserId,
                    addedUser.First_Name,
                    addedUser.Last_Name,
                    addedUser.Email,
                    addedUser.Password,
                    addedUser.UserTasks,
                    addedUser.Projects
                );

                return CreatedAtAction(nameof(GetUserById), new { UserId = user.UserId }, userOutput);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{userId}/Task")]
        public ActionResult<UserTasksOutput> AddTaskToUser(int userId, [FromBody] UserTasksInput tasksInput)
        {
            try
            {
                User user = _userManager.GetUserById(userId);

                UserTasks task = new UserTasks(user, tasksInput.TaskName, tasksInput.TaskDescription, tasksInput.Color, tasksInput.Date, false);
                _userManager.AddTaskToUser(userId, task);

                return CreatedAtAction(nameof(GetUserById), new { UserId = userId }, task);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{userId}/Project")]
        public ActionResult<ProjectOutput> AddProjectToUser(int userId, [FromBody] ProjectInput projectInput)
        {
            try
            {
                User user = _userManager.GetUserById(userId);

                Project project = new Project(user, projectInput.Name, projectInput.Description, projectInput.Color);
                _userManager.AddProjectToUser(userId, project);

                return CreatedAtAction(nameof(GetUserById), new { UserId = userId }, project);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("{email}")]
        public ActionResult DeleteUser(string email)
        {
            try
            {
                if (!_userManager.UserExistsEmail(email))
                {
                    return NotFound();
                }
                else
                {
                    _userManager.DeleteUser(email);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Task/{taskId}")]
        public ActionResult DeleteTask(int taskId)
        {
            try
            {
                if (!_userManager.UserTaskExistsId(taskId))
                {
                    return NotFound();
                }
                else
                {
                    _userManager.DeleteTask(taskId);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Project/{projectId}")]
        public ActionResult DeleteProject(int projectId)
        {
            try
            {
                if (!_userManager.ProjectExistsId(projectId))
                {
                    return NotFound();
                }
                else
                {
                    _userManager.DeleteProject(projectId);
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
                _userManager.UpdateTaskStatus(taskId, newStatus);

                return Ok("Task status updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
