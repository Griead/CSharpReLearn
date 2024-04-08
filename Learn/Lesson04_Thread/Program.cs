using System;
using System.Threading;

namespace Lesson04_Thread
{
    class Program
    {
        static void NewThread()
        {
            while (true)
            {
                Console.WriteLine("Thread is running");
            }
        }
        
        static void Main(string[] args)
        {
            Thread t = new Thread(NewThread);
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("Hello World!");
        }
    }
}