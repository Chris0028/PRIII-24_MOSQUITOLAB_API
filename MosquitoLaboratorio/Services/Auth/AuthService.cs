using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Auth;
using MosquitoLaboratorio.Repositories.Auth;
using MosquitoLaboratorio.Services.User;
using MosquitoLaboratorio.Utils;
using Newtonsoft.Json;

namespace MosquitoLaboratorio.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserService _userService;

        public AuthService(IAuthRepository authRepository, IUserService userService)
        {
            _authRepository = authRepository;
            _userService = userService;
        }

        public async Task<AuthUserDTO> Authenticate(LoginDTO dTO)
        {
            Hasher hasher = new();
            var user = await _authRepository.Authenticate(dTO);

            if(user != null)
            {
                if (hasher.VerifyPassword(dTO.Password!, user.Password))
                {
                    if (user.Role!.Equals("Doctor"))
                    {
                        var doctor = JsonConvert.DeserializeObject<DoctorAuth>(user.Info);
                        user.AditionalInfo = doctor!;
                    }
                    else if (user.Role.Equals("Employee") || user.Role.Equals("Admin"))
                    {
                        var employee = JsonConvert.DeserializeObject<EmployeeAuth>(user.Info);
                        user.AditionalInfo = employee!;
                    }
                    user.Info = null!;
                    return user;
                }
            }
            return null!;
        }

        public async Task<bool> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            Hasher hasher = new();
            var getUser = await _userService.GetUserByUsername(changePasswordDTO.Username);
            if(getUser != null)
            {
                if (hasher.VerifyPassword(changePasswordDTO.CurrentPassword, getUser.Password))
                {
                    getUser.Password = hasher.HashPassword(changePasswordDTO.NewPassword);
                    var success = await _authRepository.ChangePassword(getUser);
                    if (success > 0)
                        return true;
                    return false;
                }
                return false;
            }
            return false;
        }
    }
}
