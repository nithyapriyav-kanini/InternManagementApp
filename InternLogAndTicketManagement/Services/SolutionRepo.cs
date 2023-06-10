using InternLogAndTicketManagement.Interfaces;
using InternLogAndTicketManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InternLogAndTicketManagement.Services
{
    public class SolutionRepo : ITicketRepo<Solution, int>
    {
        private readonly LogAndTicketContext _context;
        private readonly ILogger<SolutionRepo> _logger;

        public SolutionRepo(LogAndTicketContext context, ILogger<SolutionRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Solution> Add(Solution item)
        {
            try
            {
                _context.Solutions.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Solution> Get(int key)
        {
            var result = await _context.Solutions.FirstOrDefaultAsync(i=>i.Id==key);
            if(result!=null)
            {
                return result;
            }
            return null;
        }

        public async Task<ICollection<Solution>> GetAll()
        {
            var result = await _context.Solutions.ToListAsync();
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public async Task<ICollection<Solution>> GetById(int key)
        {
            var solutions = await GetAll();
            List<Solution> result = new List<Solution>();
            foreach (var solution in solutions)
            {
                if (solution.Id == key)
                {
                    result.Add(solution);
                }
            }
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public async Task<Solution> Remove(int key)
        {
            var result = await Get(key);
            if( result != null )
            {
                try
                {
                    _context.Solutions.Remove(result);
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

        public async Task<Solution> Update(Solution item)
        {
            var result = await Get(item.Id);
            if (result != null)
            {
                result.Solutions=item.Solutions;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
