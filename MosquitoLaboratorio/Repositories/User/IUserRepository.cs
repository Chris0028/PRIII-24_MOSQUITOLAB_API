using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.User
{
    public interface IUserRepository
    {
        public Task<List<UserDTO>> GetAll(int offset, int limit);
        public Task<int> Delete(Entities.User user);
        public Task<Entities.User> FindById(int id);
        public Task<int> GetLastId();
        public Task<int> Create(NewUserDTO userDTO);
        public Task<int> CountAll();
        public Task<Entities.User> GetUserByUsername(string username);
        public Task<int> ChangeFirstLoginValue(Entities.User user);
    }
}
