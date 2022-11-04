using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_No12
{
    public delegate void MyDelegate();
    public class student
    {
        public event MyDelegate Pass;
        public event MyDelegate Fail;
        public void AcceptMarks(int marks)
        {
            if (marks < 40)
            {
                Fail();
            }
            else
            {
                Pass();
            }
        }
    }
    public class Program
    {
        static void Passmsg()
        {
            Console.WriteLine("you are Pass");
        }
        static void Failmsg()
        {
            Console.WriteLine("you are Fail");
        }
        static void Main(string[] args)
        {
            student student = new student();
            student.Pass += new MyDelegate(Passmsg);
            student.Fail += new MyDelegate(Failmsg);
            student.AcceptMarks(75);
        }
    }
}
