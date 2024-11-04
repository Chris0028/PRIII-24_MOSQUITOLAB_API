using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Repositories.User;
using MosquitoLaboratorio.Utils;
using System.Text;

namespace MosquitoLaboratorio.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<int> Delete(int userId)
        {
            var user = await GetUser(userId);
            if(user is not null)
            {
                user.Status = 0;
                return await _userRepository.Delete(user);
            }
            return 0;
        }

        public async Task<Entities.User> GetUser(int id)
        {
            return await _userRepository.FindById(id);
        }

        public async Task<int> New(NewUserDTO user)
        {
            Hasher hasher = new();
            user.Username = UsernameGenerator(user.Name, user.LastName, user.SecondLastName);
            string password = PasswordGenerator();
            user.Password = hasher.HashPassword(password);
            user.FkUserId = await _userRepository.GetLastId() + 1;
            int success = await _userRepository.Create(user);
            if(success > 0)
            {
                CustomSMTPClient sMTPClient = new();
                sMTPClient.SendEmail("eliasgonzalesec@gmail.com",
                    user.Email,
                    $"Bienvenid@, tus credenciales son:\n Nombre de usuario: {user.Username}\n Contraseña: {password} ");
                return success;
            }
            return 0;
        }

        public string PasswordGenerator()
        {
            Random random = new Random();
            char[] characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%&*?()".ToCharArray();
            int length = random.Next(8, 13);
            StringBuilder password = new StringBuilder(length);

            for (int i = 0; i < length; i++)
                password.Append(characters[random.Next(characters.Length)]);

            return password.ToString();
        }

        public string UsernameGenerator(string names, string lastName, string? secondLastName = null)
        {
            Random Random = new Random();
            string initials = names.Substring(0, 1);

            if (string.IsNullOrEmpty(secondLastName))
                initials += lastName.Substring(0, 2);
            else
            {
                initials += lastName.Substring(0, 1);
                initials += secondLastName.Substring(0, 1);
            }
            int randomNumber = Random.Next(10000, 100000);
            return $"{initials}{randomNumber}";
        }

        public async Task<Tuple<List<UserDTO>, int>> GetAll(int page, int limit)
        {
            int offset = (page - 1) * limit;
            var users = await _userRepository.GetAll(offset, limit);
            int totalCount = await _userRepository.CountAll();
            return new Tuple<List<UserDTO>, int>(users, totalCount);    
        }

        public async Task<Entities.User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<int> ChangeFirstLoginValue(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            user.FirstLogin = 1;
            return await _userRepository.ChangeFirstLoginValue(user);
        }

        public async Task<ProfileDTO> GetProfileEmployeeOrAdmin(int id)
        {
            var profile = await _userRepository.GetProfileEmployeeOrAdmin(id);
            return profile;
        }

        public async Task<ProfileDTO> GetProfileDoctor(int id)
        {
            var profile = await _userRepository.GetProfileDoctor(id);
            return profile;
        }

        public async Task<int> Update(ProfileDTO profile)
        {
            var user = await _userRepository.FindById(profile.UserId!.Value);
            dynamic type = null!;
            if (user != null)
            {
                if(user.Role == "Doctor")
                    type = await _userRepository.GetDoctorByUserId(user.Id);
                else
                    type = await _userRepository.GetEmployeeByUserId(user.Id);
                return await _userRepository.Update(user, type, profile);
            }
            return 0;
        }
    }
}
