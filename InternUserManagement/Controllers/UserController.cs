using InternUserManagement.Interfaces;
using InternUserManagement.Models;
using InternUserManagement.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InternUserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class UserController : ControllerBase
    {
        IManageUser _manageUser;
        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Register(InternDTO intern)
        {
            var result = await _manageUser.Register(intern);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserDTO user)
        {
            var result = await _manageUser.Login(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("check your credentials");
        }

        [HttpPut("Status")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> ApproveIntern(UserDTO user)
        {
            var result = await _manageUser.ChangeStatus(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("This intern has already approved");
        }

        [HttpPut("Password")]
        [Authorize]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> ChangePassword(UserDTO user)
        {
            var result = await _manageUser.ChangePassword(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Cannot update password");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<Intern>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Intern>>> ShowAllInterns()
        {
            var result = await _manageUser.ShowAllInterns();
            if(result.Count>0)
            {
                return result.ToList();
            }
            return BadRequest("Intern list is empty");
        }
    }
}

