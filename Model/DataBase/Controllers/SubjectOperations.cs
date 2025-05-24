using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using MySqlConnector;
using SistemsProyect.Model.Classes;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class SubjectOperations
    {
        public static int? InsertSubject(Subject subject)
        {
            int? result = null;

            const string query = @"
        INSERT INTO school.subjects 
        (id_professor, name, start_date, end_date, active, description) 
        VALUES 
        (@id_professor, @name, @start_date, @end_date, @active, @description);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return null;

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_professor", subject.IdTeacher);
                command.Parameters.AddWithValue("@name", subject.Name);
                command.Parameters.AddWithValue("@start_date", subject.StartDate?.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@end_date", subject.EndDate?.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@active", subject.Active.HasValue && subject.Active.Value ? 1 : 0);
                command.Parameters.AddWithValue("@description", subject.Description);

                result = command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine($"Error MySQL en InsertSubject: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error general en InsertSubject: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// gets the active maters
        /// </summary>
        /// <returns></returns>
        public static List<Subject> SubjectList()
        {
            List<Subject> list = new List<Subject>();
            const string query =
                @"SELECT id, name, id_professor, start_date, end_date, active, description 
          FROM school.subjects ";

            using (MySqlConnection? connection = SingletonSafe.CreateConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Subject subject = new Subject
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                IdTeacher = reader.GetInt32("id_professor"),
                                StartDate = reader.GetDateTime("start_date"),
                                EndDate = reader.GetDateTime("end_date"),
                                Active = reader.GetBoolean("active"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description"))
                                    ? null
                                    : reader.GetString("description")
                            };
                            list.Add(subject);
                        }
                    }
                }
            }

            return list;
        }


        public static List<Subject>? ListActiveSubjects(short active)
        {
            var list = new List<Subject>();

            // Consulta SQL con JOIN y alias para columnas del profesor
            const string query = @"
        SELECT 
            s.id, 
            s.name, 
            s.active,
            p.id AS professor_id,
            CONCAT(p.first_name, ' ', p.last_name) AS professor_fullname,
            p.email
        FROM school.subjects s
        JOIN school.professor p ON s.id_professor = p.id
        WHERE s.active = @active;
    ";

            using (MySqlConnection? connection = SingletonSafe.CreateConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@active", active);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subject = new Subject
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("id"))
                                    ? 0
                                    : reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader.IsDBNull(reader.GetOrdinal("name"))
                                    ? string.Empty
                                    : reader.GetString(reader.GetOrdinal("name")),
                                Active = reader.IsDBNull(reader.GetOrdinal("active"))
                                    ? false
                                    : reader.GetBoolean(reader.GetOrdinal("active")),
                            };

                            var teacher = new Teacher
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("professor_id"))
                                    ? 0
                                    : reader.GetInt32(reader.GetOrdinal("professor_id")),
                                FirstName = reader.IsDBNull(reader.GetOrdinal("professor_fullname"))
                                    ? string.Empty
                                    : reader.GetString(reader.GetOrdinal("professor_fullname")),
                                Email = reader.IsDBNull(reader.GetOrdinal("email"))
                                    ? string.Empty
                                    : reader.GetString(reader.GetOrdinal("email")),
                            };

                            // Supongo que Subject tiene una propiedad para Teacher, ajusta según tu modelo
                            if (teacher != null)
                            {
                                HttpContext.Current.Session["teacher"] =
                                    teacher; // Guardar en sesión si quieres usarlo después
                            }

                            list.Add(subject);
                        }
                    }
                }
            }

            return list;
        }


        public static Subject? GetById(int id)
        {
            const string query = @"
        SELECT id, name, id_professor, start_date, end_date, active, description 
        FROM school.subjects 
        WHERE id = @id;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return null;

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Subject
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        IdTeacher = reader.GetInt32("id_professor"),
                        StartDate = reader.GetDateTime("start_date"),
                        EndDate = reader.GetDateTime("end_date"),
                        Active = reader.GetBoolean("active"),
                        Description = reader.IsDBNull(reader.GetOrdinal("description"))
                            ? null
                            : reader.GetString("description")
                    };
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine($"MySQL Error in GetById: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General Error in GetById: {ex.Message}");
            }

            return null;
        }


        public static IEnumerable<Subject> GetAll()
        {
            var list = new List<Subject>();

            const string query = @"
        SELECT id, name, id_professor, start_date, end_date, active, description 
        FROM school.subjects;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return list;

                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var subject = new Subject
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        IdTeacher = reader.GetInt32("id_professor"),
                        StartDate = reader.GetDateTime("start_date"),
                        EndDate = reader.GetDateTime("end_date"),
                        Active = reader.GetBoolean("active"),
                        Description = reader.IsDBNull(reader.GetOrdinal("description"))
                            ? null
                            : reader.GetString("description")
                    };

                    list.Add(subject);
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine($"MySQL Error in GetAll: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General Error in GetAll: {ex.Message}");
            }

            return list;
        }

        public static bool AddStudentToSubject(int subjectId, int studentId)
        {
            const string query = @"
        INSERT INTO school.student_subject (id_subject, id_student)
        VALUES (@subjectId, @studentId);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return false;

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@subjectId", subjectId);
                command.Parameters.AddWithValue("@studentId", studentId);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en AddStudentToSubject: {ex.Message}");
                return false;
            }
        }


       public static List<Subject>? GetSubjectTeacher()
{
    var subjects = new List<Subject>();

    User? user = (User?)HttpContext.Current.Session["user"];
    if (user == null)
        return null;

    const string query = @"
        SELECT 
            s.id,
            s.name,
            s.active,
            p.id AS professor_id,
            p.first_name,
            p.last_name,
            p.email,
            concat(p.first_name,' ',p.last_name) AS fullname,
            CURRENT_DATE() AS date  -- Aquí obtienes la fecha actual del servidor SQL
        FROM 
            school.subjects s
        JOIN 
            school.professor p ON p.id = s.id_professor
        WHERE 
            concat(p.first_name,' ',p.last_name) = @fullName
            AND s.active = 1;
    ";

    using (MySqlConnection? connection = SingletonSafe.CreateConnection())
    {
        if (connection == null)
            return null;

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            string fullNameParam = (user.FirstName ?? "") + " " + (user.LastName ?? "");
            command.Parameters.AddWithValue("@fullName", fullNameParam.Trim());

            // Debug.WriteLine(fullNameParam);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                int rowsCount = 0;

                while (reader.Read())
                {
                    rowsCount++;

                    var subject = new Subject
                    {
                        Id = reader.IsDBNull(reader.GetOrdinal("id"))
                            ? 0
                            : reader.GetInt32(reader.GetOrdinal("id")),
                        Name = reader.IsDBNull(reader.GetOrdinal("name"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("name")).Trim(),
                        Active = reader.IsDBNull(reader.GetOrdinal("active"))
                            ? false
                            : reader.GetBoolean(reader.GetOrdinal("active")),

                        // Agregamos la fecha aquí:
                        Date = reader.IsDBNull(reader.GetOrdinal("date"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("date"))
                    };

                    var teacher = new Teacher
                    {
                        Id = reader.IsDBNull(reader.GetOrdinal("professor_id"))
                            ? 0
                            : reader.GetInt32(reader.GetOrdinal("professor_id")),
                        FirstName = reader.IsDBNull(reader.GetOrdinal("fullname"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("fullname")).Trim(),
                        Email = reader.IsDBNull(reader.GetOrdinal("email"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("email")).Trim()
                    };

                    HttpContext.Current.Session["teacher"] = teacher;

                    subjects.Add(subject);
                }

                if (rowsCount == 0)
                {
                    // No se encontraron resultados
                }
            }
        }
    }

    return subjects;
}

    }
}