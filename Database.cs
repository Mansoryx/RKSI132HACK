using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ojetto
{
    class Database
    {
        private const string ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = Project1; User Id = Environment/Eco; Password = '';";
        public string ConncetionString { get; }
        public static void dbCall()
        {

            DataTable resultTable = new DataTable();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string sqlStmt = "SELECT (columns) FROM dbo.Users WHERE (condition)";

                using (SqlCommand cmd = new SqlCommand(sqlStmt, con))
                {
                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    dap.Fill(resultTable);
                }
            }
        }
    }
}
