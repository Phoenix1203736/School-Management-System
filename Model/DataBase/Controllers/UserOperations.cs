using System;
using System.Web;
using MySqlConnector;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class UserOperations
    {
        private static string? _instruction;

        internal static void GetUser(string email, string password)
        {
            _instruction = @"SELECT name, email, role, active FROM users WHERE email = @email AND `password` = @password;";
            
            using var connection = ConnectionPooling.CreateConnection();
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
                return;

            using (MySqlCommand sqlCommand = new MySqlCommand(_instruction, connection))
            {
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User();

                        user.FirstName = reader.IsDBNull(reader.GetOrdinal("name"))
                            ? string.Empty
                            : reader.GetString("name");

                        user.Email = reader.IsDBNull(reader.GetOrdinal("email"))
                            ? string.Empty
                            : reader.GetString("email");

                        string roleStr = reader.IsDBNull(reader.GetOrdinal("role"))
                            ? "Guest"
                            : reader.GetString("role");

                        user.Role = Enum.TryParse(roleStr, out UserRole role) ? role : UserRole.Guest;

                        int activeCol = reader.GetOrdinal("active");
                        user.Active = !reader.IsDBNull(activeCol) && reader.GetInt32(activeCol) == 1;

                        HttpContext.Current.Session["user"] = user;
                    }
                }
            }
        }
    }
}
