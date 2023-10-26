using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ojetto
{
    public class GetMessage
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project1;Integrated Security=True";
        public string ConncetionString { get; }
        public List<string> ListOfMessages { get; set; }
        string Message = "";
        int MessageID = 0;

        public List<string> DBMessagesManipulate(string Sender, string Receiver)
        {
            var ListOfMessages = new List<string>();
            var ListOfMessagesString = new List<string>();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * From[dbo].[Messages] where (Sender = @Sender and Receiver = @Receiver) or (Sender = @Receiver and Receiver = @Sender) Order by MessageDateTime", con);
            cmd.Parameters.AddWithValue("@Sender", Sender);
            cmd.Parameters.AddWithValue("@Receiver", Receiver);
            cmd.Parameters.AddWithValue("@Message", Message);
            cmd.Parameters.AddWithValue("@MessageID", MessageID);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string sender = dr["Sender"].ToString();
                string receiver = dr["Receiver"].ToString();
                string Message = dr["Message"].ToString();
                int messageID = (int)dr["MessageID"];//.ToString();


                string MessageDateTime = (dr["MessageDateTime"]).ToString();

                ListOfMessages.Add($"{messageID} - {MessageDateTime} \n {sender}:  '{Message}'\n");

            }
            return ListOfMessages;
        }
        public List<string> DBMessagesPrint(string Sender, string Receiver)
        {
            var ListOfMessages = new List<string>();
            var ListOfMessagesString = new List<string>();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * From[dbo].[Messages] where (Sender = @Sender and Receiver = @Receiver) or (Sender = @Receiver and Receiver = @Sender) Order by MessageDateTime", con);
            cmd.Parameters.AddWithValue("@Sender", Sender);
            cmd.Parameters.AddWithValue("@Receiver", Receiver);
            cmd.Parameters.AddWithValue("@Message", Message);
            cmd.Parameters.AddWithValue("@MessageID", MessageID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string sender = dr["Sender"].ToString();
                string receiver = dr["Receiver"].ToString();
                string Message = dr["Message"].ToString();
                string MessageID = dr["MessageID"].ToString();
                string MessageDateTime = (dr["MessageDateTime"]).ToString();

                ListOfMessages.Add($"{MessageDateTime} \n {sender}:  '{Message}'\n");

            }
            return ListOfMessages;
        }
    }
}
