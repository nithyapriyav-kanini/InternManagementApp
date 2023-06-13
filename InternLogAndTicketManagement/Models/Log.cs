using System.ComponentModel.DataAnnotations;

namespace InternLogAndTicketManagement.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? LogInTime { get; set; }
        public DateTime? LogOutTime { get; set; }
    }
} 
