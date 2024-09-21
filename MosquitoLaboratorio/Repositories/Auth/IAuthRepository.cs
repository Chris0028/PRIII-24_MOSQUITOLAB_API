using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<User> Authenticate(string username, string password);  
    }
}
