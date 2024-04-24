// #define Test01
#define Test02

using System;
using System.Net;
using System.Net.Sockets;

namespace NetTest_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            #if Test01
            
            Console.WriteLine("***************IP地址******************");
            string strHostName = "";
            
            // 获取本地主机名
            strHostName = Dns.GetHostName();
            Console.WriteLine("本地主机名： " + strHostName);

            //由本地计算机得到的本机Ip地址
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] ips = ipHostEntry.AddressList;
            
            //显示本机的Ip地址
            for (int i = 0; i < ips.Length; i++)
            {
                Console.WriteLine($"IP{ips[i]} {ips[i].AddressFamily}");
            }
            
            Console.WriteLine("本地主机名： " + strHostName);
            
            Console.WriteLine("***************Socket.Bind******************");

            IPAddress ipa = IPAddress.Parse("127.0.0.1"); //本机
            IPEndPoint ipep = new IPEndPoint(ipa, 8080);
            
            //Socket实例
            Socket test_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine($"AddressFamily {test_socket.AddressFamily}");`
            Console.WriteLine($"SocketType {test_socket.SocketType}");
            Console.WriteLine($"ProtocolType {test_socket.ProtocolType}");
            Console.WriteLine($"Blocking {test_socket.Blocking}");
            
            test_socket.Bind(ipep);
            IPEndPoint sock_iep = (IPEndPoint)test_socket.LocalEndPoint;
            Console.WriteLine($"Local EndPoint {sock_iep.Address} {sock_iep.Port}");
            test_socket.Close();
            
            #elif Test02
            Console.WriteLine("Server is running..");
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            IPAddress ip_2 = IPAddress.Parse("127.0.0.1");
            IPAddress ip_3 = Dns.GetHostEntry("localhost").AddressList[0];

            TcpListener listener = new TcpListener(ip, 8500);
            listener.Start();//开始监听是否有建立连接
            
            Console.WriteLine("StartListening.........");

            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);

#elif Test03
#endif
        }
    }
}