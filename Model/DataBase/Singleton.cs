using System;
using System.Diagnostics;
using MySqlConnector;

namespace SistemsProyect.Model.DataBase
{
    public class Singleton
    {
        private MySqlConnection _getInstance;
        private static Singleton? _instance;

        private Singleton()
        {
            _getInstance = new MySqlConnection();
        }

        public static Singleton GetInstance()
        {
            // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
            try
            {
                mySqlConnectionStringBuilder.Server = "localhost";
                mySqlConnectionStringBuilder.UserID = "root";
                mySqlConnectionStringBuilder.Password = "";
                mySqlConnectionStringBuilder.Database = "school";
                mySqlConnectionStringBuilder.Port = 3307;
                _getInstance.ConnectionString = mySqlConnectionStringBuilder.ConnectionString;
                if (_getInstance.State == System.Data.ConnectionState.Closed)
                {
                    _getInstance.Open();
                }
                else
                {
                    return _getInstance;
                }
            }
            catch (MySqlException mye)
            {
                Debug.WriteLine($"Error en Singleton:{mye.Message}  {mye.StackTrace}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error en Singleton:{e.Message}  {e.StackTrace}");
            }

            return _getInstance;
        }

        public void CloseConnection()
        {
            if (_getInstance.State == System.Data.ConnectionState.Open)
            {
                _getInstance.Close();
            }
        }
    }
}