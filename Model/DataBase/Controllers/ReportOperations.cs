using System.Collections.Generic;
using MySqlConnector;

using SistemsProyect.Model.Classes.SistemsProyect.Model.Classes;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public class ReportOperations
    {
        public static List<SubjectReport> GetSubjectReport(int subjectId)
        {
            const string query = @"
                SELECT 
                    s.id AS SubjectId,
                    s.name AS SubjectName,
                    p.id AS ProfessorId,
                    CONCAT(p.first_name, ' ', p.last_name) AS ProfessorFullName,
                    stu.id AS StudentId,
                    CONCAT(stu.first_name, ' ', stu.last_name) AS StudentFullName,
                    COALESCE(AVG(a.grade), 0) AS AssignmentAverage,
                    COALESCE(AVG(att.attendances), 0) AS AttendanceAverage,
                    COALESCE(ss.Grade, 0) AS FinalGrade
                FROM school.subjects s
                JOIN school.professor p ON p.id = s.id_professor
                JOIN school.student_subject ss ON ss.id_subject = s.id
                JOIN school.students stu ON stu.id = ss.id_student
                LEFT JOIN school.assignments a ON a.id_subject = s.id AND a.id_student = stu.id
                LEFT JOIN school.attendances att ON att.id_subject = s.id AND att.id_student = stu.id
                WHERE s.id = @subjectId
                GROUP BY s.id, s.name, p.id, ProfessorFullName, stu.id, StudentFullName, ss.Grade
                ORDER BY StudentFullName;
            ";

            var list = new List<SubjectReport>();
            using var conn = SingletonSafe.CreateConnection();
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new SubjectReport()
                {
                    SubjectId = reader.GetInt32("SubjectId"),
                    SubjectName = reader.GetString("SubjectName"),
                    ProfessorId = reader.GetInt32("ProfessorId"),
                    ProfessorFullName = reader.GetString("ProfessorFullName"),
                    StudentId = reader.GetInt32("StudentId"),
                    StudentFullName = reader.GetString("StudentFullName"),
                    AssignmentAverage = reader.GetDecimal("AssignmentAverage"),
                    AttendanceAverage = reader.GetDecimal("AttendanceAverage"),
                    FinalGrade = reader.GetInt32("FinalGrade")
                });
            }

            return list;
        }
    }
}