using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace InternLogAndTicketManagement.Models
{
    public class LogAndTicketContext : DbContext
    {
        public LogAndTicketContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Ticket> Tickets { get; set; } 
    }
}
