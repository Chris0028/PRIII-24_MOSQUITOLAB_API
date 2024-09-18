namespace MosquitoLaboratorio.Repositories.Auth
{
    public interface IAuthRepository
    {
        public Task<Entities.User> Authenticate(string userName, string password);
    }
}
