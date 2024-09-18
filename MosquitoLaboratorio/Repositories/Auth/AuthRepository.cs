
using Dapper;
using MosquitoLaboratorio.DbContext;

namespace MosquitoLaboratorio.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DBContext _context;

        public AuthRepository(DBContext context) => _context = context;

        public async Task<Entities.User> Authenticate(string userName, string password)
        {
            using(var connection = _context.GetConnection())
            {
                var query = @"SELECT id, username, password, role FROM user WHERE username = @userName AND password = @password";
                Entities.User? user = await connection.QueryFirstOrDefaultAsync<Entities.User>(query, new { userName = userName, password = password});
                return user!;
            }
        }
    }
}
