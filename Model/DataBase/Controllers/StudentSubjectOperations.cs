using System.Collections.Generic;
using MySqlConnector;
using SistemsProyect.Model.Classes;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public class StudentSubjectOperations
    {
         public static List<SubjectStudent> GetFinalGradesBySubject(int subjectId)
        {
            const string query = @"
                SELECT s.id AS student_id,
                       CONCAT(s.first_name, ' ', s.last_name) AS student_name,
                       (
                           SELECT AVG(a.grade)
                           FROM school.assignments a
                           WHERE a.id_subject = ss.id_subject AND a.id_student = ss.id_student
                       ) AS average_grade,
                       (
                           SELECT COUNT(*) 
                           FROM school.attendances att
                           WHERE att.id_subject = ss.id_subject AND att.id_student = ss.id_student AND att.attendances = 1
                       ) /
                       (
                           SELECT COUNT(*) 
                           FROM school.attendances att_total
                           WHERE att_total.id_subject = ss.id_subject
                       ) * 100 AS attendance_percentage,
                       ss.Grade AS final_grade
                FROM school.student_subject ss
                JOIN school.students s ON s.id = ss.id_student
                WHERE ss.id_subject = @subjectId;
            ";

            var list = new List<SubjectStudent>();
            using var conn = ConnectionPooling.CreateConnection();
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SubjectStudent
                {
                    StudentId = reader.GetInt32("student_id"),
                    StudentName = reader.GetString("student_name"),
                    AssigementPercent  = reader.IsDBNull(reader.GetOrdinal("average_grade")) ? 0 : reader.GetDecimal("average_grade"),
                    AttendancePercentage = reader.IsDBNull(reader.GetOrdinal("attendance_percentage")) ? 0 : reader.GetDecimal("attendance_percentage"),
                    FinalGrade = reader.IsDBNull(reader.GetOrdinal("final_grade")) ? 0 : reader.GetInt32("final_grade")
                });
            }

            return list;
        }

        public static bool UpdateFinalGrade(int subjectId, int studentId, int grade)
        {
            const string query = @"
                UPDATE school.student_subject
                SET Grade = @grade
                WHERE id_subject = @subjectId AND id_student = @studentId;
            ";

            using var conn = ConnectionPooling.CreateConnection();
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);
            cmd.Parameters.AddWithValue("@studentId", studentId);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}