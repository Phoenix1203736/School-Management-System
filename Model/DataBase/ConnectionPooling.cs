using System;
using System.Configuration;
using System.Diagnostics;
using MySqlConnector;

namespace SistemsProyect.Model.DataBase
{
    public static class ConnectionPooling
    {
        // Leer la cadena de conexión desde Web.config; si no está configurada,
        // usa los valores de desarrollo por defecto.
        private static readonly string ConnectionString = ResolveConnectionString();

        private static string ResolveConnectionString()
        {
            var configured = ConfigurationManager.ConnectionStrings["SchoolDb"];
            if (configured != null && !string.IsNullOrWhiteSpace(configured.ConnectionString))
                return configured.ConnectionString;

            return new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "school",
                Port = 3306,
                MinimumPoolSize = 0,
                MaximumPoolSize = 100,
            }.ConnectionString;
        }

        public static MySqlConnection? CreateConnection()
        {
            MySqlConnection? connection = null;
            try
            {
                connection = new MySqlConnection(ConnectionString);
                connection.Open(); // Abre la conexión inmediatamente (puede lanzar excepción si hay error)
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                connection?.Dispose();
                connection = null;
            }
            return connection;
        }
    }
}