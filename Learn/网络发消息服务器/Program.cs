using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 网络发消息服务器
{
    class Program
    {
        static void Main(string[] args)
        {            
            const int Buffersize = 8096;
            Console.WriteLine("服务器启动，等待客户端连接...");
            
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 8500);
            
            listener.Start();
            
            Console.WriteLine("开始监听");

            TcpClient remoteClient = listener.AcceptTcpClient();
            
            Console.WriteLine($"客户端已连接,{remoteClient.Client.LocalEndPoint} -> {remoteClient.Client.RemoteEndPoint}");
            
            NetworkStream stream = remoteClient.GetStream();

            do
            {
                byte[] buffer = new byte[Buffersize];
                int byteRead = stream.Read(buffer, 0, Buffersize);
            
                Console.WriteLine($"获取字节 {byteRead}");

                string msg = Encoding.Unicode.GetString(buffer, 0, byteRead);
                Console.WriteLine($"转换过来的消息是：{msg}");
            } while (true);
        }
    }
}