using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.SqlContext
{
    public class ConnectOptions
    {
        private static IDbConnection _dbConnection = new SqlConnection();

        public static IDbConnection DbConnection
        {
            get
            {
                if (string.IsNullOrEmpty(_dbConnection.ConnectionString))
                {
                    _dbConnection.ConnectionString = ConnectionString;
                }
                return _dbConnection;

            }
        }

        private static string _connectionString {get; set;}
        public static string ConnectionString { get => _connectionString; set =>_connectionString = value }
    }
}
