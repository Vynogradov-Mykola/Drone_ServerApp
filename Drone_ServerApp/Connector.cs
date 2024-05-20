using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Net;
using System.Net.Sockets;
namespace Drone_ServerApp
{
    class Connector
    {
        NpgsqlConnection conn = DataBase.GetDBConnection();
        public TcpListener listener;
        public TcpClient client;
        public string ipAddress = "127.0.0.1"; //Server IP
        public int port = 8080;
        public void connect()
        {
            listener = new TcpListener(IPAddress.Parse(ipAddress), port);
            // TcpListener for input handler
            try
            {
                // Start handler
                listener.Start();
                Console.WriteLine("Server start. Wait for connections...");
                accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }
        public void accept()
        {
            // Client object connect
            client = listener.AcceptTcpClient();
            // Stream from client
            NetworkStream stream = client.GetStream();
            // Buffer for input stream
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            if (dataReceived != "")
            {
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("Client connect.");
                Console.WriteLine("From client: " + dataReceived);
                DataSafe sender = new DataSafe();
                // RequestHandler sender = new RequestHandler();
                Send(sender.Safer(dataReceived));
            }
            else accept();
        }
        public void Send(string sender)
        {
            //function for send stream to client
            NetworkStream stream = client.GetStream();
            byte[] responseBuffer = Encoding.ASCII.GetBytes(sender);
            stream.Write(responseBuffer, 0, responseBuffer.Length);
            Console.WriteLine("Send to client: " + sender);
            accept();

        }

    }
}
