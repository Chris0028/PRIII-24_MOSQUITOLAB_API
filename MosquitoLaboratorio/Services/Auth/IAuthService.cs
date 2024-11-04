using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Auth;

namespace MosquitoLaboratorio.Services.Auth
{
    public interface IAuthService
    {
        public Task<AuthUserDTO> Authenticate(LoginDTO user);
        Task<bool> ChangePassword(ChangePasswordDTO changePasswordDTO);
    }
}
