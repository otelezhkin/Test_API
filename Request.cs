using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test_API
{
    class Request
    {
        private static HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://countries.trevorblades.com/") };
        public static async Task<string> sendRequest(string request)
        {
            Console.WriteLine("Выполнение запроса:" + request);
            using var httpResponseMessage =
                await _httpClient.PostAsync(_httpClient.BaseAddress, new StringContent(request, Encoding.UTF8, "application/json"));
            httpResponseMessage.EnsureSuccessStatusCode();
            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var streamReader = new StreamReader(stream);
            var response = streamReader.ReadToEnd();
            Console.WriteLine("Ответ на запрос:");
            Console.WriteLine(response);
            return response;
        }
    }
}
