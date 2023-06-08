using InternUserManagement.Interfaces;
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
            _manageUser= manageUser;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Register(InternDTO intern)
        {
            var result=await _manageUser.Register(intern);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Login([FromBody]UserDTO user)
        {
            var result = await _manageUser.Login(user);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("check your credentials");
        }

        [HttpPut]
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
    }
}
