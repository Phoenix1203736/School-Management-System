using System;
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
                command.Parameters.AddWithValue("@id_professor", subject.ID_Teacher);
                command.Parameters.AddWithValue("@name", subject.Name);
                command.Parameters.AddWithValue("@start_date", subject.startDate);
                command.Parameters.AddWithValue("@end_date", subject.endDate);
                command.Parameters.AddWithValue("@active", subject.Active);
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
    }
}