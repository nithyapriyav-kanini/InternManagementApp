using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternLogAndTicketManagement.Models
{
    public class Solution
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int AdminId { get; set; }
        public string Solutions { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
