using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTry_6
{
    public class ExceptionUseCase
    {

        public string MathError()
        {
            string str = "success";
            try
            {
                if (1 == 1) throw new Exception("math error");
            }
            catch (Exception e) when (CustomException.ExceptionExtension(e) != "custom") 
            {
                str = "error";               
            }
            return str;
        }

        public string InvalidError()
        {
            string str = "success";
            try
            {
                if (1 == 1) throw new Exception("math error");
            }
            catch (Exception e) when (CustomException.ExceptionExtension(e) != "success")
            {
                str = "error";
            }
            return str;
        }
    }
}
