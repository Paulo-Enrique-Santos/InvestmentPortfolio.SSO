using System.Security.Cryptography;

namespace InvestmentPortfolio.SSO.Application.Security
{
    public class PasswordHasher
    {
        private const int SaltSize = 16; 
        private const int HashSize = 32; 
        private const int Iterations = 10000; 

        public static string HashPassword(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var saltBytes = new byte[SaltSize];
                rng.GetBytes(saltBytes);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256))
                {
                    var hashBytes = pbkdf2.GetBytes(HashSize);

                    var hashWithSaltBytes = new byte[SaltSize + HashSize];
                    Array.Copy(saltBytes, 0, hashWithSaltBytes, 0, SaltSize);
                    Array.Copy(hashBytes, 0, hashWithSaltBytes, SaltSize, HashSize);

                    return Convert.ToBase64String(hashWithSaltBytes);
                }
            }
        }

        public static bool VerifyPassword(string storedHash, string passwordToCheck)
        {
            var hashWithSaltBytes = Convert.FromBase64String(storedHash);

            var saltBytes = new byte[SaltSize];
            Array.Copy(hashWithSaltBytes, 0, saltBytes, 0, SaltSize);

            var storedHashBytes = new byte[HashSize];
            Array.Copy(hashWithSaltBytes, SaltSize, storedHashBytes, 0, HashSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(passwordToCheck, saltBytes, Iterations, HashAlgorithmName.SHA256))
            {
                var hashBytesToCheck = pbkdf2.GetBytes(HashSize);

                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytesToCheck[i] != storedHashBytes[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
