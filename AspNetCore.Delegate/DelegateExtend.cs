using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.Delegate
{
    public class DelegateExtend
    {
        public void Show()
        {
            InvokeAction invokeAction = new InvokeAction();
            Action action = () => { invokeAction.Show(); };
            Type type = invokeAction.GetType();
            if (type.IsDefined(typeof(BeforeActionAttribute),true))
            {
                foreach (BaseAttribute baseAttribute in type.GetCustomAttributes(typeof(BaseAttribute),true))
                {
                    action = baseAttribute.Do(action);
                }
            }
            action.Invoke();
        }
    }
    public abstract class BaseAttribute : Attribute
    {
        public abstract Action Do(Action action);
    }
    public class BeforeActionAttribute : BaseAttribute
    {
        public BeforeActionAttribute()
        {
            Console.WriteLine("封装了A方法");
        }
        public override Action Do(Action action)
        {
            return new Action(() =>
            {
                {
                    Console.WriteLine("A方法来咯!");
                }
                action.Invoke();
            });
        }
    }

    public class AfterActionAttribute : BaseAttribute
    {
        public AfterActionAttribute()
        {
            Console.WriteLine("封装了B方法");
        }
        public override Action Do(Action action)
        {
            return new Action(() =>
            {
                {
                    Console.WriteLine("B方法来咯!");
                }
                action.Invoke();
            });
        }
    }


    [BeforeAction]
    [AfterAction]
    public class InvokeAction
    {
        public InvokeAction()
        {
            Console.WriteLine("封装了C方法");
        }
        public void Show()
        {
            Console.WriteLine("C方法来咯!");
        }
    }
}
