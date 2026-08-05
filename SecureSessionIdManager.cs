using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;

namespace SistemsProyect
{
    /// <summary>
    /// Genera identificadores de sesión criptográficamente aleatorios y rechaza
    /// identificadores que no provengan de este generador, mitigando la fijación
    /// de sesión (no se puede elegir la ID de una sesión ajena).
    /// </summary>
    public sealed class SecureSessionIdManager : SessionIDManager
    {
        public override string CreateSessionID(HttpContext context)
        {
            var buffer = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }

            return Convert.ToBase64String(buffer)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace('=', '~');
        }

        public override bool Validate(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 24)
                return false;

            foreach (var c in id)
            {
                if (!(char.IsLetterOrDigit(c) || c == '-' || c == '_' || c == '~'))
                    return false;
            }

            return true;
        }
    }
}