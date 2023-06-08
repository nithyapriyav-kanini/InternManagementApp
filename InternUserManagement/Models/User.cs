using System.ComponentModel.DataAnnotations;

namespace InternUserManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
