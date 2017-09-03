using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Dynamic;

namespace CSTry_4
{
    public class Dynamics
    {
        public string DefineMe(dynamic obj)
        {
            if (obj is int) return string.Format("i am {0}", obj.ToString());
            if (obj is string) return string.Format("i am {0}", obj);
            else return "not found";
        }

        public string VerifyObject(object obj)
        {
            //compile time typedetermined
            //boxing/unboxing
            return (string)obj;
        }

        public string VerifyString(string obj)
        {
            //compile time typedetermined
            var str = obj;
            return str;
        }

        public string VerifyDynamic(dynamic obj)
        {
            //runtime typedetermined
            return obj;
        }
    }
}
