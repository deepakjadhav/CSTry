using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTry_7
{
    public class ParameterClass
    {
        public void CheckOut(int num, out string name)
        {
            name = num.ToString();
        }
    }
}
