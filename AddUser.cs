using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ojetto
{
    class AddUser
    {
        public string Username;
        public string Password;

        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }

        public static void DBUserAdd(string username, string password)
        {
            DataTable Users = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string insertString = $@"insert into dbo.Users(Username, Password) values ('{username}', '{password}')"; //Command


                using (SqlCommand cmd = new SqlCommand(insertString, conn))  // Instantiate the command with a query and connection
                {
                    try
                    {
                        cmd.ExecuteNonQuery();  // Send command
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }


                }
            }

        }


        public AddUser(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
