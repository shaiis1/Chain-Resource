using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource_ShaiIsraeli
{
    public class HttpRequester
    {
        public async static Task<T> GetData<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<T>(content);
            Console.Write(responseData);
            return responseData;
        }
    }
}
