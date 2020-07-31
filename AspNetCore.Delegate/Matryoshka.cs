using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AspNetCore.Delegate
{
    public class Matryoshka
    {
        public void Show()
        {
            MainLogic mainLogic = new MainLogic();
            Type type = mainLogic.GetType();
            MethodInfo methodInfo = type.GetMethod("Method");
            Action action = new Action(() =>
            {
                methodInfo.Invoke(mainLogic, null);
            });

            if (methodInfo.IsDefined(typeof(AbstractAttribute),true))
            {
                IEnumerable<AbstractAttribute> abstractAttributes = methodInfo.GetCustomAttributes<AbstractAttribute>();
                foreach (AbstractAttribute attribute in abstractAttributes.Reverse())
                {
                    action = attribute.Do(action);
                }
            }
            action.Invoke();
        }
    }

    public abstract class AbstractAttribute:Attribute
    {
        public abstract Action Do(Action action);
    }

    public class RecordTimeAttribute : AbstractAttribute
    {
        public RecordTimeAttribute()
        {
            Console.WriteLine("RecordTimeAttribute");
        }
        public override Action Do(Action action)
        {
            Action actionResult = new Action(() =>
            {
                {
                    Console.WriteLine($"现在是北京时间：{DateTime.Now}");
                }
                action.Invoke();
            });
            return actionResult;
        }
    }
    public class LoggingAttribute : AbstractAttribute
    {
        public LoggingAttribute()
        {
            Console.WriteLine("LoggingAttribute");
        }
        public override Action Do(Action action)
        {
            Action actionResult = new Action(() =>
            {
                {
                    Console.WriteLine("记录日志");  //这里可以随便写。。。。
                }
                action.Invoke();
            });
            return actionResult;
        }
    }

    public class MainLogic
    {
        public MainLogic()
        {
            Console.WriteLine("MainLogic");
        }
        [Logging]
        [RecordTime]
        public void Method()
        {
            Console.WriteLine("This is a mainLogic area!");
        }
    }
}
