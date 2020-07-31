using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Delegate
{
    public enum FromType
    {
        YiChang,
        ShangHai,
        GuangDong,
        WuHan
    }
    public delegate void SayHiDelegate(string name);
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// 使用枚举来处理业务逻辑，当业务逻辑需要增加时，需要修改方法内部结构，增加枚举选项，违法了开放封闭原则OCP(Open－Close Principle) 
        /// 一个模块在扩展性方面应该是开放的而在更改性方面应该是封闭的
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fromType"></param>
        public void SayHi(string name, FromType fromType)
        {
            Console.WriteLine("招招手~~");
            switch (fromType)
            {
                case FromType.YiChang:
                    Console.WriteLine($"{name}同学:你好~");
                    break;
                case FromType.ShangHai:
                    Console.WriteLine($"{name}同学:侬好~");
                    break;
                case FromType.GuangDong:
                    Console.WriteLine($"{name}同学:雷猴~");
                    break;
                case FromType.WuHan:
                    Console.WriteLine($"{name}同学:吃了么~");
                    break;
                default:
                    throw new Exception("fromType Wrong!"); //不要隐藏错误
            }
        }


        //public void SayHiAction(string name, SayHiDelegate sayHiDelegate)
        //{
        //    Console.WriteLine("问候的同时，会招手。。。");
        //    sayHiDelegate.Invoke(name);
        //}

        public void SayHiAction(string name, Action<string> action)
        {
            Console.WriteLine("问候的同时，会招手。。。");
            action.Invoke(name);
        }

        public void SayHiYiChang(string name)
        {
            //Console.WriteLine("招招手~~"); 
            Console.WriteLine($"{name}同学:你好~");
        }

        public void SayHiShangHai(string name)
        {
            //Console.WriteLine("招招手~~");
            Console.WriteLine($"{name}同学:侬好~");
        }

        public void SayHiGuangDong(string name)
        {
            //Console.WriteLine("招招手~~");
            Console.WriteLine($"{name}同学:雷猴~");
        }

        public void SayHiWuhan(string name)
        {
            //Console.WriteLine("招招手~~");
            Console.WriteLine($"{name}同学:吃了么~");
        }
    }
}
