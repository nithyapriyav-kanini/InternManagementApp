using InternLogAndTicketManagement.Interfaces;
using InternLogAndTicketManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InternLogAndTicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class TicketAndSolutionController : ControllerBase
    {
        private readonly ITicketAndSolutionRepo _service;

        public TicketAndSolutionController(ITicketAndSolutionRepo service)
        {
            _service=service;
        }
        
        [HttpPost("GetOne")]
        [Authorize]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> GetTicket(Ticket ticket) 
        {
            var result = await _service.GetTicket(ticket.Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Ticket not found");
        }

        
        [HttpGet("All")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ICollection<Ticket>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Ticket>>> GetAllTicket()
        {
            var result = await _service.GetAllTicket();
            if (result !=null)
            {
                return Ok(result);
            }
            return BadRequest("Ticket not found");
        }

        [HttpGet("ByUser")]
        [Authorize]
        [ProducesResponseType(typeof(ICollection<Ticket>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Ticket>>> GetByUser(int id)
        {
            var result = await _service.GetTicketByUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Ticket not found");
        }

        [HttpPost("Ticket")]
        [Authorize(Roles ="Intern")]
        [ProducesResponseType(typeof(Ticket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> RaiseTicket(Ticket ticket)
        {
            ticket.IssueDate= DateTime.Now;
            var result = await _service.AddTicket(ticket);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Cannot be added");
        }

        [HttpPost("Solution")]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(typeof(Solution), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> RaiseSolution(Solution solution)
        {
            var result = await _service.AddSolution(solution);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Cannot be added");
        }

        [HttpGet("Solution")]
        [Authorize]
        [ProducesResponseType(typeof(Solution), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Solution>> GetSolution(int key)
        {
            var result = await _service.GetSolution(key);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Solution not found");
        }

        [HttpGet("AllSolution")]
        [Authorize]
        [ProducesResponseType(typeof(ICollection<Solution>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Solution>>> GetAllSolution()
        {
            var result = await _service.GetAllSolution();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Solutions not found");
        }

        [HttpPost("ByTicket")]
        /*[Authorize]*/
        [ProducesResponseType(typeof(ICollection<Solution>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<Solution>>> GetSolutionByTicket(Ticket ticket)
        {
            var result = await _service.GetSolutionByTicket(ticket.Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Solutions not found");
        }

    }
}
