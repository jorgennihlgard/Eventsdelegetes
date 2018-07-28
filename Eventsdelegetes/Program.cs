using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventsdelegetes
{
    class Program
    {
        static void Main(string[] args)
        {
            Cash c = new Cash();
            Bank b = new Bank();
            
            c.MyEvent += C_MyEvent;
            c.MyEvent += b.OnMyCash;

            c.AddCash(50);
            c.AddCash(50);

            Console.ReadLine();
        }

        

        private static void C_MyEvent(object sender,CashEventArgs e)
        {
            Console.WriteLine("Cashen har trillat in" + e.Cash);
        }
    }


    class Cash
    {

        public delegate void MyEventHandler(object sender, CashEventArgs e);
        public event MyEventHandler MyEvent;
        //public event EventHandler<CashEventArgs> MyEvent;

        
        private int myCash;

        public int MyCash
        {
            get
            {
                return myCash;
            }

            set
            {
                myCash = value;

                if (myCash == 100)
                {
                    if (MyEvent != null)
                    {
                        OnMyEvent(myCash);
                    }
                }
            }
        }

        protected void OnMyEvent(int myCash)
        {
            MyEvent(this,new CashEventArgs() {Cash= myCash });
        }

        public void AddCash(int amount)
        {
            MyCash += amount;
        }



    }
}
