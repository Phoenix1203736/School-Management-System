using System.Collections.Generic;
using System.Web;
using MySqlConnector;
using SistemsProyect.Model.Classes;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public class AssigmentOperations
    {
        public static bool InsertAssignment(int subjectId, int? studentId, string description)
        {
            const string query = @"
            INSERT INTO school.assignments (id_subject, id_student, description)
            VALUES (@id_subject, @id_student, @description);";

            try
            {
                using var connection = ConnectionPooling.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return false;

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_subject", subjectId);
                command.Parameters.AddWithValue("@id_student", studentId);
                command.Parameters.AddWithValue("@description", description);
                return command.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;
            }
        }
        public static List<Assignament> GetAssignmentsByProfessor()
        {
            User? user = (User?)HttpContext.Current.Session["user"];
            if (user == null) return new List<Assignament>();

            const string query = @"
        SELECT 
            MIN(a.id) AS id, 
            a.description
        FROM 
            school.assignments a
        JOIN 
            school.subjects s ON s.id = a.id_subject
        JOIN 
            school.professor p ON p.id = s.id_professor
        WHERE 
            CONCAT(p.first_name, ' ', p.last_name) = @fullName
        GROUP BY 
            a.description, a.id_subject;
    ";

            var list = new List<Assignament>();
            using var conn = ConnectionPooling.CreateConnection();
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fullName", $"{user.FirstName} {user.LastName}".Trim());

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Assignament
                {
                    Id = reader.GetInt32("id"),
                    Description = reader.GetString("description")
                });
            }

            return list;
        }

        public class StudentGradeInfo
        {
            public int? AssignmentId { get; set; }
            public string StudentName { get; set; } = "";
            public int? Grade { get; set; }
        }

        public static List<StudentGradeInfo> GetStudentsForAssignment(int assignmentId)
        {
            const string query = @"
        SELECT  
            a.id AS assignment_id,
            CONCAT(s.first_name, ' ', s.last_name) AS student_name,
            a.grade
        FROM school.assignments a
        JOIN school.students s ON s.id = a.id_student
        WHERE a.id_subject = (SELECT id_subject FROM school.assignments WHERE id = @assignmentId)
          AND description = (SELECT description FROM school.assignments WHERE id = @assignmentId);
    ";

            var list = new List<StudentGradeInfo>();
            using var conn = ConnectionPooling.CreateConnection();
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@assignmentId", assignmentId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new StudentGradeInfo
                {
                    AssignmentId = reader.GetInt32("assignment_id"),
                    StudentName = reader.GetString("student_name"),
                    Grade = reader.IsDBNull(reader.GetOrdinal("grade")) ? 0 : reader.GetInt32("grade")
                });
            }

            return list;
        }

        
        public static bool UpdateGrade(int assignmentId, int grade)
        {
            const string query = @"
        UPDATE school.assignments
        SET grade = @grade
        WHERE id = @id;
    ";

            using var conn = ConnectionPooling.CreateConnection();
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@id", assignmentId);

            return cmd.ExecuteNonQuery() > 0;
        }


    }
}