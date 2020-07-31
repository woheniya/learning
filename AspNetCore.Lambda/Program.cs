using System;
using System.Collections.Generic;

namespace AspNetCore.Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            
            list.ChengWhere(x => x == "Id"); ;
            ExtensionLinq.ChengWhere(list, x => {

                Console.WriteLine("mycase");
                return default;
            });
        }
    }
}
