namespace APC.Application.Common.Security.Hashing
{
    public class PasswordHasher
    {
        private const int Iterations = 50000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        //generate a salt
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        //hash a password with salt
        public static byte[] HashPassword(string password, byte[] salt)
        {
            var pbkdf2 = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA512, HashSize);
            return pbkdf2;

        }

        //verify a password against a hashed password and salt
        public static bool VerifyPassword(string password, string salt, string hash)
        {
            byte[] computedHash = HashPassword(password, Convert.FromBase64String(salt));
            return AreHashesEqual(Convert.FromBase64String(hash), computedHash);
        }

        //compare two hash values for equality
        private static bool AreHashesEqual(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length)
            {
                return false;
            }
            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}