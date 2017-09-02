using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTry_3
{
    public class Delegates
    {
        Func<int,int, int> AddNumber = (x,y) => x + y;
        Func<int,int, int> SubNumber = (x,y) => x - y;
        Func<int, string> ConvertToString = x => string.Format("this is string {0}", x.ToString());

        public int AddTwoNumber(int x, int y)
        {
            return AddNumber(x, y);
        }

        public int SubtractTwoNumber(int x, int y)
        {
            return SubNumber(x, y);
        }

        public string ParseInt(int x)
        {
            return ConvertToString(x);
        }

        public int Calculate(int x, Func<int,int, int> multiply)
        {
            return x + multiply(x,5);
        }


    }
}
