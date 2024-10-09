using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Auth;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<AuthUserDTO> Authenticate(UserDTO user);  
    }
}
