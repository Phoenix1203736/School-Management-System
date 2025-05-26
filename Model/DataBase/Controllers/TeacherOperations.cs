using System;

using System.Collections.Generic;
using System.Diagnostics;
using MySqlConnector;
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
            _query = @"INSERT INTO school.professor 
                    (`first_name`, `last_name`, `email`, `password`, `phone`, `hire_date`, `specialization`, `status`) 
                    VALUES (@FirstName, @LastName, @Email, @password, @phone, @hireDate, @specialization, @status);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();

                using MySqlCommand command = new MySqlCommand(_query, connection);
                command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                command.Parameters.AddWithValue("@LastName", teacher.LastName);
                command.Parameters.AddWithValue("@Email", teacher.Email);
                command.Parameters.AddWithValue("@password", teacher.Password);
                command.Parameters.AddWithValue("@phone", teacher.Phone);
                command.Parameters.AddWithValue("@hireDate", teacher.HireDate);
                command.Parameters.AddWithValue("@specialization", teacher.Specialization);
                command.Parameters.AddWithValue("@status", teacher.Status);

                result = command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message + " en método AddTeacherToProfessor");
            }

            return result;
        }

        public static int? AddTeacherToUsers(Teacher teacher)
        {
            var user = new User();
            int? result = null;
            short? active;
            _query = @"INSERT INTO school.users (`name`, `email`, `password`, `phone`, `role`, `active`) 
                       VALUES (@name, @email, @password, @phone, @role, @active);";

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

            try
            {
                using var connection = SingletonSafe.CreateConnection();

                using MySqlCommand command = new MySqlCommand(_query, connection);
                command.Parameters.AddWithValue("@name", teacher.FirstName+" "+teacher.LastName);
                command.Parameters.AddWithValue("@email", teacher.Email);
                command.Parameters.AddWithValue("@password", teacher.Password);
                command.Parameters.AddWithValue("@phone", teacher.Phone);
                command.Parameters.AddWithValue("@role", user.Role.ToString());
                command.Parameters.AddWithValue("@active", active);

                result = command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message + " en método AddTeacherToUsers");
            }

            return result;
        }

        public static Teacher? GetProfessorByEmail(string email)
        {
            Teacher? professor = null;
            string query = @"SELECT id, first_name, last_name, email, phone, hire_date, specialization, status 
                             FROM school.professor WHERE email = @email LIMIT 1;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    professor = new Teacher
                    {
                        Id = reader.GetInt32("id"),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name"))
                            ? ""
                            : reader.GetString("first_name"),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name")) ? "" : reader.GetString("last_name"),
                        Email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                        Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? "" : reader.GetString("phone"),
                        HireDate = reader.IsDBNull(reader.GetOrdinal("hire_date"))
                            ? DateTime.Now
                            : reader.GetDateTime("hire_date"),
                        Specialization = reader.IsDBNull(reader.GetOrdinal("specialization"))
                            ? ""
                            : reader.GetString("specialization"),
                        Status = reader.IsDBNull(reader.GetOrdinal("status")) ? "" : reader.GetString("status")
                    };
                }
            }
            catch (MySqlException e)
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

                string checkQuery = "SELECT COUNT(*) FROM school.users WHERE email = @oldEmail";
                using var checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@oldEmail", oldEmail.Trim());
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count == 0)
                {
                    Debug.WriteLine($"No existe el email antiguo en la base de datos: {oldEmail}");
                    return null;
                }

                short active = teacher.Status == nameof(TeacherStatus.Active) ? (short)1 : (short)0;

                string updateQuery = @"
                    UPDATE school.users 
                    SET `name` = @name, 
                        `password` = @password, 
                        `phone` = @phone, 
                        `role` = @role, 
                        `active` = @active 
                    WHERE email = @oldEmail;";

                using var updateCmd = new MySqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@name", teacher.FirstName);
                updateCmd.Parameters.AddWithValue("@password", teacher.Password);
                updateCmd.Parameters.AddWithValue("@phone", teacher.Phone);
                updateCmd.Parameters.AddWithValue("@role", teacher.Status == nameof(TeacherStatus.Active)
                    ? UserRole.Standard.ToString()
                    : UserRole.Guest.ToString());
                updateCmd.Parameters.AddWithValue("@active", active);
                updateCmd.Parameters.AddWithValue("@oldEmail", oldEmail.Trim());

                result = updateCmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
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

            string query = @"
                UPDATE school.professor 
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

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
                command.Parameters.AddWithValue("@LastName", teacher.LastName);
                command.Parameters.AddWithValue("@Phone", teacher.Phone);
                command.Parameters.AddWithValue("@HireDate", teacher.HireDate);
                command.Parameters.AddWithValue("@Specialization", teacher.Specialization);
                command.Parameters.AddWithValue("@Status", teacher.Status);
                command.Parameters.AddWithValue("@Email", teacher.Email);

                result = command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message + " en método UpdateTeacher");
            }

            return result;
        }

        public static Teacher? GetProfessorByPhone(string phone)
        {
            Teacher? professor = null;
            string query = @"SELECT id, first_name, last_name, email, phone, hire_date, specialization, status
                             FROM school.professor WHERE phone = @phone LIMIT 1;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@phone", phone);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    professor = new Teacher
                    {
                        Id = reader.GetInt32("id"),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name"))
                            ? ""
                            : reader.GetString("first_name"),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name")) ? "" : reader.GetString("last_name"),
                        Email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email"),
                        Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? "" : reader.GetString("phone"),
                        HireDate = reader.IsDBNull(reader.GetOrdinal("hire_date"))
                            ? DateTime.Now
                            : reader.GetDateTime("hire_date"),
                        Specialization = reader.IsDBNull(reader.GetOrdinal("specialization"))
                            ? ""
                            : reader.GetString("specialization"),
                        Status = reader.IsDBNull(reader.GetOrdinal("status")) ? "" : reader.GetString("status")
                    };
                }
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message + " en método GetProfessorByPhone");
            }

            return professor;
        }

        public static List<Teacher> GetActiveProfessors()
        {
            List<Teacher> professors = new List<Teacher>();
            string query = "SELECT id, first_name, last_name FROM school.professor WHERE status = 'active'";

            try
            {
                using var connection = SingletonSafe.CreateConnection();

                using var cmd = new MySqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    professors.Add(new Teacher
                    {
                        Id = reader.GetInt32("id"),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name"))
                            ? ""
                            : reader.GetString("first_name"),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name")) ? "" : reader.GetString("last_name")
                    });
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine("Error en GetActiveProfessors:");
                Debug.WriteLine(ex.Message);
            }

            return professors;
        }

        /*public static int? GetTeacherId(string email)
        {
            int? TeacherId = null;
            int? result = null;
            const string query = @"Select school.professor.id from school.professor where email=@Email";
            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TeacherId = reader.IsDBNull(reader.GetOrdinal("id")) ? (int?)null : reader.GetInt32("id");
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error en GetTeacherId:");
                Debug.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en GetTeacherId:");
                Debug.WriteLine(e.Message);
            }


            return result;
        }*/

        public static IEnumerable<Teacher> GetAll()
        {
            var list = new List<Teacher>();

            const string query = @"
                SELECT id, first_name, last_name, email, phone, hire_date, specialization, status 
                FROM school.professor;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return list;

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var teacher = new Teacher
                    {
                        Id = reader.GetInt32("id"),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("first_name")) ? null : reader.GetString("first_name"),
                        LastName = reader.IsDBNull(reader.GetOrdinal("last_name")) ? null : reader.GetString("last_name"),
                        Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                        Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? null : reader.GetString("phone"),
                        HireDate = reader.GetDateTime("hire_date"),
                        Specialization = reader.IsDBNull(reader.GetOrdinal("specialization")) ? null : reader.GetString("specialization"),
                        Status = reader.IsDBNull(reader.GetOrdinal("status")) ? null : reader.GetString("status"),
                    };

                    list.Add(teacher);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine($"MySQL Error in GetAll (Teacher): {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General Error in GetAll (Teacher): {ex.Message}");
            }

            return list;
        }
        public static int? ChangeStatus(int id, string status)
        {
            string query = @"UPDATE school.professor SET `status`=@status WHERE id=@id;";
            int? result = null;
            try
            {
                using (MySqlConnection connection = SingletonSafe.CreateConnection())
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@id", id);

                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message);
                return 0;
            }

            return result;
        }
    }
}