using System;

namespace Lesson01_Struct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Griead!");
            
            //基本概念 自定义变量类型 数据和函数的集合 用结构体表现 学生 动物 人类等等
            
            //自定义结构体名 
            Student s1;
            
            
        }
    }
    
    
    struct Student
    {
        // 变量 
        // 结构体申明的变量 不能直接初始化
        // 变量类型 可以写任意类型 包括结构体 但是 不能是自己的结构体

        private int age;

        private bool sex;

        private int number;

        private string name;

        // 构造函数
        // 构造函数不能有返回值
        // 函数名必须和结构体名相同
        //  如果申明了构造函数 那么必须在其中把所有变量数据初始化
        // 一般方便外部初始化
        public Student(int age, bool sex, int number, string name)
        {
            this.age = age;
            this.sex = sex;
            this.number = number;
            this.name = name;   
        }    
        // 函数
    }
}