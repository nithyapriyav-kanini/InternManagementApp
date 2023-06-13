using InternLogAndTicketManagement.Interfaces;
using InternLogAndTicketManagement.Models;
using log4net.Repository;
using Microsoft.EntityFrameworkCore;

namespace InternLogAndTicketManagement.Services
{
    public class LogRepo : ILogRepo<Log, int>
    {
        private readonly LogAndTicketContext _context;
        private readonly ILogger<LogRepo> _logger;

        public LogRepo(LogAndTicketContext context,ILogger<LogRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Log> Add(Log item)
        {
            try
            {
                _context.Logs.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Log>> GetAll()
        {
            var logs=await _context.Logs.ToListAsync();
            if (logs.Count > 0)
            {
                return logs;
            }
            return null;
        }

        public async Task<ICollection<Log>> GetByUser(int key)
        {
            var logs= await GetAll();
            List<Log> result = new List<Log>();
            foreach (var log in logs)
            {
                if(log.UserId==key)
                {
                    result.Add(log);
                }
            }
            if(result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public async Task<Log> Update(Log item)
        {
            var log=_context.Logs.SingleOrDefault(l=>l.Id==item.Id);
            if (log != null)
            {
                log.LogOutTime = item.LogOutTime;
                await _context.SaveChangesAsync();
                return log;
            }
            return null;
        }
    }
}
