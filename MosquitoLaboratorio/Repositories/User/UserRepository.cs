using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly LabMosContext _context;

        public UserRepository(LabMosContext context) => _context = context;

        public async Task<int> ChangeFirstLoginValue(Entities.User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CountAll()
        {
            var count = await _context.UfcGetAllUsers.FromSql($"SELECT userId FROM ufc_get_all_users()").CountAsync();
            return count;
        }

        public async Task<int> Create(NewUserDTO userDTO)
        {
            Entities.User createdUser = new()
            {
                Username = userDTO.Username!,
                Password = userDTO.Password!,
                Role = userDTO.Role
            };
            await _context.Users.AddAsync(createdUser);
            await _context.SaveChangesAsync();
            if (userDTO.Role != "Doctor")
            {
                Employee employee = new()
                {
                    Names = userDTO.Name,
                    LastName = userDTO.LastName,
                    SecondLastName = userDTO.SecondLastName,
                    Phone = userDTO.Phone,
                    Email = userDTO.Email,
                    LaboratoryId = userDTO.WorkplaceId,
                    UserId = userDTO.FkUserId!.Value
                };
                await _context.Employees.AddAsync(employee);
            }
            else
            {
                Doctor doctor = new()
                {
                    Name = userDTO.Name,
                    LastName = userDTO.LastName,
                    SecondLastName = userDTO.SecondLastName,
                    Phone = userDTO.Phone,
                    Email = userDTO.Email,
                    Sedes = userDTO.Sedes,
                    HospitalId = userDTO.WorkplaceId,
                    UserId = userDTO.FkUserId!.Value,
                };
                await _context.Doctors.AddAsync(doctor);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Entities.User user)
        {
            if(user != null)
            {
                _context.Entry(user).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Entities.User> FindById(int id)
        {
            return await _context.Users.FirstAsync(u => u.Id.Equals(id));
        }

        public async Task<List<UserDTO>> GetAll(int offset, int limit)
        { 
            var users = await _context.UfcGetAllUsers.FromSql($"SELECT * FROM ufc_get_all_users() WHERE status < 2 ORDER BY Role OFFSET {offset} LIMIT {limit}")
                .OrderBy(u => u.Role)
                .ToListAsync();
            return users;
        }

        public async Task<int> GetLastId()
        {
            int lastId = await _context.Users.OrderByDescending(u => u.Id).Select(u => u.Id).FirstOrDefaultAsync();
            return lastId;
        }

        public async Task<Entities.User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstAsync(u => u.Username.Equals(username));
        }
    }
}
