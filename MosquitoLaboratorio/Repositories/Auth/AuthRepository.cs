using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LabMosContext _context;

        public AuthRepository(LabMosContext context) => _context = context;

        public async Task<User> Authenticate(string username, string password)
        {
            var auth = await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));
            return auth!;
        }
    }
}
