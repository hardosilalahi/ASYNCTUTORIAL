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
      public class Address{
        public string label { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }

    public class Phone{
        public string label { get; set; }
        public string phone { get; set; }
    }

    public class Department{
        public string name { get; set; }
    }

    public class Position{
        public string name { get; set; }
    }

    public class Employed{
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public DateTime birthday { get; set; }
        public List<Address> addresses { get; set; }
        public List<Phone> phones { get; set; }
        public List<string> presence_list { get; set; }
        public int salary { get; set; }
        public Department department { get; set; }
        public Position position { get; set; }
    }

    public class numtwo
    {
        public static async Task<List<Employed>> StartingClient(){
            var client = new HttpClient();

            var result = await client.GetStringAsync("https://mul14.github.io/data/employees.json");

            var deserial = JsonConvert.DeserializeObject<List<Employed>>(result);

            return deserial;
        }

        public static async Task<string> GajiLebih(){
            var start = await StartingClient();
            var employeeName = new List<string>();

            foreach(var i in start){
                if(i.salary > 15000000){
                    employeeName.Add($"{i.first_name} {i.last_name}");
                }
            }
            return $"Gaji Karyawan Lebih dari Rp15.000.000 : {String.Join(',', employeeName)}";
        }

        public static async Task<string> TinggalJakarta(){
            var start = await StartingClient();
            var employeeName = new List<string>();

            foreach(var i in start){
                foreach(var j in i.addresses){
                    if(j.city == "DKI Jakarta"){
                        employeeName.Add($"{i.first_name} {i.last_name}");
                    }
                }
            }
            var result = employeeName.Distinct();
            return $"Karyawan yang tinggal di JKT: {String.Join(',', result)}";
        }
        
        public static async Task<string> BirthMarch(){
            var start = await StartingClient();
            var employeeName = new List<string>();

            foreach(var i in start){
                var month = i.birthday.Month;
                if(month == 03){
                    employeeName.Add($"{i.first_name} {i.last_name}");
                }
            }
            var result = employeeName.Distinct();
            return $"Karyawan yang Ulangtahun Bulan Maret : {String.Join(',', result)}";
        }

        public static async Task<string> Dept_RD(){
            var start = await StartingClient();
            var employeeName = new List<string>();

            foreach(var i in start){
                if(i.department.name == "Research and development"){
                    employeeName.Add($"{i.first_name} {i.last_name}");
                }
            }
            return $"Karyawan Dept. R&D : {String.Join(',', employeeName)}";
        }

        public static async Task<string> OctAbsent(){
            var start = await StartingClient();
            var Absencies = new List<int>();

            foreach(var i in start){
                var count = 0;
                foreach(var j in i.presence_list){
                    if(j.Contains("-10-") == true){
                        count++;
                    }
                }
                Absencies.Add(count);
            }
            return $"Absen di Bulan Oktober : {String.Join(',', Absencies)}";
        }
    }
}