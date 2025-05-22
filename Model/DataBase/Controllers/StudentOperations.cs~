using System;
using System.Diagnostics;
using System.Web;
using MySqlConnector;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class StudentOperations
    {
        private static string? _query;

        public static int? AddStudentToStudents(Student student)
        {
            int? result = null;
            _query =
                @"INSERT INTO school.students 
                  (`first_name`, `last_name`, `birth_day`, `email`, `phone`, `date_entry`, `status`) 
                  VALUES 
                  (@first_Name, @LastName, @birthDay, @email, @phone, @dateEntry, @status);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new MySqlCommand(_query, connection);
                command.Parameters.AddWithValue("@first_Name", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@birthDay", student.BirthDate);
                command.Parameters.AddWithValue("@email", student.Email);
                command.Parameters.AddWithValue("@phone", student.Phone);
                command.Parameters.AddWithValue("@dateEntry", student.DateEntry);
                command.Parameters.AddWithValue("@status", student.Status);
                result = command.ExecuteNonQuery();
            }
            catch (MySqlException mysql)
            {
                Debug.Write($"Error en AddStudentToStudents: {mysql.Message}");
            }

            return result;
        }

        public static int? GetStudentByEmail(string email)
        {
            int? result = null;
            string _query = @"
                SELECT id, first_name, last_name, birth_day, email, phone, date_entry, `status`
                FROM school.students 
                WHERE email = @email 
                LIMIT 1;";

            using var connection = SingletonSafe.CreateConnection();
            using var command = new MySqlCommand(_query, connection);
            command.Parameters.AddWithValue("@email", email);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var student = new Student
                {
                    Id        = reader.GetInt32(reader.GetOrdinal("id")),
                    FirstName = reader.IsDBNull(reader.GetOrdinal("first_name")) ? "" : reader.GetString("first_name"),
                    LastName  = reader.IsDBNull(reader.GetOrdinal("last_name"))  ? "" : reader.GetString("last_name"),
                    Email     = reader.IsDBNull(reader.GetOrdinal("email"))      ? "" : reader.GetString("email"),
                    Phone     = reader.IsDBNull(reader.GetOrdinal("phone"))      ? "" : reader.GetString("phone"),
                    BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_day"))  ? DateTime.Now : reader.GetDateTime("birth_day"),
                    DateEntry = reader.IsDBNull(reader.GetOrdinal("date_entry")) ? DateTime.Now : reader.GetDateTime("date_entry"),
                    Status    = Enum.TryParse(
                                  reader.IsDBNull(reader.GetOrdinal("status")) ? null : reader.GetString("status"),
                                  true,
                                  out StudentStatus status)
                                ? status
                                : StudentStatus.Inactive
                };

                result = reader.IsDBNull(reader.GetOrdinal("id"))
                         ? 0
                         : reader.GetInt32(reader.GetOrdinal("id"));
                HttpContext.Current.Session["student"] = student;
            }

            return result;
        }

        public static int? GetStudentByPhone(string phone)
        {
            int? result = null;
            string _query = @"
                SELECT id, first_name, last_name, birth_day, email, phone, date_entry, `status`
                FROM school.students 
                WHERE phone = @phone 
                LIMIT 1;";

            using var connection = SingletonSafe.CreateConnection();
            using var command = new MySqlCommand(_query, connection);
            command.Parameters.AddWithValue("@phone", phone);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var student = new Student
                {
                    Id        = reader.GetInt32(reader.GetOrdinal("id")),
                    FirstName = reader.IsDBNull(reader.GetOrdinal("first_name")) ? "" : reader.GetString("first_name"),
                    LastName  = reader.IsDBNull(reader.GetOrdinal("last_name"))  ? "" : reader.GetString("last_name"),
                    Email     = reader.IsDBNull(reader.GetOrdinal("email"))      ? "" : reader.GetString("email"),
                    Phone     = reader.IsDBNull(reader.GetOrdinal("phone"))      ? "" : reader.GetString("phone"),
                    BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_day"))  ? DateTime.Now : reader.GetDateTime("birth_day"),
                    DateEntry = reader.IsDBNull(reader.GetOrdinal("date_entry")) ? DateTime.Now : reader.GetDateTime("date_entry"),
                    Status    = Enum.TryParse(
                                  reader.IsDBNull(reader.GetOrdinal("status")) ? null : reader.GetString("status"),
                                  true,
                                  out StudentStatus status)
                                ? status
                                : StudentStatus.Inactive
                };

                result = reader.IsDBNull(reader.GetOrdinal("id"))
                         ? 0
                         : reader.GetInt32(reader.GetOrdinal("id"));
                HttpContext.Current.Session["student"] = student;
            }

            return result;
        }

        public static int? UpdateStudent(Student student, string oldEmail)
        {
            if (student == null || string.IsNullOrWhiteSpace(oldEmail))
            {
                Debug.WriteLine("El objeto student es nulo o el oldEmail está vacío.");
                return null;
            }

            int? result = null;
            try
            {
                using var connection = SingletonSafe.CreateConnection();

                // 1) Verificar existencia
                const string checkSql = @"
                    SELECT COUNT(*) 
                    FROM school.students 
                    WHERE email = @oldEmail;";

                using (var command = new MySqlCommand(checkSql, connection))
                {
                    command.Parameters.AddWithValue("@oldEmail", oldEmail.Trim());
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Debug.WriteLine($"No existe el email antiguo en students: {oldEmail}");
                        return null;
                    }
                }

                // 2) Ejecutar UPDATE
                const string updateSql = @"
                    UPDATE school.students 
                    SET first_name = @firstName,
                        last_name  = @lastName,
                        birth_day  = @birthDay,
                        email      = @newEmail,
                        phone      = @phone,
                        date_entry = @dateEntry,
                        status     = @status
                    WHERE email = @oldEmail;";

                using (var command = new MySqlCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@firstName", student.FirstName?.Trim());
                    command.Parameters.AddWithValue("@lastName",  student.LastName?.Trim());
                    command.Parameters.AddWithValue("@birthDay",  student.BirthDate);
                    command.Parameters.AddWithValue("@newEmail",  student.Email?.Trim());
                    command.Parameters.AddWithValue("@phone",     student.Phone?.Trim());
                    command.Parameters.AddWithValue("@dateEntry", student.DateEntry);
                    command.Parameters.AddWithValue("@status",    (short)student.Status);
                    command.Parameters.AddWithValue("@oldEmail",  oldEmail.Trim());

                    result = command.ExecuteNonQuery();
                }
            }
            catch (MySqlException mex)
            {
                Debug.WriteLine($"MySQL Error en UpdateStudent: {mex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general en UpdateStudent: {ex.Message}");
            }

            return result;
        }
    }
}
