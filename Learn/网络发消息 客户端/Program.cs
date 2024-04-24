using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 网络发消息_客户端
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("客户端连接中");
            
            TcpClient client = null;
            
            try
            {
                client = new TcpClient();
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                client.Connect(ip, 8500);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine($"客户端连接{client.Client.LocalEndPoint} -> {client.Client.RemoteEndPoint}");
            
            // string str = "欢迎来到C#程序";
            // NetworkStream ns = client.GetStream();
            //
            // byte[] buffer = Encoding.Unicode.GetBytes(str);
            // ns.Write(buffer, 0, buffer.Length);
            // Console.WriteLine($"发送消息{str}");

            NetworkStream ns = client.GetStream();
            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.S)
                {
                    Console.WriteLine("输入消息:");
                    string msg = Console.ReadLine();
                    byte[] buffer = Encoding.Unicode.GetBytes(msg);
                    ns.Write(buffer, 0 , buffer.Length);
                    Console.WriteLine("发送"+ msg);
                }
            } while (key != ConsoleKey.X);

        }
    }
}