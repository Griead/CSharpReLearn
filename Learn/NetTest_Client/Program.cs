using System;
using System.Net.Sockets;

namespace NetTest_Client
{
    class Client
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Client Running...");
            
            // TCp客户端的一个类
            TcpClient client = new TcpClient();

            try
            {
                //与服务器连接
                client.Connect("localhost", 8500);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            // 远程和本地ip和端口
            Console.WriteLine($"Server Connect!{client.Client.LocalEndPoint}->{client.Client.RemoteEndPoint}");
        }
    }
}