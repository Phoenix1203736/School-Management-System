using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SistemsProyect.Model.DataBase
{
    public static class SingletonSafe
    {
        // Cadena de conexión configurada usando SqlConnectionStringBuilder
        private static string _cadcon;

        public static SqlConnection? CreateConnection()
        {
            // _cadcon = @"Server=PHOENIX-DESKTOP\SQLEXPRESS;Database=school;Trusted_Connection=True;";
            _cadcon=@"workstation id=school_2.mssql.somee.com;packet size=4096;user id=Phoenixcc_SQLLogin_1;pwd=nv6rwejqoo;data source=school_2.mssql.somee.com;persist security info=False;initial catalog=school_2;TrustServerCertificate=True";
            SqlConnection? connection = null;
            try
            {
                connection = new SqlConnection(_cadcon);
                connection.Open(); // Abre la conexión inmediatamente
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error al conectar con SQL Server: {e.Message}");
            }

            return connection;
        }
    }
}