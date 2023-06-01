using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 聊天室;

namespace 聊天室Server
{
    internal class Client
    {
        private Socket clientSocket;
        Thread t;
        private byte[] data = new byte[1024];
        private byte[] data2 = new byte[1024];
        private string message;
        public static string spiltID;
        public static string spiltID2;
        readonly private LoginRegisterDB LRDB = new LoginRegisterDB();

        public Client(Socket s)
        {
            clientSocket = s;
            t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    int length = clientSocket.Receive(data);
                    message = Encoding.UTF8.GetString(data, 0, length);

                    spiltID = message.Substring(message.IndexOf("~@!#"));
                    spiltID = spiltID.Remove(0, 4);
                    spiltID = spiltID.Remove(spiltID.IndexOf("!#~@"));

                    spiltID2 = message.Substring(message.IndexOf("!#~@"));
                    spiltID2 = spiltID2.Remove(0, 4);

                    message = message.Remove(message.IndexOf("~@!#"));

                    LRDB.InsertChatText(spiltID + spiltID2, message);
                    LRDB.InsertChatText(spiltID2 + spiltID, message);
                    Program.BroadMSG();
                }
                catch(Exception)
                {
                    clientSocket.Close();
                    break;
                }
            }
        }

        public void SendMessage(string idData)
        {
            data2 = Encoding.UTF8.GetBytes(idData);
            clientSocket.Send(data2);
        }

        public bool Connected
        {
            get { return clientSocket.Connected; }
        }
    }
}
