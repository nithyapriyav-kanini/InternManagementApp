using InternLogAndTicketManagement.Interfaces;
using InternLogAndTicketManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InternLogAndTicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class LogController : ControllerBase
    {
        private readonly ILogManageRepo _service;

        public LogController(ILogManageRepo service)
        {
            _service=service;
        }
        [HttpPost("InTime")]
        public async Task<ActionResult<Log>> InAndOut(Log item)
        {
            item.LogInTime= DateTime.Now;
            var result = await _service.InAndOut(item);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Can't register at this moment");
        }
        [HttpPost("OutTime")]
        public async Task<ActionResult<Log>> OutTime(Log item)
        {
            item.LogOutTime = DateTime.Now;
            var result = await _service.OutTime(item);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Can't register at this moment");
        }

        [HttpGet("All")]
        public async Task<ActionResult<ICollection<Log>>> GetAll()
        {
            var result=await _service.GetAll();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("The Log list is empty");
        }
        [HttpGet("ByUser")]
        public async Task<ActionResult<ICollection<Log>>> GetByUser(int key)
        {
            var result = await _service.GetByUser(key);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("The Log list is empty");
        }
    }
}
