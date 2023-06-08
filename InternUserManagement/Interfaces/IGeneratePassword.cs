using InternUserManagement.Models;

namespace InternUserManagement.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);
    }
}
