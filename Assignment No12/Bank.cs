using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_No12
{
    public delegate void MyDelegate();
    public class Bank
    {

        public event MyDelegate insufficientbalance;
        public event MyDelegate zerobalance;
        public event MyDelegate lowbalance;
        public event MyDelegate updatedbalance;
        public int balance = 5000;
        public int Credit(int amount)
        {
            balance = balance + amount;
            //updatedbalance();
            return balance;

        }
        public void Debit(int amount)
        {
            if (amount > balance)
            {
                insufficientbalance();
            }
            else
            {
                balance -= amount;


                if (balance == 0)
                {
                    zerobalance();

                }
                else if (balance < 3000)
                {
                    lowbalance();

                }
                else
                {
                    Console.WriteLine(balance);
                }
            }
        }
        public class program
        {
            static void Imsg()
            {
                Console.WriteLine("you have insufficient balance");
            }
            static void Zmsg()
            {
                Console.WriteLine("you have zero balance");
            }
            static void Lmsg()
            {
                Console.WriteLine("you have low balance");
            }
            static void Main(string[] args)
            {
                Bank b = new Bank();
                b.insufficientbalance += new MyDelegate(Imsg);
                b.zerobalance += new MyDelegate(Zmsg);
                b.lowbalance += new MyDelegate(Lmsg);
                b.Credit(0);
                b.Debit(3000);

            }
        }
    }
}

