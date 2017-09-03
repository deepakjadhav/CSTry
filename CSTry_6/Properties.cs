using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSTry_6.Helper;

namespace CSTry_6
{
    public class Properties
    {
        public string Name { get; }
        public int Age { get; }
        public string Gender { get; }

        public AnotherClass anotherclass;

        private List<string> states = new List<string>() { "tx", "az", "ny", "ca" };
        public Properties(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
            anotherclass = new AnotherClass();
        }

        public void SetName(string name)
        {
            //   Name = name;
            //   Error CS0200  Property or indexer 'Properties.Name' cannot be assigned to --it is read only 
        }

        public string Description => $"{Name} {Age} {Gender}";

        public string State => $"{states.Find( s => s.StartsWith("t"))}";

        public string CallHelper()
        {
            return ReturnMe();
        }

        public string CallAnother()
        {
            return this.anotherclass?.AnotherReturnMe();
        }
    }

    public class AnotherClass
    {
        public string AnotherReturnMe()
        {
            return "dependant";
        }
    }
}
