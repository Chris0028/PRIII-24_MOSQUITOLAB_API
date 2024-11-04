using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;

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
        public Task<ProfileDTO> GetProfileEmployeeOrAdmin(int id);
        public Task<ProfileDTO> GetProfileDoctor(int id);
        public Task<int> Update(Entities.User target, dynamic type, ProfileDTO source);
        public Task<Doctor> GetDoctorByUserId(int userId);
        public Task<Employee> GetEmployeeByUserId(int userId);
    }
}
