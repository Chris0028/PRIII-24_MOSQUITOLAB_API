using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Services.Auth
{
    public interface IAuthService
    {
        public Task<UserDTO> Authenticate(string username, string password);
    }
}
