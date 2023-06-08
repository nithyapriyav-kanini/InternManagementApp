using InternUserManagement.Models;

namespace InternUserManagement.Interfaces
{
    public interface IGeneratePassword
    {
        public string? GeneratePassword(Intern intern);
    }
}
