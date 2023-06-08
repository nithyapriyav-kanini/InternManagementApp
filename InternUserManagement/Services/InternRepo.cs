using InternUserManagement.Interfaces;
using InternUserManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InternUserManagement.Services
{
    public class InternRepo : IRepo<int, Intern>
    {
        private readonly UserContext _context;
        private readonly ILogger<USerRepo> _logger;

        public InternRepo(UserContext context, ILogger<USerRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Intern?> Add(Intern item)
        {
            try
            {
                _context.Interns.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Intern?> Delete(int key)
        {
            var intern =await Get(key);
            if(intern != null)
            {
                try
                {
                    _context.Interns.Remove(intern);
                    await _context.SaveChangesAsync();
                    return intern;
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return null;
        }
         
        public async Task<Intern?> Get(int key)
        {
            var intern = await Get(key);
            if (intern != null)
            {
                return intern;
            }
            return null;
        }

        public async Task<ICollection<Intern>?> GetAll()
        {
            var interns = await _context.Interns.ToListAsync();
            if(interns.Count>0)
            {
                return interns;
            }
            return null;
        }

        /*public async Task<Intern?> Update(Intern item)
        {
            var intern = await Get(item.Id);
            if (intern != null)
            {
                intern.Name=item.Name;
                intern.DateOfBirth=item.DateOfBirth;
                intern.Age=item.Age;
                intern.Gender=item.Gender;
                intern.Phone=item.Phone;
                intern.Email=item.Email;
                try
                {
                    await _context.SaveChangesAsync();
                    return intern; ;
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return null;
        }*/
    }
}

