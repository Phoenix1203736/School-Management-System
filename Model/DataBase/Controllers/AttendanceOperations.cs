using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class AttendanceOperations
    {
        public static bool UpsertAttendance(Attendance attendance)
        {
            if (attendance == null)
                return false;

            var dateOnly = attendance.Date?.Date ?? DateTime.Today;

            const string query = @"
                INSERT INTO attendances
                    (id_subject, id_student, attendances, date)
                VALUES
                    (@SubjectId, @StudentId, @Status, @Date);";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return false;

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubjectId", attendance.IdSubject);
                command.Parameters.AddWithValue("@StudentId", attendance.IdStudent);
                command.Parameters.AddWithValue("@Status", attendance.Attenndace.ToString());
                command.Parameters.AddWithValue("@Date", dateOnly);

                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in UpsertAttendance: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in UpsertAttendance: {ex.Message}");
                return false;
            }
        }

        public static Attendance GetAttendanceByStudentAndDate(int subjectId, int studentId, DateTime date)
        {
            const string query = @"
                SELECT TOP 1
                    id,
                    id_subject,
                    id_student,
                    attendances,
                    date
                FROM attendances
                WHERE id_subject = @SubjectId
                  AND id_student = @StudentId
                  AND date = @Date;";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != ConnectionState.Open)
                    return null;

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubjectId", subjectId);
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@Date", date.Date);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                    return new Attendance
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        IdSubject = reader.GetInt32(reader.GetOrdinal("id_subject")),
                        IdStudent = reader.GetInt32(reader.GetOrdinal("id_student")),
                        Attenndace = Enum.TryParse(
                            reader.GetString(reader.GetOrdinal("attendances")),
                            out AttendanceStatus status)
                            ? status
                            : AttendanceStatus.Absent,
                        Date = reader.GetDateTime(reader.GetOrdinal("date"))
                    };

                return null;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL Error in GetAttendanceByStudentAndDate: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetAttendanceByStudentAndDate: {ex.Message}");
                return null;
            }
        }
    }
}