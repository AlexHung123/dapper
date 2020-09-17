using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.SqlContext
{
    public class DapperHelper
    {
        //static IDbConnection _dbConnection = new SqlConnection();

        //public string ConnectionString => ConnectOptions.ConnectionString;

        //public DapperHelper()
        //{
        //    if (string.IsNullOrEmpty(_dbConnection.ConnectionString))
        //    {
        //        _dbConnection.ConnectionString = ConnectionString;
        //    }
            
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="CommandTimeOut"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeOut = null, CommandType? commandType = null)
        {
            ConnectOptions.DbConnection.Open();
            using (transaction = ConnectOptions.DbConnection.BeginTransaction())
            {
                var users = ConnectOptions.DbConnection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeOut, commandType);
                transaction.Commit();
                ConnectOptions.DbConnection.Close();
                return users;
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeOut"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeOut = null, CommandType? commandType = null)
        {
            return ConnectOptions.DbConnection.Query<T>(sql, param, transaction, buffered, commandTimeOut, commandType);
        }

        public int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeOut = null, CommandType? commandType = null)
        {
            return ConnectOptions.DbConnection.Execute(sql, param, transaction, commandTimeOut, commandType);
        }
    }
}
