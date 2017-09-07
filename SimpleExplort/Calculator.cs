using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExplort
{
    public class Calculator
    {
        private int x;
        private int y;
        public Calculator()
        {
            x = 0;
            y = 0;
            Console.WriteLine("Calculator() invoked");
        }
        public Calculator(int x,int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("Calculator(int x,int y) invoked");
        }

        public int Add()
        {
            int total = 0;
            total = x + y;
            Console.WriteLine("Invoke Instance Method:");
            Console.WriteLine(String.Format("[Add]:{0} plus {1} equals to {2}", x, y, total));
            return total;
        }

        public static void Add(int x,int y)
        {
            int total = x + y;
            Console.WriteLine("Invoke Static Method");
            Console.WriteLine(String.Format("[Add]:{0} plus {1} equals to {2}", x, y, total));
        }
    }
}
