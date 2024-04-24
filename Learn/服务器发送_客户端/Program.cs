using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 服务器发送_客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BufferSize = 8096;
            
            Console.WriteLine("Client Beginning......");
            
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(ip, 8500);
            
            Console.WriteLine($"Client Connected......{tcpClient.Client.LocalEndPoint} -> {tcpClient.Client.RemoteEndPoint}");

            var stream = tcpClient.GetStream();

            ConsoleKey key;
            
            // 发送数据
            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.S)
                {
                    Console.WriteLine("请输入:");

                    string msg = Console.ReadLine();
                    
                    byte[] buffer = Encoding.Unicode.GetBytes(msg);

                    try
                    {
                        lock (stream)
                        {
                            stream.Write(buffer, 0, buffer.Length); // 发送到服务器
                        }
                        Console.WriteLine($"发送数据{msg}");


                        int bytesRead;

                        buffer = new byte[BufferSize];
                        lock (stream)
                        {
                            bytesRead = stream.Read(buffer, 0, BufferSize); // 从服务器接收数据
                        }

                        msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"客户端接受到数据:{msg}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            } while (key != ConsoleKey.Q);
            
            stream.Dispose();
            tcpClient.Close();
        }
    }
}