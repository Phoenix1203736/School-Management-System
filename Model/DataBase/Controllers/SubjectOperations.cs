using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using SistemsProyect.Model.Classes;

// ReSharper disable All
namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class SubjectOperations
    {
        public static int? InsertSubject(Subject subject)
        {
            int? result = null;

            const string query = @"
                INSERT INTO subjects
                (id_professor, name, start_date, end_date, active, description)
                VALUES (@IdProfessor, @Name, @StartDate, @EndDate, @Active, @Description);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return null;

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdProfessor", subject.IdTeacher);
                command.Parameters.AddWithValue("@Name", subject.Name);
                command.Parameters.AddWithValue("@StartDate", subject.StartDate ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@EndDate", subject.EndDate ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Active", subject.Active == true ? 1 : 0);
                command.Parameters.AddWithValue("@Description", (object)subject.Description ?? DBNull.Value);

                result = command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error en InsertSubject: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general en InsertSubject: {ex.Message}");
            }

            return result;
        }

        public static List<Subject> SubjectList()
        {
            var list = new List<Subject>();
            const string query = @"
                SELECT id, name, id_professor, start_date, end_date, active, description
                FROM subjects;";

            using var connection = SingletonSafe.CreateConnection();
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Subject
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    IdTeacher = reader.GetInt32(reader.GetOrdinal("id_professor")),
                    StartDate = reader.GetDateTime(reader.GetOrdinal("start_date")),
                    EndDate = reader.GetDateTime(reader.GetOrdinal("end_date")),
                    Active = reader.GetBoolean(reader.GetOrdinal("active")),
                    Description = reader.IsDBNull(reader.GetOrdinal("description"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("description"))
                });
            }

            return list;
        }

        public static List<Subject> ListActiveSubjects(int isActive)
        {
            var list = new List<Subject>();
            const string query = @"
                SELECT
                    s.id,
                    s.name,
                    s.active,
                    p.id AS professor_id,
                    CONCAT(p.first_name, ' ', p.last_name) AS professor_fullname,
                    p.email
                FROM subjects s
                JOIN professor p ON s.id_professor = p.id
                WHERE s.active = @Active;";

            using var connection = SingletonSafe.CreateConnection();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Active", isActive != 0 ? 1 : 0);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var subject = new Subject
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Active = reader.GetBoolean(reader.GetOrdinal("active"))
                };
                var Teacher = new Teacher
                {
                    Id = reader.GetInt32(reader.GetOrdinal("professor_id")),
                    FirstName = reader.GetString(reader.GetOrdinal("professor_fullname")),
                    Email = reader.GetString(reader.GetOrdinal("email"))
                };

                list.Add(subject);
                // opcional: almacenar Teacher en sesión
                HttpContext.Current.Session["teacher"] = Teacher;
            }

            return list;
        }

        public static Subject? GetById(int id)
        {
            const string query = @"
                SELECT id, name, id_professor, start_date, end_date, active, description
                FROM subjects
                WHERE id = @Id;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return null;

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Subject
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        IdTeacher = reader.GetInt32(reader.GetOrdinal("id_professor")),
                        StartDate = reader.GetDateTime(reader.GetOrdinal("start_date")),
                        EndDate = reader.GetDateTime(reader.GetOrdinal("end_date")),
                        Active = reader.GetBoolean(reader.GetOrdinal("active")),
                        Description = reader.IsDBNull(reader.GetOrdinal("description"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("description"))
                    };
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetById: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general en GetById: {ex.Message}");
            }

            return null;
        }

        public static IEnumerable<Subject> GetAll()
        {
            var list = new List<Subject>();
            const string query = @"
                SELECT id, name, id_professor, start_date, end_date, active, description
                FROM subjects;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return list;

                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Subject
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        IdTeacher = reader.GetInt32(reader.GetOrdinal("id_professor")),
                        StartDate = reader.GetDateTime(reader.GetOrdinal("start_date")),
                        EndDate = reader.GetDateTime(reader.GetOrdinal("end_date")),
                        Active = reader.GetBoolean(reader.GetOrdinal("active")),
                        Description = reader.IsDBNull(reader.GetOrdinal("description"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("description"))
                    });
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetAll: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general en GetAll: {ex.Message}");
            }

            return list;
        }

        public static bool AddStudentToSubject(int subjectId, int studentId)
        {
            const string query = @"
                INSERT INTO student_subject (id_subject, id_student)
                VALUES (@SubjectId, @StudentId);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return false;

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubjectId", subjectId);
                command.Parameters.AddWithValue("@StudentId", studentId);

                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error en AddStudentToSubject: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general en AddStudentToSubject: {ex.Message}");
                return false;
            }
        }

        public static List<Subject>? GetSubjectTeacher()
        {
            var subjects = new List<Subject>();
            var user = (User?)HttpContext.Current.Session["user"];
            if (user == null)
                return null;

            const string query = @"
                SELECT
                    s.id,
                    s.name,
                    s.active,
                    p.id AS professor_id,
                    CONCAT(p.first_name, ' ', p.last_name) AS fullname,
                    p.email,
                    CAST(GETDATE() AS date) AS [current_date]
                FROM subjects s
                JOIN professor p ON p.id = s.id_professor
                WHERE CONCAT(p.first_name, ' ', p.last_name) = @FullName
                  AND s.active = 1;";

            using var connection = SingletonSafe.CreateConnection();
            using var command = new SqlCommand(query, connection);
            string fullName = $"{user.FirstName} {user.LastName}".Trim();
            command.Parameters.AddWithValue("@FullName", fullName);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var subject = new Subject
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")).Trim(),
                    Active = reader.GetBoolean(reader.GetOrdinal("active")),
                    Date = reader.GetDateTime(reader.GetOrdinal("current_date"))
                };

                subjects.Add(subject);
                HttpContext.Current.Session["teacher"] = new Teacher
                {
                    Id = reader.GetInt32(reader.GetOrdinal("professor_id")),
                    FirstName = reader.GetString(reader.GetOrdinal("fullname")),
                    Email = reader.GetString(reader.GetOrdinal("email"))
                };
            }

            return subjects;
        }

        public static List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();
            const string query = @"
                SELECT id, name
                FROM subjects
                ORDER BY name;";

            using var connection = SingletonSafe.CreateConnection();
            using var command = new SqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                subjects.Add(new Subject
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name"))
                });
            }

            return subjects;
        }
    }
}