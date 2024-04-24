using System;

namespace Lesson7_特性
{
    class MyCustomAttribute : Attribute
    {
        public MyCustomAttribute(string info)
        {
            Info = info;
        }
        
        // 特性可以包含一些自定义的数据
        public string Info;

        public void TestFunc()
        {
            Console.WriteLine("测试特性" + Info);
        }
    }

    [MyCustom("这是一个自定义特性")]
    class Person
    {
        [MyCustom("年纪")] public int age;
        
        [MyCustom("名字")] public string name;
    }
    
    //限制自定义特性的使用范围
    
    //参数一 限制类型 参数二 是否可以重复 参数三 是否在子类中继承特性
    [AttributeUsage(AttributeTargets.Class)]
    
    //设置提示 过时提示 
    //参数1 提示文本 参数二 是否直接报错
    [Obsolete("这个特性已经过时")]
    public class  MyCustomAttribute2 : Attribute 
    {
        public MyCustomAttribute2(string info)
        {
            Info = info;
        }
        
        // 特性可以包含一些自定义的数据
        public string Info;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Type personType = typeof(Person);
            object[] attributesType = personType.GetCustomAttributes(true);
            for (int i = 0; i < attributesType.Length; i++)
            {
                if (attributesType[i] is MyCustomAttribute attribute)
                {
                    Console.WriteLine(attribute.Info);
                    attribute.TestFunc();
                }
            }
        }
    }
}