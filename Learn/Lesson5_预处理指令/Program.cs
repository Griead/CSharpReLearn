
#define Unity4
#undef Unity5

using System;

namespace Lesson5_预处理指令
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            #if Unity4
                Console.WriteLine("Unity4");
            #elif Unity5
                Console.WriteLine("Unity5");
            #endif
            
        }
    }
}