using InternUserManagement.Interfaces;
using InternUserManagement.Models.DTO;
using InternUserManagement.Models;
using System.Security.Cryptography;
using System.Text;

namespace InternUserManagement.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<int, User> _userRepo;
        private readonly IRepo<int, Intern> _internRepo;
        private readonly IGeneratePassword _passwordService;
        private readonly IGenerateToken _tokenService;

        public ManageUserService(IRepo<int, User> userRepo,
            IRepo<int, Intern> internRepo,
            IGeneratePassword passwordService,
            IGenerateToken tokenService)
        {
            _userRepo = userRepo;
            _internRepo = internRepo;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }
        public async Task<UserDTO> ChangeStatus(UserDTO user)
        {
            User user1 = new User();
            user1.Id = user.UserId;
            var result = await _userRepo.Update(user1);
            if(result != null)
            {
                UserDTO resultUser = new UserDTO();
                resultUser.UserId = result.Id;
                resultUser.Role = result.Role;
                return resultUser;
            }
            return null;
        }

        public async Task<UserDTO> Login(UserDTO user)
        {
            UserDTO userDTO = null;
            var result =await _userRepo.Get(user.UserId);
            if (result != null)
            {
                var hmac = new HMACSHA512(result.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != result.PasswordHash[i])
                        return null;
                }
                userDTO = new UserDTO();
                userDTO.UserId = result.Id;
                userDTO.Role = result.Role;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
            }
            return userDTO;
        }

        public async Task<UserDTO> Register(InternDTO intern)
        {

            UserDTO user = null;
            var hmac = new HMACSHA512();
            string? generatedPassword = await _passwordService.GeneratePassword(intern);
            intern.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(generatedPassword ?? "1234"));
            intern.User.PasswordKey = hmac.Key;
            intern.User.Role = "Admin";
            intern.User.Status = "Not Approved";
            var userResult = await _userRepo.Add(intern.User);
            var internResult = await _internRepo.Add(intern);
            if (userResult != null && internResult != null)
            {
                user = new UserDTO();
                user.UserId = internResult.Id;
                user.Role = userResult.Role; 
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;

        }
    }
}
