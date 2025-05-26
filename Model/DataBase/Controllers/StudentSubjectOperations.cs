using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using SistemsProyect.Model.Classes;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public class StudentSubjectOperations
    {
        public static List<SubjectStudent> GetFinalGradesBySubject(int subjectId)
        {
            var list = new List<SubjectStudent>();
            try
            {
                using (var connection = SingletonSafe.CreateConnection())
                using (var command = new SqlCommand(@"
        SELECT 
            s.id                                           AS student_id,
            CONCAT(s.first_name, ' ', s.last_name)        AS student_name,
            (
                SELECT AVG(a.grade)
                FROM school.dbo.assignments a
                WHERE a.id_subject = ss.id_subject 
                  AND a.id_student = ss.id_student
            )                                             AS AssignmentPercent,
            ROUND(
                (
                    SELECT COUNT(*) 
                    FROM attendances att
                    WHERE att.id_subject   = ss.id_subject 
                      AND att.id_student   = ss.id_student 
                      AND att.attendances = 'Came'
                ) * 1.0 
                / NULLIF(
                    (
                        SELECT COUNT(*) 
                        FROM attendances att_total
                        WHERE att_total.id_subject = ss.id_subject 
                          AND att_total.id_student = ss.id_student
                    ), 0
                ) * 100
            ,1)                                          AS AttendancePercentage,
            ss.Grade                                      AS FinalGrade
        FROM school.dbo.student_subject ss
        INNER JOIN students s 
            ON s.id = ss.id_student
        WHERE ss.id_subject = @SubjectId;
    ", connection))
                {
                    command.Parameters.AddWithValue("@SubjectId", subjectId);

                    using (var reader = command.ExecuteReader())
                    {
                        var idxStudentId = reader.GetOrdinal("student_id");
                        var idxStudentName = reader.GetOrdinal("student_name");
                        var idxAssignPct = reader.GetOrdinal("AssignmentPercent");
                        var idxAttendPct = reader.GetOrdinal("AttendancePercentage");
                        var idxFinalGrade = reader.GetOrdinal("FinalGrade");

                        while (reader.Read())
                        {
                            var student = new SubjectStudent
                            {
                                StudentId = reader.IsDBNull(idxStudentId)
                                    ? null
                                    : (int?)reader.GetInt32(idxStudentId),

                                StudentName = reader.IsDBNull(idxStudentName)
                                    ? null
                                    : reader.GetString(idxStudentName),

                                AssignmentPercent = reader.IsDBNull(idxAssignPct)
                                    ? null
                                    : (decimal?)Convert.ToDecimal(reader.GetValue(idxAssignPct)),

                                AttendancePercentage = reader.IsDBNull(idxAttendPct)
                                    ? null
                                    : (decimal?)Convert.ToDecimal(reader.GetValue(idxAttendPct)),

                                FinalGrade = reader.IsDBNull(idxFinalGrade)
                                    ? null
                                    : (decimal?)Convert.ToDecimal(reader.GetValue(idxFinalGrade))
                            };

                            list.Add(student);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine($"SQL Error in GetFinalGradesBySubject: {e.Message}");
                Debug.WriteLine("-------------------------------");
                Debug.WriteLine("Stack Trace: " + e.StackTrace);
            }
            catch (Exception e)
            {
                Debug.WriteLine("-------------------------------");
                Debug.WriteLine($"SQL Error in GetFinalGradesBySubject: {e.Message}");
                Debug.WriteLine("-------------------------------");
                Debug.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return list;
        }


        public static Boolean UpdateFinalGrade(int subjectId, int studentId, int grade)
        {
            const string query = @"
                UPDATE school.student_subject
                SET Grade = @grade
                WHERE id_subject = @subjectId AND id_student = @studentId;
            ";

            using var conn = SingletonSafe.CreateConnection();
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);
            cmd.Parameters.AddWithValue("@studentId", studentId);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}