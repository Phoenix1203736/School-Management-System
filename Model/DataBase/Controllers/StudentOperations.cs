using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class StudentOperations
    {
        public static int? AddStudent(Student student)
        {
            int? result = null;
            const string query = @"
                INSERT INTO students
                    (first_name, last_name, birth_day, email, phone, date_entry, status)
                VALUES
                    (@FirstName, @LastName, @BirthDay, @Email, @Phone, @DateEntry, @Status);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@BirthDay", student.BirthDate);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Phone", student.Phone);
                command.Parameters.AddWithValue("@DateEntry", student.DateEntry);
                command.Parameters.AddWithValue("@Status", student.Status.ToString());

                result = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in AddStudent: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in AddStudent: {ex.Message}");
            }

            return result;
        }

        public static int? GetStudentByEmail(string email)
        {
            int? result = null;
            const string query = @"
                SELECT TOP 1 id, first_name, last_name, birth_day, email, phone, date_entry, status
                FROM students
                WHERE email = @Email;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var student = new Student
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
                        BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_day"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("birth_day")),
                        DateEntry = reader.IsDBNull(reader.GetOrdinal("date_entry"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("date_entry")),
                        Status = Enum.TryParse(
                            reader.IsDBNull(reader.GetOrdinal("status"))
                                ? string.Empty
                                : reader.GetString(reader.GetOrdinal("status")), true, out StudentStatus status)
                            ? status
                            : StudentStatus.Inactive
                    };

                    result = student.Id;
                    HttpContext.Current.Session["student"] = student;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetStudentByEmail: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetStudentByEmail: {ex.Message}");
            }

            return result;
        }

        public static int? GetStudentByPhone(string phone)
        {
            int? result = null;
            const string query = @"
                SELECT TOP 1 id, first_name, last_name, birth_day, email, phone, date_entry, status
                FROM students
                WHERE phone = @Phone;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Phone", phone);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var student = new Student
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
                        BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_day"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("birth_day")),
                        DateEntry = reader.IsDBNull(reader.GetOrdinal("date_entry"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("date_entry")),
                        Status = Enum.TryParse(
                            reader.IsDBNull(reader.GetOrdinal("status"))
                                ? string.Empty
                                : reader.GetString(reader.GetOrdinal("status")), true, out StudentStatus status)
                            ? status
                            : StudentStatus.Inactive
                    };

                    result = student.Id;
                    HttpContext.Current.Session["student"] = student;
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetStudentByPhone: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetStudentByPhone: {ex.Message}");
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

                const string checkSql = @"
                    SELECT COUNT(*)
                    FROM students
                    WHERE email = @OldEmail;";
                using (var cmdCheck = new SqlCommand(checkSql, connection))
                {
                    cmdCheck.Parameters.AddWithValue("@OldEmail", oldEmail.Trim());
                    var count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (count == 0)
                    {
                        Debug.WriteLine($"No existe el email antiguo: {oldEmail}");
                        return null;
                    }
                }

                const string updateSql = @"
                    UPDATE students
                    SET first_name = @FirstName,
                        last_name = @LastName,
                        birth_day = @BirthDay,
                        email = @NewEmail,
                        phone = @Phone,
                        date_entry = @DateEntry,
                        status = @Status
                    WHERE email = @OldEmail;";
                using (var cmdUpdate = new SqlCommand(updateSql, connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@FirstName", student.FirstName.Trim());
                    cmdUpdate.Parameters.AddWithValue("@LastName", student.LastName.Trim());
                    cmdUpdate.Parameters.AddWithValue("@BirthDay", student.BirthDate);
                    cmdUpdate.Parameters.AddWithValue("@NewEmail", student.Email.Trim());
                    cmdUpdate.Parameters.AddWithValue("@Phone", student.Phone.Trim());
                    cmdUpdate.Parameters.AddWithValue("@DateEntry", student.DateEntry);
                    cmdUpdate.Parameters.AddWithValue("@Status", student.Status.ToString());
                    cmdUpdate.Parameters.AddWithValue("@OldEmail", oldEmail.Trim());

                    result = cmdUpdate.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in UpdateStudent: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in UpdateStudent: {ex.Message}");
            }

            return result;
        }

        public static IEnumerable<Student> GetStudentsBySubject(int subjectId)
        {
            var students = new List<Student>();
            const string query = @"
                SELECT s.id, s.first_name, s.last_name, s.birth_day, s.email, s.phone, s.date_entry, s.status
                FROM students s
                INNER JOIN student_subject ss ON s.id = ss.id_student
                WHERE ss.id_subject = @SubjectId
                ORDER BY s.last_name, s.first_name;";
            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubjectId", subjectId);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                    students.Add(new Student
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
                        BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_day"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("birth_day")),
                        DateEntry = reader.IsDBNull(reader.GetOrdinal("date_entry"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("date_entry")),
                        Status = Enum.TryParse(
                            reader.IsDBNull(reader.GetOrdinal("status"))
                                ? string.Empty
                                : reader.GetString(reader.GetOrdinal("status")), true, out StudentStatus status)
                            ? status
                            : StudentStatus.Inactive
                    });
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetStudentsBySubject: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetStudentsBySubject: {ex.Message}");
            }

            return students;
        }

        public static int? ChangeStatus(int id, string status)
        {
            int? result = null;
            const string query = @"
                UPDATE students
                SET status = @Status
                WHERE id = @Id;";
            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@Id", id);

                result = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in ChangeStatus: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ChangeStatus: {ex.Message}");
            }

            return result;
        }
    }
}