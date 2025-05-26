using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using SistemsProyect.Model.Classes;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class AssignmentOperations
    {
        public static bool InsertAssignment(int subjectId, int? studentId, string description)
        {
            const string query = @"
                INSERT INTO assignments
                    (id_subject, id_student, description)
                VALUES
                    (@SubjectId, @StudentId, @Description);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return false;

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubjectId", subjectId);
                command.Parameters.AddWithValue("@StudentId", studentId ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Description", description);

                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in InsertAssignment: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in InsertAssignment: {ex.Message}");
                return false;
            }
        }

        public static List<Assignament> GetAssignmentsByProfessor()
        {
            var user = (User?)HttpContext.Current.Session["user"];
            if (user == null)
                return new List<Assignament>();

            const string query = @"
                SELECT
                    MIN(a.id) AS id,
                    a.description
                FROM assignments a
                JOIN subjects s ON s.id = a.id_subject
                JOIN professor p ON p.id = s.id_professor
                WHERE CONCAT(p.first_name, ' ', p.last_name) = @FullName
                GROUP BY a.description, a.id_subject;";

            var list = new List<Assignament>();
            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var cmd = new SqlCommand(query, connection);
                var fullName = $"{user.FirstName} {user.LastName}".Trim();
                cmd.Parameters.AddWithValue("@FullName", fullName);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Assignament
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Description = reader.GetString(reader.GetOrdinal("description"))
                    });
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetAssignmentsByProfessor: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetAssignmentsByProfessor: {ex.Message}");
            }

            return list;
        }

        public static List<StudentGradeInfo> GetStudentsForAssignment(int assignmentId)
        {
            const string query = @"
                SELECT
                    a.id AS assignment_id,
                    CONCAT(s.first_name, ' ', s.last_name) AS student_name,
                    a.grade
                FROM assignments a
                JOIN students s ON s.id = a.id_student
                WHERE a.id_subject = (
                    SELECT id_subject FROM assignments WHERE id = @AssignmentId
                )
                  AND description = (
                    SELECT description FROM assignments WHERE id = @AssignmentId
                );";

            var list = new List<StudentGradeInfo>();
            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@AssignmentId", assignmentId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new StudentGradeInfo
                    {
                        AssignmentId = reader.GetInt32(reader.GetOrdinal("assignment_id")),
                        StudentName = reader.GetString(reader.GetOrdinal("student_name")),
                        Grade = reader.IsDBNull(reader.GetOrdinal("grade"))
                            ? (int?)null
                            : reader.GetInt32(reader.GetOrdinal("grade"))
                    });
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetStudentsForAssignment: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetStudentsForAssignment: {ex.Message}");
            }

            return list;
        }

        public static bool UpdateGrade(int assignmentId, int grade)
        {
            const string query = @"
                UPDATE assignments
                SET grade = @Grade
                WHERE id = @Id;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@Id", assignmentId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in UpdateGrade: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in UpdateGrade: {ex.Message}");
                return false;
            }
        }
    }

    public class StudentGradeInfo
    {
        public int? AssignmentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int? Grade { get; set; }
    }
}