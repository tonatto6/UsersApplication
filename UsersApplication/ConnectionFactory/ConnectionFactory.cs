using Microsoft.AspNetCore.Connections;
using System.Data.SqlClient;
using System.Net;

namespace UsersApplication.ConnectionFactory
{
    public static class ConnectionFactory 
    {
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Database=UsersApplication;";

        public static SqlConnection GetConnection
        {
            get
            {
                var sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                return sqlConn;
            }
        }
    }
}
