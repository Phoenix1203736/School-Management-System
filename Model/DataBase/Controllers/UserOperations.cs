using System;
using System.Web;
using MySqlConnector;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class UserOperations
    {
        private const string Query =
            @"SELECT id, name, email, role, active, `password` FROM users WHERE email = @email AND active = 1 LIMIT 1;";

        /// <summary>
        /// Autentica un usuario. Verifica el hash de la contraseña en código
        /// (nunca compara contraseñas en SQL) y solo admite cuentas activas.
        /// </summary>
        internal static bool GetUser(string email, string password)
        {
            using var connection = ConnectionPooling.CreateConnection();
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
                return false;

            string storedHash;
            User user;

            using (MySqlCommand sqlCommand = new MySqlCommand(Query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.Read())
                        return false;

                    storedHash = reader.IsDBNull(reader.GetOrdinal("password"))
                        ? string.Empty
                        : reader.GetString("password");

                    user = new User
                    {
                        Id = reader.GetInt32("id"),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("name"))
                            ? string.Empty
                            : reader.GetString("name"),
                        Email = reader.IsDBNull(reader.GetOrdinal("email"))
                            ? string.Empty
                            : reader.GetString("email"),
                        Role = Enum.TryParse(
                                   reader.IsDBNull(reader.GetOrdinal("role"))
                                       ? null
                                       : reader.GetString("role"),
                                   out UserRole role)
                            ? role
                            : UserRole.Guest,
                        Active = true
                    };
                }
            }

            if (!PasswordManager.Verify(password, storedHash))
                return false;

            HttpContext.Current.Session["user"] = user;
            return true;
        }

        /// <summary>
        /// Reemplaza la contraseña de un usuario (y de su registro de profesor,
        /// si existe) por un hash nuevo. Devuelve false si el email no existe.
        /// </summary>
        internal static bool ResetPassword(string email, string newPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
                return false;

            var hash = PasswordManager.Hash(newPassword);

            using var connection = ConnectionPooling.CreateConnection();
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
                return false;

            using (var check = new MySqlCommand(@"SELECT COUNT(*) FROM users WHERE email = @email;", connection))
            {
                check.Parameters.AddWithValue("@email", email);
                if (Convert.ToInt32(check.ExecuteScalar()) == 0)
                    return false;
            }

            using (var update = new MySqlCommand(@"UPDATE users SET `password` = @hash WHERE email = @email;", connection))
            {
                update.Parameters.AddWithValue("@hash", hash);
                update.Parameters.AddWithValue("@email", email);
                update.ExecuteNonQuery();
            }

            using (var updateProfessor = new MySqlCommand(
                       @"UPDATE professor SET `password` = @hash WHERE email = @email;", connection))
            {
                updateProfessor.Parameters.AddWithValue("@hash", hash);
                updateProfessor.Parameters.AddWithValue("@email", email);
                updateProfessor.ExecuteNonQuery();
            }

            return true;
        }
    }
}