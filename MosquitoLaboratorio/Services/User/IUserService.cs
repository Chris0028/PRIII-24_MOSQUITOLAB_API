using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Services.User
{
    public interface IUserService
    {
        public Task<int> Delete(int userIds);
        public Task<Entities.User> GetUser(int id);
        public Task<int> New(NewUserDTO user);
        public string UsernameGenerator(string names, string lastName, string? secondLastName = null);
        public string PasswordGenerator();
        public Task<Tuple<List<UserDTO>, int>> GetAll(int page, int limit);
        public Task<Entities.User> GetUserByUsername(string username);
        public Task<int> ChangeFirstLoginValue(string username);
    }
}
