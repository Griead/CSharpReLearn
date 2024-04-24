using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace 服务端发送_服务器
{
    class Server
    {
        static void Main(string[] args)
        {
            const int BufferSize = 8096;
            ConsoleKey key;
            
            Console.WriteLine("Server is Running...");
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start();
            
            Console.WriteLine("Start Listening...");

            //获取一个连接, 同步方法 在此处中断
            TcpClient remoteClient = listener.AcceptTcpClient();
            
            //打印连接的客户端
            Console.WriteLine($"Client Connected...{remoteClient.Client.LocalEndPoint}->{remoteClient.Client.RemoteEndPoint}");

            NetworkStream _networkStream = remoteClient.GetStream();

            do
            {
                
                try
                {
                    byte[] buffer = new byte[BufferSize];

                    int _byteLength = _networkStream.Read(buffer, 0, BufferSize);


                    if (_byteLength == 0)
                    {
                        throw new Exception("读取到零字节");
                    }
                
                
                    string _str = Encoding.Unicode.GetString(buffer, 0, _byteLength);
                    Console.WriteLine($"Received: {_str}");

                    _str = _str.ToUpper();
                
                    byte[] _newBuffer = Encoding.Unicode.GetBytes(_str);

                    lock (_networkStream)
                    {
                        _networkStream.Write(_newBuffer, 0, _newBuffer.Length);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            } while (true);
            
            _networkStream.Dispose();
            remoteClient.Close();
            
            Console.WriteLine("Client Disconnected...");
        }
    }
}