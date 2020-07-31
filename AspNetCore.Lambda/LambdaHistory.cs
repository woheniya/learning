using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Lambda
{
    public class LambdaHistory
    {
        public delegate void MyDelegate(int id, string name);

        public void UseDelegate()
        {
            int i = 666;
            //.netframework1.0
            {
                //MyDelegate myDelegate1 = new MyDelegate(GetDate);
                //myDelegate1.Invoke(1, "aaa");
            }

            //.netframework2.0 增加了匿名方法
            {
                //MyDelegate myDelegate1 = new MyDelegate(delegate(int id,string name) {
                //    Console.WriteLine("我是2.0了");
                //});
                //myDelegate1.Invoke(2, "aaa");
            }

            //.netframework3.0 去掉了delegate关键字,加上了goes to=>
            {
                //MyDelegate myDelegate1 = new MyDelegate((int id, string name) => {
                //    Console.WriteLine("我是3.0了");
                //});
                //myDelegate1.Invoke(3, "aaa");
            }

            //.netframework3.0版本迭代 去掉了方法中的参数类型,语法糖(编译器通过委托声明的参数类型)
            {
                //MyDelegate myDelegate1 = new MyDelegate((id, name) => {
                //    Console.WriteLine("我是3.0同时代的版本了");
                //});
                //myDelegate1.Invoke(3, "aaa");
            }

            //.netframework3.0版本迭代 只有一行代码的，可以省略方法体中的大括号
            {
                //MyDelegate myDelegate1 = (id, name) => Console.WriteLine("我是3.0同时代plusPro版本了");
                //myDelegate1.Invoke(3, "aaa");
            }

            //go on
            {
                Action<string> action = s => Console.WriteLine("我是3.0，已经很简洁了");
                action.Invoke("666");

                //返回值
                Func<string> func = () => "666";
                Func<int, string> func1 = i => i.ToString();
            }
        }


        public void GetDate(int id,string name)
        {
            Console.WriteLine("好嗨哟");
        }

        public string GetLaLaLa(string name)
        {
            Console.WriteLine("好嗨哟");
            return default;
        }
    }
}
