using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utility
{
    public static class DbManager
    {
        private static readonly string ConnectionString = "YourConnectionStringHere";
        private static SqlConnection _connection;

        static DbManager()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        public static SqlConnection GetOpenConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }

        public static void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
