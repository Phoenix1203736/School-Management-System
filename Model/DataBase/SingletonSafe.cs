using System;
using System.Diagnostics;
using MySqlConnector;

namespace SistemsProyect.Model.DataBase
{
    public static class SingletonSafe
    {
        private static readonly string ConnectionString = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            UserID = "root",
            Password = "",
            Database = "school",
            Port = 3306,
            MinimumPoolSize = 0,
            MaximumPoolSize = 100,
            // Opcional: puedes ajustar el pool si lo necesitas
            // MinimumPoolSize = 0,
            // MaximumPoolSize = 100
        }.ConnectionString;

        public static MySqlConnection? CreateConnection()
        {
            MySqlConnection? connection=null;
            try
            {
                 connection = new MySqlConnection(ConnectionString);
                connection.Open(); // Abre la conexión inmediatamente (puede lanzar excepción si hay error)
              
            }
            catch (Exception e)
            {
Debug.WriteLine(e.Message);
            }
            return connection;
        }
    }
}