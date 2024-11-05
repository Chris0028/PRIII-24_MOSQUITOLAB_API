using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Services.User
{
    public interface IUserService
    {
        public Task<int> ChangeStatus(int userIds, short newStatus);
        public Task<Entities.User> GetUser(int id);
        public Task<int> New(NewUserDTO user);
        public string UsernameGenerator(string names, string lastName, string? secondLastName = null);
        public string PasswordGenerator();
        public Task<Tuple<List<UserDTO>, int>> GetAll(int page, int limit);
        public Task<Entities.User> GetUserByUsername(string username);
        public Task<int> ChangeFirstLoginValue(string username);
        public Task<ProfileDTO> GetProfileEmployeeOrAdmin(int id);
        public Task<ProfileDTO> GetProfileDoctor(int id);
        public Task<int> Update(ProfileDTO profile);
    }
}
