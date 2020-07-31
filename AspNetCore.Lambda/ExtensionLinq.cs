using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Lambda
{
    public static class ExtensionLinq
    {
        public static List<T> ChengWhere<T>(this List<T> resource,Func<T,bool> func)
        {
            List<T> list = new List<T>();

            foreach (var item in resource)
            {
                if (func.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
