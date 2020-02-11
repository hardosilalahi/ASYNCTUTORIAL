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
    // public class BlogScraper : WebScraper 
    // {
        // public override void Init(){
        //     this.LoggingLevel = WebScraper.LogLevel.All;
        //     this.Request("https://blog.scrapinghub.com/", Parse);
        // }

        // public override void Parse(Response response){
        //     foreach(var titleLink in response.Css("div.post-header")){
        //         string link = titleLink.Css("a[href]").First().Attributes["href"];

        //         Console.WriteLine(link);
        //     }
        // }
    //     // public override void Init(){
    //     //     this.LoggingLevel = WebScraper.LogLevel.All;
    //     //     this.Request("https://www.kompas.com/", Parse);
    //     // }

    //     // public override void Parse(Response response){
    //     //     foreach(var titleLink in response.Css("div.slick-track")){
    //     //         string link = titleLink.Css("a[href]").First().Attributes["href"];
    //     //         // string title = titleLink.Css("img[alt]").First().Attributes["alt"];

    //     //         Console.WriteLine(link);
    //     //         // Console.WriteLine(title);
    //     //     }
    //     // }
    // }
}