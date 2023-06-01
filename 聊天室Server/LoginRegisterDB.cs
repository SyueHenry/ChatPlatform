using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Security.Principal;
using System.Data.Common;

namespace 聊天室
{
    internal class LoginRegisterDB
    {
        
        
        public string Query { get; set; }
        
        readonly SqlConnection connection = new SqlConnection("Data Source = ; Initial Catalog = 聊天室DB; User ID = sa; Password = ");

        public void InsertChatText(string id, string chatText)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Query = $@"INSERT INTO ['{id}']
                           VALUES('{chatText}')";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
