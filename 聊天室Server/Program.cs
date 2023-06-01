using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace 聊天室Server
{
    internal class Program
    {
        public static List<Client> clientList = new List<Client>();
        public static List<string> idList = new List<string>();

        static void Main(string[] args)
        {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse("1"),1));
            tcpServer.Listen(100);

            while(true)
            {
                Socket clientSocket = tcpServer.Accept();
                Client client = new Client(clientSocket);
                clientList.Add(client);
            }
        }

        public static void BroadMSG()
        {
            var notConnectedList = new List<Client>();

            foreach(var client in clientList)
            {
                if (client.Connected)
                    client.SendMessage(Client.spiltID + "~!@#" + Client.spiltID2);
                else
                    notConnectedList.Add(client);
            }

            foreach(var temp in notConnectedList)
            {
                clientList.Remove(temp);
            }
        }
    }
}