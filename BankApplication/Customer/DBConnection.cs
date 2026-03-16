using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BankApplication.Customer
{
    internal class DBConnection
    {
        SqlConnection conn;

        public DBConnection()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString);
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}