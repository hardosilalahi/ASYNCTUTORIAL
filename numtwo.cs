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
      public class Address
    {
        public string label { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }

    public class Phone
    {
        public string label { get; set; }
        public string phone { get; set; }
    }

    public class Department
    {
        public string name { get; set; }
    }

    public class Position
    {
        public string name { get; set; }
    }

    public class RootObject2
    {
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string birthday { get; set; }
        public List<Address> addresses { get; set; }
        public List<Phone> phones { get; set; }
        public List<string> presence_list { get; set; }
        public int salary { get; set; }
        public Department department { get; set; }
        public Position position { get; set; }
    }

    public class numtwo
    {
        public static async Task<List<RootObject2>> Fetch(){
            var client = new HttpClient();

            var result = await client.GetStringAsync("https://mul14.github.io/data/employees.json");

            var fet = JsonConvert.DeserializeObject<List<RootObject2>>(result);

            return fet;
        }
        
    }
}