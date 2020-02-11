using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IronWebScraper;
using System.Linq;

namespace async
{
    public class numfive : WebScraper 
    {
        public override void Init(){
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request("https://www.kompas.com/", Parse);
        }

        public override void Parse(Response response){
            foreach(var titleLink in response.Css("a.headline__thumb__link")){
                string link = titleLink.Attributes["href"];
                string title = titleLink.InnerTextClean;
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Link: {link}");
            }
        }
    }
}