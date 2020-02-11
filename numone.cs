using System.Net;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IronWebScraper;
using System.IO;

namespace async
{
    public class numone
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> Get(string link){
            return await client.GetStringAsync(link);
        }
        public static async void Delete(string link){
            await client.DeleteAsync(link);
        }

        public static async void Post(string link, HttpContent data){
            await client.PostAsync(link, data);
        }

        public static async void Put(string link, HttpContent data){
            await client.PutAsync(link, data);
        }
        
        public static async void Patch(string link, HttpContent data){
            await client.PatchAsync(link, data);
        }
    }
}