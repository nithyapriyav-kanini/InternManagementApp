using InternUserManagement.Interfaces;
using InternUserManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InternUserManagement.Services
{
    public class USerRepo : IRepo<int, User>,IFunction<User>
    {
        private readonly UserContext _context;
        private readonly ILogger<USerRepo> _logger;

        public USerRepo(UserContext context, ILogger<USerRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User?> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<User?> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User?> Get(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == key);
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<ICollection<User>?> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            if (users.Count > 0)
                return users;
            return null;
        }

        public async Task<User?> UpdatePassword(User item)
        {
            var user=await Get(item.Id);
            if(user != null)
            {
                user.PasswordHash = item.PasswordHash;
                user.PasswordKey = item.PasswordKey;
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User?> UpdateStatus(User item)
        {
            var user = await Get(item.Id);
            if (user != null)
            {
                /*user.Role = item.Role;
                user.PasswordHash = item.PasswordHash;
                user.PasswordKey = item.PasswordKey;*/
                if (user.Status == "Not Approved")
                {
                    user.Status = "Approved";
                    await _context.SaveChangesAsync();
                    return user;
                }
            }
            return null;
        }
    }
}

