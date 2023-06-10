using System.ComponentModel.DataAnnotations;

namespace InternLogAndTicketManagement.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int? InternId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}
