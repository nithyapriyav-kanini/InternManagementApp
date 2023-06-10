using InternLogAndTicketManagement.Interfaces;
using InternLogAndTicketManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InternLogAndTicketManagement.Services
{
    public class TicketRepo : ITicketRepo<Ticket, int>
    {
        private readonly LogAndTicketContext _context;
        private readonly ILogger<TicketRepo> _logger;

        public TicketRepo(LogAndTicketContext context,ILogger<TicketRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Ticket> Add(Ticket item)
        {
            try
            {
                _context.Tickets.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Ticket> Get(int key)
        {
            var result = _context.Tickets.SingleOrDefault(i=>i.Id == key);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<ICollection<Ticket>> GetAll()
        {
            var result = await _context.Tickets.ToListAsync();
            if(result.Count>0)
            {
                return result;
            }
            return null;
        }

        public async Task<ICollection<Ticket>> GetById(int key)
        {
            var tickets = await GetAll();
            List<Ticket> result = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                if (ticket.InternId == key)
                {
                    result.Add(ticket);
                }
            }
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public async Task<Ticket> Remove(int key)
        {
            var result = await Get(key);
            if(result != null)
            {
                try
                {
                    _context.Tickets.Remove(result);
                    await _context.SaveChangesAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return null;
        }

        public async Task<Ticket> Update(Ticket item)
        {
            var result = _context.Tickets.SingleOrDefault(i => i.Id == item.Id);
            if (result != null)
            {
                result.Title = item.Title;
                result.Description = item.Description;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
