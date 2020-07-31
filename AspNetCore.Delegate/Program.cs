using System;

namespace AspNetCore.Delegate
{
    class Program
    {
        public delegate void MyDelegate();
        static void Main(string[] args)
        {
            //ShowDelegateExtend();
            //ShowStudent();
            ShowMatryoshka();
        }

        static void ShowDelegateExtend()
        {
            DelegateExtend deleget = new DelegateExtend();
            deleget.Show();
        }

        static void ShowStudent()
        {
            Student student = new Student();
            student.SayHiAction("deidei", student.SayHiGuangDong);
            student.SayHiAction("deidei", student.SayHiYiChang);
            student.SayHiAction("deidei", student.SayHiShangHai);
            student.SayHiAction("deidei", student.SayHiWuhan);
        }

        static void ShowMatryoshka()
        {
            Matryoshka matryoshka = new Matryoshka();
            matryoshka.Show();
        }
    }
}
