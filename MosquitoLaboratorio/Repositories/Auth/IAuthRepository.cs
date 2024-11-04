using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Auth;

namespace MosquitoLaboratorio.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<AuthUserDTO> Authenticate(LoginDTO user);
        Task<int> ChangePassword(Entities.User changePasswordDTO);
    }
}