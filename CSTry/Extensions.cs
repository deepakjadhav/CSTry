using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTry_3
{
    public static class Extensions
    {
        public static string ConvertString(this int num, string addedtext)
        {
            return addedtext + num.ToString();
        }

        public static string ConvertString(this ExtendMe obj)
        {
            return obj.Name + obj.Address;
        }
    }

    public class ExtendMe
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public ExtendMe(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }

}
