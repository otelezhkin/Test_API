﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test_API
{
    internal static class ServiceHelper
    {
        private static HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://countries.trevorblades.com/") };
        public static async Task<string> PostRequestAsync_get()
        {
            string query = $"{{country (code: \"RU\"){{code name}}}}";
            var queryParamsBuilder = new StringBuilder($"query={query}");
            using var httpResponseMessage =
                await _httpClient.GetAsync($"{_httpClient.BaseAddress}?{queryParamsBuilder}");
            httpResponseMessage.EnsureSuccessStatusCode();
            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var streamReader = new StreamReader(stream);
            var result = streamReader.ReadToEnd();
            Console.WriteLine(result);
            return result;
        }
        public static async Task<string> PostRequestAsync_post()
        {
            var queryParamsBuilder = new StringBuilder($"query={{country (code: \"RU\"){{code name}}}}");
            var q3 = "{\"query\":\"query {country(code:\\\"RU\\\"){code name}}\"}";
            using var httpResponseMessage =
                await _httpClient.PostAsync(_httpClient.BaseAddress, new StringContent(q3, Encoding.UTF8, "application/json"));
            httpResponseMessage.EnsureSuccessStatusCode();
            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var streamReader = new StreamReader(stream);
            var response = streamReader.ReadToEnd();
            //Console.WriteLine(response);
            return response;
        }
        public static async Task<object> PostRequestAsync_post_return_object()
        {
            var queryParamsBuilder = new StringBuilder($"query={{country (code: \"RU\"){{code name}}}}");
            var q3 = "{\"query\":\"query {country(code:\\\"RU\\\"){code name}}\"}";
            using var httpResponseMessage =
                await _httpClient.PostAsync(_httpClient.BaseAddress, new StringContent(q3, Encoding.UTF8, "application/json"));
            httpResponseMessage.EnsureSuccessStatusCode();
            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            using var streamReader = new StreamReader(stream);
            var response = streamReader.ReadToEnd();
            //Country restoredCountry = JsonSerializer.Deserialize<Country>(response);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);
            Console.WriteLine(myDeserializedClass);
            Console.WriteLine("Ответ на запрос до десериализации в методе:");
            Console.WriteLine(response);
            Console.WriteLine("Ответ на запрос после десериализации в методе:");
            Console.WriteLine(myDeserializedClass.data.country.code);
            return myDeserializedClass;
        }
        public static async Task<string> get_Country_by_code(string countryCode)
        {
            var query = "{\"query\":\"query {country(code:\\\"" + countryCode + "\\\"){code name capital}}\"}";
            var response = await Request.sendRequest(query);
            return response;
        }
        public static async Task<string> get_Language_by_code(string languageCode)
        {
            var query = "{\"query\":\"query {language(code:\\\"" + languageCode + "\\\"){code name native rtl}}\"}";
            var response = await Request.sendRequest(query);
            return response;
        }
        public static async Task<string> get_Languages_by_filter_empty()
        {
            var query = "{\"query\":\"query {languages{code name native rtl}}\"}";
            var response = await Request.sendRequest(query);
            return response;
        }
        public static async Task<string> get_Languages_by_filter_codeEqual(string languageCode)
        {
            var query = "{\"query\":\"query {languages(filter:{code:{eq:\\\"" + languageCode + "\\\"}}){code name native rtl}}\"}";
            var response = await Request.sendRequest(query);
            return response;
        }
        public static async Task<string> get_Countries_by_filter_empty()
        {
            var query = "{\"query\":\"query {countries{code name capital}}\"}";
            var response = await Request.sendRequest(query);
            return response;
        }
        public static async Task<string> get_Countries_by_filter_codeEqual(string countryCode)
        {
            var query = "{\"query\":\"query {countries(filter:{code:{eq:\\\"" + countryCode + "\\\"}}){code name capital}}\"}";
            var response = await Request.sendRequest(query);
            return response;
        }
    }
}
