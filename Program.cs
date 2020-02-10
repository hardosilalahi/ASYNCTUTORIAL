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
    class Program : Fetcher
    {
        static async Task Main(string[] args)
        {
            // var result = await Get();

            Console.WriteLine(await NumberTres());

            // var scrape = new BlogScraper();
            // await scrape.StartAsync();
        }
    }
}
