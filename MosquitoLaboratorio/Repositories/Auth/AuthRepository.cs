using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Auth;
using Npgsql;

namespace MosquitoLaboratorio.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LabMosContext _context;

        public AuthRepository(LabMosContext context) => _context = context;

        public async Task<AuthUserDTO> Authenticate(LoginDTO user)
        {
            try
            {
                var auth = await _context.UfcUserAuth.FromSqlInterpolated($"SELECT * FROM ufcuserauth({user.UserName}, {user.Password})")
                .FirstOrDefaultAsync();
                return auth!;
            }
            catch (PostgresException e)
            {
                return null!;
            }
        }

        public async Task<int> ChangePassword(Entities.User userChangedPasswordDTO)
        {
            _context.Entry(userChangedPasswordDTO).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
