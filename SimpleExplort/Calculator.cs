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
    }
}
