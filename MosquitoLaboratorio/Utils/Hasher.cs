using Microsoft.AspNetCore.Identity;

namespace MosquitoLaboratorio.Utils
{
    public class Hasher
    {
        private readonly PasswordHasher<object> _passwordHasher;

        public Hasher() => _passwordHasher = new PasswordHasher<object>();

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null!, password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null!, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
