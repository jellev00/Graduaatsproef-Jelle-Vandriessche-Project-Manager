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

        [HttpGet("{Email}")]
        public ActionResult<User> GetUserByEmail(string Email)
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

        [HttpPost]
        public ActionResult<UserDTO> AddUser([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = new User(userDTO.First_Name, userDTO.Last_Name, userDTO.Email, userDTO.Password);
                _userManager.AddUser(user);

                var createdUserDTO = new UserDTO(user.First_Name, user.Last_Name, user.Email, user.Password);

                return CreatedAtAction(nameof(GetUserByEmail), new { Email = user.Email }, createdUserDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Email}")]
        public ActionResult DeleteUser(string Email)
        {
            try
            {
                if (!_userManager.UserExistsEmail(Email))
                {
                    return NotFound();
                }
                else
                {
                    _userManager.DeleteUser(Email);
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
