using System;
using System.Data.SqlClient;
using System.Web;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class UserOperations
    {
        private static string? _instruction;

        internal static User? GetUser(string email, string password)
        {
            const string query = @"
        SELECT id, name, email, phone, role, active
        FROM users
        WHERE email = @email AND password = @password";

            using var connection = SingletonSafe.CreateConnection();
            if (connection == null) return null;

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password); // Solo si no estás usando hashing

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var user = new User
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    FirstName = reader["name"] as string,
                    Email = reader["email"] as string,
                    Phone = reader["phone"] as string,
                    Role = Enum.TryParse<UserRole>(reader["role"]?.ToString(), out var role) ? role : UserRole.Guest,
                    Active = reader["active"] is int active && active == 1
                };

                HttpContext.Current.Session["user"] = user;
            }

            return null;
        }
    }
}