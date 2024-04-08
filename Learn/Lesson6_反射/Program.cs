using System;
using System.Reflection;

namespace Lesson6_反射
{
    class Test
    {
        private int i = 1;
        public int j = 0;
        public string str = "103";

        public Test()
        {
            Console.WriteLine("无参构造");
        }

        public Test(int i)
        {
            this.i = i;
            
            Console.WriteLine("一参构造" + i);
        }

        public Test(int i, string str) : this(i)
        {
            this.str = str;
            
            Console.WriteLine("二参构造" + i + str);
        }

        public void Speek()
        {
            Console.WriteLine("Speek");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // 程序运行时 可以查看其他程序集或者自身的元数据
            //  一个运行的程序查看本身或者其他程序的元数据的行为被称为反射
            // 反射：动态获取程序集中类型信息的能力
            
            //type 类的信息类
            // 他是反射功能的基础
            // 他是访问元数据的主要方式
            // 使用Type的成员获取有关类型声明的信息
            // 有关类型的成员（如构造函数 方法 字段 属性和类的事件）
            
            // 获取Type
            //1
            int a = 43;
            Type type = a.GetType();
            Console.WriteLine(type);
            //2
            Type type2 = typeof(int);
            Console.WriteLine(type2);
            //3 GetType（）必须包含命名空间
            Type type3 = Type.GetType("System.Int32");
            Console.WriteLine(type3);
            // 每一个int的type 都指向一个地址
            
            
            //得到程序集
            
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type2.Assembly);
            Console.WriteLine(type3.Assembly);
            
            //获取类中的所有公共成员

            Console.WriteLine("***************************");
            Type t = typeof(Test);
            MemberInfo[] members = t.GetMembers();
            for (int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i]);
            }
            
            Console.WriteLine("***************************");
            //获取所有的构造函数
            ConstructorInfo[] ctor = t.GetConstructors();
            for (int i = 0; i < ctor.Length; i++)
            {
                Console.WriteLine(ctor[i]);
            }
            
            // 获取其中一个构造函数并执行
            //得构造函数并传入 Type数组 数组中内容按顺序是参数类型
            // 执行构造函数传入 object数组 表示按顺序传入得参数

            //无参
            ConstructorInfo ctorInfo = t.GetConstructor(new Type[0]);
            //执行
            Test test = ctorInfo?.Invoke(null) as Test;

            //一参
            ConstructorInfo ctorInfo2 = t.GetConstructor(new Type[] { typeof(int) });
            Test test02 = ctorInfo2.Invoke(new object[]{15}) as Test;

            // 二参
            ConstructorInfo ctorInfo3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) });
            Test test03 = ctorInfo3.Invoke(new object[] { 66, "hello" }) as Test;


            #region 获取类得公共成员变量

            FieldInfo[] fieldInfos = t.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                Console.WriteLine(fieldInfos[i]);
            }
            
            //得指定名称得公共成员变量
            FieldInfo fieldInfo1 = t.GetField("j");
            Console.WriteLine(fieldInfo1);
            
            Console.WriteLine("***************************");
            //通过反射获取和设置对象的值
            Test test04 = new Test();
            test04.j = 99;
            test04.str = "2222";
            
            // 通过反射 获取对象得某个对象得值
            Console.WriteLine(fieldInfo1.GetValue(test04));
            fieldInfo1.SetValue(test04, 100);
            Console.WriteLine(fieldInfo1.GetValue(test04));
            
            Console.WriteLine("***************************");
            //获得类中得公共成员方法
            Type strType = typeof(String);
            MethodInfo[] methodInfos = strType.GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(methodInfos[i]);
            }
            //存在重载 用type数据表示参数
            MethodInfo methodInfo1 = strType.GetMethod("Substring", new Type[]{typeof(int), typeof(int)});
            
            //调用
            string str = "Hello World!";
            //第一个参数是哪个对象执行这个成员方法 后边得是参数
            string tt = methodInfo1.Invoke(str, new object[]{2, 8}) as string;
            Console.WriteLine(tt);
            
            #endregion
            
            Console.WriteLine("Hello World!");
        }
    }
}