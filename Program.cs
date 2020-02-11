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

            // var scrape = new numsix();
            // await scrape.StartAsync();

            // var scrape2 = new numfive();
            // await scrape2.StartAsync();

            Console.WriteLine(await numtwo.GajiLebih());
            Console.WriteLine(await numtwo.TinggalJakarta());
            Console.WriteLine(await numtwo.BirthMarch());
            Console.WriteLine(await numtwo.Dept_RD());
            Console.WriteLine(await numtwo.OctAbsent());

        }
    }   
}

