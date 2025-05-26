using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class TeacherOperations
    {
        private static string? _query;

        public static int? AddTeacherToProfessor(Teacher teacher)
        {
            int? result = null;
            // Use SQL Server compatible syntax: remove backticks and schema if default
            _query = @"INSERT INTO professor
                       (first_name, last_name, email, password, phone, hire_date, specialization, status)
                       VALUES (@FirstName, @LastName, @Email, @Password, @Phone, @HireDate, @Specialization, @Status);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(_query, connection);

                command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                command.Parameters.AddWithValue("@LastName", teacher.LastName);
                command.Parameters.AddWithValue("@Email", teacher.Email);
                command.Parameters.AddWithValue("@Password", teacher.Password);
                command.Parameters.AddWithValue("@Phone", teacher.Phone);
                command.Parameters.AddWithValue("@HireDate", teacher.HireDate);
                command.Parameters.AddWithValue("@Specialization", teacher.Specialization);
                command.Parameters.AddWithValue("@Status", teacher.Status);

                result = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message + " en método AddTeacherToProfessor");
            }

            return result;
        }

        public static int? AddTeacherToUsers(Teacher teacher)
        {
            int? result = null;
            // Determine role and active flag
            var user = new User();
            short active;
            if (teacher.Status == nameof(TeacherStatus.Active))
            {
                user.Role = UserRole.Standard;
                active = 1;
            }
            else
            {
                user.Role = UserRole.Guest;
                active = 0;
            }

            _query = @"INSERT INTO users
                       (name, email, password, phone, role, active)
                       VALUES (@Name, @Email, @Password, @Phone, @Role, @Active);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(_query, connection);

                command.Parameters.AddWithValue("@Name", teacher.FirstName + " " + teacher.LastName);
                command.Parameters.AddWithValue("@Email", teacher.Email);
                command.Parameters.AddWithValue("@Password", teacher.Password);
                command.Parameters.AddWithValue("@Phone", teacher.Phone);
                command.Parameters.AddWithValue("@Role", user.Role.ToString());
                command.Parameters.AddWithValue("@Active", active);

                result = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message + " en método AddTeacherToUsers");
            }

            return result;
        }

        public static Teacher? GetProfessorByEmail(string email)
        {
            Teacher? professor = null;
            // Use TOP 1 instead of LIMIT
            var query = @"SELECT TOP 1 id, first_name, last_name, email, phone, hire_date, specialization, status
                             FROM professor
                             WHERE email = @Email;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                    professor = new Teacher
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("first_name")),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("last_name")),
                        Email = reader.IsDBNull(reader.GetOrdinal("email"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("email")),
                        Phone = reader.IsDBNull(reader.GetOrdinal("phone"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("phone")),
                        HireDate = reader.IsDBNull(reader.GetOrdinal("hire_date"))
                            ? DateTime.Now
                            : reader.GetDateTime(reader.GetOrdinal("hire_date")),
                        Specialization = reader.IsDBNull(reader.GetOrdinal("specialization"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("specialization")),
                        Status = reader.IsDBNull(reader.GetOrdinal("status"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("status"))
                    };
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message + " en método GetProfessorByEmail");
            }

            return professor;
        }

        public static int? UpdateTeacherInUsers(Teacher teacher, string oldEmail)
        {
            if (string.IsNullOrWhiteSpace(oldEmail))
            {
                Debug.WriteLine("El email antiguo está vacío o nulo.");
                return null;
            }

            int? result = null;

            try
            {
                using var connection = SingletonSafe.CreateConnection();

                // Check existence
                var checkQuery = "SELECT COUNT(*) FROM users WHERE email = @OldEmail;";
                using var checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@OldEmail", oldEmail.Trim());
                var count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count == 0)
                {
                    Debug.WriteLine($"No existe el email antiguo: {oldEmail}");
                    return null;
                }

                var active = teacher.Status == nameof(TeacherStatus.Active) ? (short)1 : (short)0;

                var updateQuery = @"UPDATE users
                                       SET name = @Name,
                                           password = @Password,
                                           phone = @Phone,
                                           role = @Role,
                                           active = @Active
                                       WHERE email = @OldEmail;";

                using var updateCmd = new SqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@Name", teacher.FirstName + " " + teacher.LastName);
                updateCmd.Parameters.AddWithValue("@Password", teacher.Password);
                updateCmd.Parameters.AddWithValue("@Phone", teacher.Phone);
                updateCmd.Parameters.AddWithValue("@Role",
                    teacher.Status == nameof(TeacherStatus.Active)
                        ? UserRole.Standard.ToString()
                        : UserRole.Guest.ToString());
                updateCmd.Parameters.AddWithValue("@Active", active);
                updateCmd.Parameters.AddWithValue("@OldEmail", oldEmail.Trim());

                result = updateCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine($"Error en UpdateTeacherInUsers: {e.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general en UpdateTeacherInUsers: {ex.Message}");
            }

            return result;
        }

        public static int? UpdateTeacher(Teacher teacher)
        {
            int? result = null;
            var query = @"UPDATE professor
                             SET first_name = @FirstName,
                                 last_name = @LastName,
                                 phone = @Phone,
                                 hire_date = @HireDate,
                                 specialization = @Specialization,
                                 status = @Status
                             WHERE email = @Email;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                command.Parameters.AddWithValue("@LastName", teacher.LastName);
                command.Parameters.AddWithValue("@Phone", teacher.Phone);
                command.Parameters.AddWithValue("@HireDate", teacher.HireDate);
                command.Parameters.AddWithValue("@Specialization", teacher.Specialization);
                command.Parameters.AddWithValue("@Status", teacher.Status);
                command.Parameters.AddWithValue("@Email", teacher.Email);

                result = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message + " en método UpdateTeacher");
            }

            return result;
        }

        public static Teacher? GetProfessorByPhone(string phone)
        {
            Teacher? professor = null;
            var query = @"SELECT TOP 1 id, first_name, last_name, email, phone, hire_date, specialization, status
                             FROM professor
                             WHERE phone = @Phone;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Phone", phone);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                    professor = new Teacher
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("first_name")),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("last_name")),
                        Email = reader.IsDBNull(reader.GetOrdinal("email"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("email")),
                        Phone = reader.IsDBNull(reader.GetOrdinal("phone"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("phone")),
                        HireDate = reader.IsDBNull(reader.GetOrdinal("hire_date"))
                            ? DateTime.Now
                            : reader.GetDateTime(reader.GetOrdinal("hire_date")),
                        Specialization = reader.IsDBNull(reader.GetOrdinal("specialization"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("specialization")),
                        Status = reader.IsDBNull(reader.GetOrdinal("status"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("status"))
                    };
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message + " en método GetProfessorByPhone");
            }

            return professor;
        }

        public static List<Teacher> GetActiveProfessors()
        {
            var professors = new List<Teacher>();
            var query = "SELECT id, first_name, last_name FROM professor WHERE status = 'active';";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var cmd = new SqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    professors.Add(new Teacher
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("first_name")),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("last_name"))
                    });
            }
            catch (SqlException e)
            {
                Debug.WriteLine("Error en GetActiveProfessors: " + e.Message);
            }

            return professors;
        }

        public static IEnumerable<Teacher> GetAll()
        {
            var list = new List<Teacher>();
            var query = @"SELECT id, first_name, last_name, email, phone, hire_date, specialization, status
                             FROM professor;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return list;

                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(new Teacher
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("first_name")),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("last_name")),
                        Email = reader.IsDBNull(reader.GetOrdinal("email"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("email")),
                        Phone = reader.IsDBNull(reader.GetOrdinal("phone"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("phone")),
                        HireDate = reader.GetDateTime(reader.GetOrdinal("hire_date")),
                        Specialization = reader.IsDBNull(reader.GetOrdinal("specialization"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("specialization")),
                        Status = reader.IsDBNull(reader.GetOrdinal("status"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("status"))
                    });
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"Error en GetAll (Teacher): {ex.Message}");
            }

            return list;
        }

        public static int? ChangeStatus(int id, string status)
        {
            int? result = null;
            var query = @"UPDATE professor SET status = @Status WHERE id = @Id;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@Id", id);

                result = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message + " en método ChangeStatus");
                return 0;
            }

            return result;
        }


        public static int? RemoveTeacherUsers(string email)
        {
            int? result = null;

string query = @"DELETE FROM users WHERE email = @Email;";
            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email.Trim());

                result = command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message + " en método RemoveTeacherUsers");
            }

            return result;
        }
        
        
        
        
    }
}