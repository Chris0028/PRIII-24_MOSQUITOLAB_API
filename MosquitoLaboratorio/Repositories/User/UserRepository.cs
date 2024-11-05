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

        public async Task<int> ChangeStatus(Entities.User user)
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

        public async Task<ProfileDTO> GetProfileDoctor(int id)
        {
            var profile = await _context.Users.Join(_context.Doctors, u => u.Id, d => d.UserId,
                (u, d) => new ProfileDTO()
                {
                    Name = d.Name,
                    LastName = d.LastName,
                    SecondLastName = d.LastName ?? null,
                    Phone = d.Phone,
                    Email = d.Email,
                    Sedes = d.Sedes,
                    UserId = u.Id,
                    UserName = u.Username
                }).Where(p => p.UserId.Equals(id)).FirstOrDefaultAsync();
            return profile!;
        }

        public async Task<ProfileDTO> GetProfileEmployeeOrAdmin(int id)
        {
            var profile = await _context.Users.Join(_context.Employees, u => u.Id, e => e.UserId,
                (u, e) => new ProfileDTO()
                {
                    Name = e.Names,
                    LastName = e.LastName,
                    SecondLastName = e.SecondLastName ?? null,
                    Phone = e.Phone,
                    Email = e.Email,
                    UserId = u.Id,
                    UserName = u.Username
                }).Where(p => p.UserId.Equals(id)).FirstOrDefaultAsync();
            return profile!;
        }

        public async Task<Entities.User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstAsync(u => u.Username.Equals(username));
        }

        public async Task<int> Update(Entities.User target, dynamic type, ProfileDTO source)
        {
            target.Username = source.UserName;
            _context.Entry(target).State = EntityState.Modified;
            if(target.Role == "Doctor")
            {
                var doctor = type as Doctor;
                doctor.Name = source.Name;
                doctor.LastName = source.LastName;
                doctor.SecondLastName = source.SecondLastName;
                doctor.Phone = source.Phone;
                doctor.Email = source.Email;
                doctor.Sedes = source.Sedes;
                doctor.LastUpdate = DateTime.Now;
                _context.Entry(doctor).State = EntityState.Modified;
            }
            else
            {
                var employee = type as Employee;
                employee.Names = source.Name;
                employee.LastName = source.LastName;
                employee.SecondLastName = source.SecondLastName;
                employee.Phone = source.Phone;
                employee.Email = source.Email;
                employee.LastUpdate = DateTime.Now;
                _context.Entry(employee).State = EntityState.Modified;
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorByUserId(int userId)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.UserId.Equals(userId))!;
        }

        public async Task<Employee> GetEmployeeByUserId(int userId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.UserId.Equals(userId))!;
        }
    }
}
