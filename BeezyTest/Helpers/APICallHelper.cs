using BeezyTest.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeezyTest.Helpers
{
    public static class APICallHelper
    {

            private static HttpClient GetHttpClient(string url)
             {
                 var client = new HttpClient { BaseAddress = new Uri(url) };
                 client.DefaultRequestHeaders.Accept.Clear();
                 client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                 return client;
             }




             private static async Task<T> GetAsync<T>(string url, string urlParameters)
             {
                 try
                 {
                     using (var client = GetHttpClient(url))
                     {
                         HttpResponseMessage response = await client.GetAsync(urlParameters).ConfigureAwait(continueOnCapturedContext: false); ;
                         if (response.IsSuccessStatusCode)
                         {
                             var json = await response.Content.ReadAsStringAsync();
                             var result = JsonConvert.DeserializeObject<T>(json, Converter.Settings);
                             return result;
                         }

                         return default(T);
                     }
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);
                     return default(T);
                 }
             }



             public static async Task<T> RunAsync<T>(string url, string urlParameters)
             {
                 return await GetAsync<T>(url, urlParameters).ConfigureAwait(continueOnCapturedContext: false);
             }

         }
    }

