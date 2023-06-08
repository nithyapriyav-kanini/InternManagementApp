using InternUserManagement.Models;
using InternUserManagement.Models.DTO;

namespace InternUserManagement.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO> Login(UserDTO user);
        public Task<UserDTO> Register(InternDTO intern);
        public Task<UserDTO> ChangeStatus(UserDTO user);
        public Task<ICollection<Intern>> ShowAllInterns();
        public Task<UserDTO> ChangePassword(UserDTO user);
    }
}