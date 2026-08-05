using System;
using System.Security.Cryptography;

namespace SistemsProyect.Model.Classes
{
    /// <summary>
    /// Genera y verifica contraseñas usando PBKDF2 (Rfc2898DeriveBytes) con salt
    /// aleatorio por usuario. Compatible solo con .NET Framework (no usa
    /// CryptographicOperations, que no existe en esta plataforma).
    /// </summary>
    public static class PasswordManager
    {
        private const int DefaultIterations = 100000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static string Hash(string? password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("La contraseña no puede ser vacía.", nameof(password));

            var salt = new byte[SaltSize];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash;
            using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(
                       password, salt, DefaultIterations, System.Security.Cryptography.HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            return $"PBKDF2${DefaultIterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        }

        public static bool Verify(string? password, string? storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
                return false;

            var parts = storedHash!.Split('$');
            if (parts.Length != 4 || !string.Equals(parts[0], "PBKDF2", StringComparison.Ordinal))
                return false;

            if (!int.TryParse(parts[1], out var iterations))
                return false;

            byte[] salt;
            byte[] expected;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expected = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] actual;
            using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(
                       password, salt, iterations, System.Security.Cryptography.HashAlgorithmName.SHA256))
            {
                actual = pbkdf2.GetBytes(expected.Length);
            }

            return FixedTimeEquals(actual, expected);
        }

        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            if (left.Length != right.Length)
                return false;

            int diff = 0;
            for (var i = 0; i < left.Length; i++)
            {
                diff |= left[i] ^ right[i];
            }

            return diff == 0;
        }
    }
}