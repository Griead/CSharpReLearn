using System;
using System.Net;
using System.Net.Sockets;

namespace NetTest_Client2
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Running...");
            TcpClient client;

            for (int i = 0; i <= 2; i++)
            {
                try
                {
                    client = new TcpClient();
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                    // IPAddress ipAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
                    client.Connect(ipAddress, 8500);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                
                Console.WriteLine($"Server Connected{client.Client.LocalEndPoint}->{client.Client.RemoteEndPoint}");
            }
        }
    }
}