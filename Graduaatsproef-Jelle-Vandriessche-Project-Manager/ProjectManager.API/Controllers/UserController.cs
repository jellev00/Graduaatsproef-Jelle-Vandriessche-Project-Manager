using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Models;
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

        [HttpGet("{userName}")]
        public ActionResult<User> GetUserByName(string userName)
        {
            try
            {
                User users = _userManager.GetUserByName(userName);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<UserDTO> AddUser([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = new User(userDTO.Name, userDTO.Email, userDTO.Password);
                _userManager.AddUser(user);

                var createdUserDTO = new UserDTO(user.Name, user.Email, user.Password);

                return CreatedAtAction(nameof(GetUserByName), new { userName = user.Name }, createdUserDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userName}")]
        public ActionResult DeleteUser(string userName)
        {
            try
            {
                if (!_userManager.UserExists(userName))
                {
                    return NotFound();
                }
                else
                {
                    _userManager.DeleteUser(userName);
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
