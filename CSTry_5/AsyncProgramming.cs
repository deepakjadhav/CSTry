using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSTry_5
{
    public class AsyncProgramming
    {

        public async Task<string> MultipleWebCalls()
        {
            var result1 = GetWebResponse("http://www.google.com", 1);
            var result2 = GetWebResponse("http://www.microsoft.com", 2);
            var result3 = GetWebResponse("http://www.yahoo.com", 3);
            await result1;
            await result2;
            await result3;
            return result1.Result + result2.Result + result3.Result;
        }

        async Task<string> GetWebResponse(string url, int index)
        {
            HttpClient httpclient = new HttpClient() { MaxResponseContentBufferSize = 1000000 };
            var result = await httpclient.GetByteArrayAsync(url);
            Thread.Sleep(5000);
            if (result.Length > 0) return string.Format("success-{0}-{1}", index.ToString(),DateTime.Now.ToString());
            else return string.Empty;
        }

        public async Task<string> MultipleWebCallsWithWhenAll()
        {
            var urllist = new List<string> { "http://www.google.com", "http://www.microsoft.com", "http://www.yahoo.com" };
            int index = 1;
            IEnumerable<Task<string>> result = from s in urllist select GetWebResponse(s, index++);

            Task<string>[] tasks = result.ToArray();
            var output = await Task.WhenAll(tasks);
            var returnresult = string.Empty;
            foreach(string str in output)
            {
                returnresult += str;
            }
            return returnresult;
        }

        public async Task<string> MultipleWebCallsWithWhenAny()
        {
            var urllist = new List<string> { "http://www.google.com", "http://www.microsoft.com", "http://www.yahoo.com" };
            int index = 1;
            IEnumerable<Task<string>> result = from s in urllist select GetWebResponse(s, index++);

            Task<string>[] tasks = result.ToArray();
            var output = await Task.WhenAny(tasks);
            var returnresult = output.Result;
            //foreach (string str in output)
            //{
            //    returnresult += str;
            //}
            return returnresult;
        }
    }
}