using System;
using System.Collections.Generic;

namespace SistemsProyect.Model.Classes
{
    /// <summary>
    /// Control de intentos fallidos de inicio de sesión en memoria.
    /// Bloquea la cuenta temporalmente tras varios fallos consecutivos.
    /// </summary>
    public static class LoginAttemptTracker
    {
        private const int MaxFailures = 5;
        private static readonly TimeSpan LockoutDuration = TimeSpan.FromMinutes(15);

        private static readonly Dictionary<string, LoginAttempt> Attempts =
            new Dictionary<string, LoginAttempt>(StringComparer.OrdinalIgnoreCase);

        private static readonly object Sync = new object();

        private sealed class LoginAttempt
        {
            public int Failures;
            public DateTime? LockoutUntil;
        }

        public static bool IsLockedOut(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            lock (Sync)
            {
                if (!Attempts.TryGetValue(email, out var attempt) || attempt.LockoutUntil == null)
                    return false;

                if (DateTime.UtcNow >= attempt.LockoutUntil.Value)
                {
                    Attempts.Remove(email);
                    return false;
                }

                return true;
            }
        }

        public static void RegisterFailure(string email)
        {
            if (string.IsNullOrEmpty(email))
                return;

            lock (Sync)
            {
                if (!Attempts.TryGetValue(email, out var attempt))
                {
                    attempt = new LoginAttempt();
                    Attempts[email] = attempt;
                }

                attempt.Failures++;
                if (attempt.Failures >= MaxFailures)
                {
                    attempt.LockoutUntil = DateTime.UtcNow.Add(LockoutDuration);
                }
            }
        }

        public static void RegisterSuccess(string email)
        {
            if (string.IsNullOrEmpty(email))
                return;

            lock (Sync)
            {
                Attempts.Remove(email);
            }
        }
    }
}