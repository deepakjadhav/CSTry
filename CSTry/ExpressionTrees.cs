using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSTry_3
{
    public class ExpressionTrees
    {
        Expression<Func<int, bool>> prime = x => isPrime(x);

        Expression<Func<int, List<int>, bool>> existsin = (x, y) => y.Contains(x);

        public bool CheckIfPrime(int num)
        {
            Func<int, bool> compileprime = prime.Compile();
            return compileprime(num);
        }

        public bool CheckIfexists(int num, List<int> lists)
        {
            Func<int,List<int>, bool> compileexistsin = existsin.Compile();
            return compileexistsin(num,lists);
        }


        private static bool isPrime(int x)
        {
            if (x == 1) return false;
            if (x == 2 || x == 3) return true;
            for (int i = 2; i < Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
    }
}
