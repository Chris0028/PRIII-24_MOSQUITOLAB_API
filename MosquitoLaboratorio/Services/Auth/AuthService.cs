using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Mappers;
using MosquitoLaboratorio.Repositories.Auth;

namespace MosquitoLaboratorio.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository) => _authRepository = authRepository;

        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await _authRepository.Authenticate(username, password);
            if(user is not null)
                return Mapper.ToUserDTO(user);

            return null!;
        }
    }
}
