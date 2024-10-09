using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.Auth;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LabMosContext _context;

        public AuthRepository(LabMosContext context) => _context = context;

        public async Task<AuthUserDTO> Authenticate(UserDTO user)
        {
            var auth = await _context.UfcUserAuth.FromSqlInterpolated($"SELECT * FROM ufcuserauth({user.UserName}, {user.Password})")
                .FirstOrDefaultAsync();
            return auth!;
        }
    }
}
