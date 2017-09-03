using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTry_6
{
    public static class CustomException 
    {
        public static string ExceptionExtension(this Exception exception)
        {
             return "custom";
        }
    }
}
