using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventsdelegetes
{
    class Bank
    {
        
        public void OnMyCash(object sender, CashEventArgs e)
        {
            Console.WriteLine("Bank notified" + e.Cash);
        }
    }
}
