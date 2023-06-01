using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Documents;
using System.Security.Principal;
using System.Data.Common;
using System.IO.Packaging;

namespace 聊天室
{
    internal class LoginRegisterDB
    {
        public int Count { get; set; }
        public string Str { get; set; }
        public string Query { get; set; }
        public bool IsChinese { get; set; }
        readonly SqlConnection connection = new SqlConnection("Data Source = ; Initial Catalog = 聊天室DB; User ID = sa; Password = ");
        public bool CompareLogin(string iap, string iap2, string column, string column2)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Query = $@"SELECT {column} FROM IAP WHERE {column} IN ('{iap}')";
                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (iap == reader[column].ToString())
                    {
                        reader.Close();
                        Query = $@"SELECT {column2} FROM IAP WHERE {column} IN ('{iap2}')";
                        cmd = new SqlCommand(Query, connection);
                        reader = cmd.ExecuteReader();

                        if (reader.Read())
                            Count = 1;
                        else
                            Count = 0;
                    }
                    else
                        Count = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return Count == 1;
        }

        public bool CompareIAP(string iap, string column, string table)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                for (int i = 0; i < table.Length; i++)
                {
                    if ((int)table[i] >= 65 && (int)table[i] <= 90)
                        IsChinese = false;
                    else
                    {
                        IsChinese = true;
                        break;
                    }

                }

                if (IsChinese)
                    Query = $@"SELECT {column} FROM ['{table}']";
                else
                    Query = $@"SELECT {column} FROM {table}";

                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (iap == reader[column].ToString())
                    {
                        Count = 1;
                        break;
                    }
                    else
                        Count = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return Count == 1;
        }

        public int InsertData(string id, string account, string password)
        {
            if (!CompareIAP(id, "ID", "IAP") && !CompareIAP(account, "Account", "IAP"))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    Query = $@"INSERT INTO IAP(ID, Account, Password)
                                      VALUES('{id}', '{account}', HASHBYTES('SHA2_512', N'{password}'))
                                      CREATE TABLE ['{id}']
                                      (
                                        [Friend] [nvarchar](10) NULL,
                                        [Friend_Check] [nvarchar](10) NULL,
                                      )";
                    SqlCommand cmd = new SqlCommand(Query, connection);

                    SqlCommand cmd2 = new SqlCommand($@"INSERT INTO ['{id}'] (Friend, Friend_Check)
                                      VALUES('1a2b3c4d5e', '1a2b3c4d5e')", connection);

                    Count = cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else if (CompareIAP(id, "ID", "IAP") && CompareIAP(account, "Account", "IAP"))
                Count = 2;
            else if (CompareIAP(id, "ID", "IAP"))
                Count = 3;
            else
                Count = 4;
            return Count;
        }

        public string FoundIAP(string iap, string iap2, string data)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Query = $@"SELECT {iap} FROM IAP WHERE {iap2} IN ('{data}')";
                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    Str = reader[iap].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return Str;
        }

        public void InsertFriend(string id, string table, string column)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Query = $@"INSERT INTO ['{table}']({column})
                           VALUES('{id}')";
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteFriend(string id, string table, string column)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                for (int i = 0; i < table.Length; i++)
                {
                    if ((int)table[i] >= 65 && (int)table[i] <= 90)
                        IsChinese = false;
                    else
                    {
                        IsChinese = true;
                        break;
                    }
                }

                if(IsChinese)
                    Query = $@"DELETE FROM ['{table}'] WHERE {column} = '{id}'";
                else
                    Query = $@"DELETE FROM {table} WHERE {column} = '{id}'";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<string> SelectFriendCheck(string table, string column)
        {
            List<string> friendCheckList = new List<string>();
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                /*for (int i = 0; i < table.Length; i++)
                {
                    if ((int)table[i] >= 65 && (int)table[i] <= 90)
                        IsChinese = false;
                    else
                    {
                        IsChinese = true;
                        break;
                    }
                }

                if(IsChinese)
                    Query = $@"SELECT {column} FROM ['{table}'] WHERE {column} IS NOT NULL";
                else*/
                Query = $@"SELECT {column} FROM ['{table}'] WHERE {column} IS NOT NULL";

                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    friendCheckList.Add(reader[column].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return friendCheckList;
        }

        public bool FriendStateCheck(string id, string table)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                for (int i = 0; i < table.Length; i++)
                {
                    if ((int)table[i] >= 65 && (int)table[i] <= 90)
                        IsChinese = false;
                    else
                    {
                        IsChinese = true;
                        break;
                    }

                }

                if (IsChinese)
                    Query = $@"SELECT Friend, Friend_Check FROM ['{table}']";
                else
                    Query = $@"SELECT Friend, Friend_Check FROM {table}";

                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (id == reader["Friend"].ToString() || id == reader["Friend_Check"].ToString())
                    {
                        Count = 1;
                        break;
                    }
                    else
                        Count = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return Count == 1;
        }

        public void CreateChatLog(string id)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Query = $@"CREATE TABLE ['{id}']
                        (
                            [log] [nvarchar](MAX) NULL 
                        )";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void SelectChatLog(string id)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Query = $@"SELECT * FROM ['{id}']";
                SqlCommand cmd = new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int i = 0;
                    ClientScreen.ChatRecord[ClientScreen.IndexRecord] += reader[i].ToString() + "\n";
                    i++;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
