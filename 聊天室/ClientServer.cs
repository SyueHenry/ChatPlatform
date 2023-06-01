using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Web;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Forms;
using System.Threading;

namespace 聊天室
{
    internal class ClientServer
    {
        public string ipAddress = "";
        public int port = 1;

        private static Socket clientSocket;
        private byte[] data = new byte[1024];
        private byte[] data2 = new byte[1024];
        private int length;
        readonly private static LoginRegisterDB LRDB = new LoginRegisterDB();

        public void ConnectToServer()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));
        }
        public void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);
        }

        public void ReceiveMessage() 
        {
            //while (true)
            //{
                length = clientSocket.Receive(data2);
                ClientScreen.isYoursNews = Encoding.UTF8.GetString(data2, 0, length);
                
                //break;
            //}
        }
    }
}
