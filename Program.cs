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
    class Program
    {
        static async Task Main(string[] args)
        {
            // var result = await Get();

            // Console.WriteLine(await numthree.NumberTres());

            // Console.WriteLine(await numfour.movieKeanu());
            // Console.WriteLine(await numfour.movieIndonesia());
            // Console.WriteLine(await numfour.movieRobertHolland());
            // Console.WriteLine(await numfour.movie2016());

            // var scrape = new BlogScraper();
            // await scrape.StartAsync();

            //start of num2
            var numTwo = await numtwo.Fetch();
            Console.WriteLine("gaji karyawan lebih dari Rp15.000.000 :");
            List<string> sal = new List<string>();
            foreach (var X in numTwo){
                if(X.salary>15000000){
                    sal.Add($"{X.first_name} {X.last_name}");
                }
            }
            Console.WriteLine(String.Join(", ", sal));
            Console.WriteLine();
            
            Console.WriteLine("yang tinggal di jkt :");
            List<string> jkt48 = new List<string>();
            foreach (var X in numTwo){
                foreach(var Y in X.addresses){
                    if(Y.city== "DKI Jakarta"){
                        jkt48.Add($"{X.first_name} {X.last_name}");
                    }
                }
            }
            var jkt96 = jkt48.Distinct();
            Console.WriteLine(String.Join(", ", jkt96));
            Console.WriteLine();

            Console.WriteLine("yang ultah maret :");
            List<string> Mar = new List<string>();
            foreach (var X in numTwo){
                if ((X.birthday).Substring(5,2)=="03"){
                    Mar.Add($"{X.first_name} {X.last_name}");
                }
            }
            Console.WriteLine(String.Join(", ", Mar));
            Console.WriteLine();

            Console.WriteLine("yang di departemen R&D :");
            List<string> RnD = new List<string>();
            foreach (var X in numTwo){
                if(X.department.name== "Research and development"){
                    RnD.Add($"{X.first_name} {X.last_name}");
                }
            }
            Console.WriteLine(String.Join(", ", RnD));
            Console.WriteLine();

            Console.WriteLine("yang absen di oktober :");
            List<int> Absen = new List<int>();
            foreach (var X in numTwo){
                int count = 0;
                foreach(var Y in X.presence_list){
                    if(Y.Substring(5,2)=="10"){
                        count++;
                    } 
                }
                Absen.Add(count);
            }
            Console.WriteLine(String.Join(", ", Absen));
        }
        //end of num2
    }
}

