using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Auth;
using MosquitoLaboratorio.Repositories.Auth;
using Newtonsoft.Json;

namespace MosquitoLaboratorio.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository) => _authRepository = authRepository;

        public async Task<AuthUserDTO> Authenticate(UserDTO dTO)
        {
            var user = await _authRepository.Authenticate(dTO);
            if (user.Role!.Equals("Doctor"))
            {
                var doctor = JsonConvert.DeserializeObject<DoctorAuth>(user.Info);
                user.AditionalInfo = doctor!;
            }
            else if (user.Role.Equals("Employee"))
            {
                var employee = JsonConvert.DeserializeObject<EmployeeAuth>(user.Info);
                user.AditionalInfo = employee!;
            }
            user.Info = null!;
            return user;
        }
    }
}
