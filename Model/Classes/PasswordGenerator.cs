using System.Security.Cryptography;

namespace SistemsProyect.Model.Classes
{
    public static class PasswordGenerator
    {
        public static string GeneratePassword(int length)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()_-+=[{]};:<>|./?";

            var allChars = lowercase + uppercase + digits + specialChars;
            var randomBytes = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            var password = new char[length];
            for (var i = 0; i < length; i++) password[i] = allChars[randomBytes[i] % allChars.Length];

            return new string(password);
        }
    }
}