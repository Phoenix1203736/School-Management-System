using System;
using System.Diagnostics;
using MySqlConnector;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.DataBase.Controllers
{
    public static class AttendanceOperations
    {
        public static bool UpsertAttendance(Attendance? attendance)
        {
            if (attendance == null)
                return false;

            var dateOnly = attendance.Date?.Date ?? DateTime.Today;

            const string query = @"
    INSERT INTO school.attendances (id_subject, id_student, attendances, date)
    VALUES (@id_subject, @id_student, @status, @date);
";


            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return false;

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_subject", attendance.IdSubject);
                command.Parameters.AddWithValue("@id_student", attendance.IdStudent);
                command.Parameters.AddWithValue("@status",
                    attendance.Attenndace?.ToString() ?? "Absent"); // Valor por defecto si es null
                command.Parameters.AddWithValue("@date", dateOnly);
                return command.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine($"MySQL Error in UpsertAttendance: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General Error in UpsertAttendance: {ex.Message}");
                return false;
            }
        }

        public static Attendance? GetAttendanceByStudentAndDate(int subjectId, int studentId, DateTime date)
        {
            const string query = @"
        SELECT id, id_subject, id_student, attendances, date
        FROM school.attendances
        WHERE id_subject = @id_subject
          AND id_student = @id_student
          AND date = @date
        LIMIT 1;
    ";

            try
            {
                using var connection = SingletonSafe.CreateConnection();
                if (connection == null || connection.State != System.Data.ConnectionState.Open)
                    return null;

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_subject", subjectId);
                command.Parameters.AddWithValue("@id_student", studentId);
                command.Parameters.AddWithValue("@date", date.Date);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Attendance
                    {
                        Id = reader.GetInt32("id"),
                        IdSubject = reader.GetInt32("id_subject"),
                        IdStudent = reader.GetInt32("id_student"),
                        // Aquí convertimos el enum string a enum en C#
                        Attenndace = Enum.TryParse<AttendanceStatus>(reader.GetString("attendances"), out var status)
                            ? status
                            : AttendanceStatus.Absent,
                        Date = reader.GetDateTime("date")
                    };
                }
                else
                {
                    return null; // No existe registro para esa fecha
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en GetAttendanceByStudentAndDate: {ex.Message}");
                return null;
            }
        }
    }
}