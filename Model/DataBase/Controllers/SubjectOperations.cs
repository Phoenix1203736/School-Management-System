using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

            using (MySqlConnection connection = SingletonSafe.CreateConnection())
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
            const string query = @"SELECT id, name FROM school.subjects WHERE active = @active;";

            using (MySqlConnection connection = SingletonSafe.CreateConnection())
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
                                Id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32("id"),
                                Name = reader.IsDBNull(reader.GetOrdinal("name")) ? "" : reader.GetString("name")
                            };

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
                        Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString("description")
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
                        Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString("description")
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

    }
}