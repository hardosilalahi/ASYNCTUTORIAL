using System.Xml.Linq;
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
    public class numsix : WebScraper
    {
        public override void Init(){
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request("https://www.cgv.id/en/", Parse);
        }

        public override void Parse(Response response){
            foreach(var titleLink in response.Css("ul.slides > li > a")){
                string link = titleLink.Attributes["href"];
                this.Request(link, ParseLagi);
                // Console.WriteLine(link);
            }
        }
        public void ParseLagi(Response response){
            string title = response.Css("div.movie-info-title").First().InnerText.Replace("\t", "");
            Console.WriteLine(title);
            foreach(var i in response.Css("div.movie-add-info > ul")){
                string info = i.InnerText.Replace("\t","");
                Console.WriteLine(info);
            }
            string synopsis = response.Css("div.movie-synopsis").First().InnerText.Replace("\t", "");
            
            Console.WriteLine(synopsis);
        }
    }
}