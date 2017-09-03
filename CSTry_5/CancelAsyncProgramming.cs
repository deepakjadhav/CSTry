using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSTry_5
{
   public class CancelAsyncProgramming
    {

        CancellationTokenSource cts = null;

        public void CancelAsync()
        {
            if (cts != null) cts.Cancel();
        }
        async Task<string> GetWebResponse(string url, int index, CancellationToken ct)
        {
            HttpClient httpclient = new HttpClient() { MaxResponseContentBufferSize = 1000000 };
            var result = httpclient.GetAsync(url, ct);
            await Task.Delay(5000);
            await result;
            HttpResponseMessage response = result.Result;
            byte[] content = await response.Content.ReadAsByteArrayAsync();
            if (content.Length > 0) return string.Format("success-{0}-{1}", index.ToString(), DateTime.Now.ToString());
            else return string.Empty;
        }

        public async Task<string> SingleWebCall()
        {
            try
            {
                cts = new CancellationTokenSource();
                var result = GetWebResponse("http://www.google.com", 1, cts.Token);

                await result;
                cts = null;
                return result.Result;
            }
            catch (OperationCanceledException exception)
            {

                return "canceled";
            }
        }

        public async Task<string> MultipleWebCall()
        {
            try
            {
                cts = new CancellationTokenSource();
                var result1 = GetWebResponse("http://www.google.com", 1,cts.Token);
                var result2 = GetWebResponse("http://www.microsoft.com", 2, cts.Token);
                var result3 = GetWebResponse("http://www.yahoo.com", 3, cts.Token);
                await result1;
                await result2;
                await result3;
                                
                cts = null;
                return result1.Result + result2.Result + result3.Result;
            }
            catch (OperationCanceledException exception)
            {

                return "canceled";
            }
        }

        public async Task<string> MultipleWebCallCancelAfter()
        {
            try
            {
                cts = new CancellationTokenSource();
                cts.CancelAfter(1000);
                var result1 = GetWebResponse("http://www.google.com", 1, cts.Token);
                var result2 = GetWebResponse("http://www.microsoft.com", 2, cts.Token);
                var result3 = GetWebResponse("http://www.yahoo.com", 3, cts.Token);
                await result1;
                await result2;
                await result3;

                cts = null;
                return result1.Result + result2.Result + result3.Result;
            }
            catch (OperationCanceledException exception)
            {

                return "canceled";
            }
        }

        public async Task<string> MultipleWebCallCancelAfterAnyone()
        {
            try
            {
                cts = new CancellationTokenSource();
                var urllist = new List<string> { "http://www.google.com", "http://www.microsoft.com", "http://www.yahoo.com" };
                int index = 1;
                IEnumerable<Task<string>> result = from s in urllist select GetWebResponse(s, index++,cts.Token);

                Task<string>[] tasks = result.ToArray();
                var output = await Task.WhenAny(tasks);
                cts.Cancel();
                var returnresult = output.Result;
                cts = null;
                return returnresult;

            }
            catch (OperationCanceledException exception)
            {
                return "canceled";
            }
        }

    }
}
