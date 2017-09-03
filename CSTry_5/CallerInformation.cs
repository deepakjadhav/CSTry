using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTry_5
{
    public class CallerInformation
    {

        public string ReturnCallerInformation([System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            return string.Format("{0} - {1} - {2}", memberName, sourceFilePath, sourceLineNumber);
        }
    }
}
