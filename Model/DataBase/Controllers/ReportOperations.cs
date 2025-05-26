using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using SistemsProyect.Model.Classes.SistemsProyect.Model.Classes;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class ReportOperations
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
                    COALESCE(AVG(CAST(att.attendances AS decimal(5,2))), 0) AS AttendanceAverage,
                    COALESCE(ss.Grade, 0) AS FinalGrade
                FROM subjects s
                JOIN professor p ON p.id = s.id_professor
                JOIN student_subject ss ON ss.id_subject = s.id
                JOIN students stu ON stu.id = ss.id_student
                LEFT JOIN assignments a ON a.id_subject = s.id AND a.id_student = stu.id
                LEFT JOIN attendances att ON att.id_subject = s.id AND att.id_student = stu.id
                WHERE s.id = @SubjectId
                GROUP BY s.id, s.name, p.id, p.first_name, p.last_name, stu.id, stu.first_name, stu.last_name, ss.Grade
                ORDER BY StudentFullName;";

            var list = new List<SubjectReport>();
            try
            {
                using var connection = SingletonSafe.CreateConnection();
                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new SubjectReport
                    {
                        SubjectId = reader.GetInt32(reader.GetOrdinal("SubjectId")),
                        SubjectName = reader.GetString(reader.GetOrdinal("SubjectName")),
                        ProfessorId = reader.GetInt32(reader.GetOrdinal("ProfessorId")),
                        ProfessorFullName = reader.GetString(reader.GetOrdinal("ProfessorFullName")),
                        StudentId = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        StudentFullName = reader.GetString(reader.GetOrdinal("StudentFullName")),
                        AssignmentAverage = reader.GetDecimal(reader.GetOrdinal("AssignmentAverage")),
                        AttendanceAverage = reader.GetDecimal(reader.GetOrdinal("AttendanceAverage")),
                        FinalGrade = reader.GetInt32(reader.GetOrdinal("FinalGrade"))
                    });
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetSubjectReport: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetSubjectReport: {ex.Message}");
            }

            return list;
        }
    }
}