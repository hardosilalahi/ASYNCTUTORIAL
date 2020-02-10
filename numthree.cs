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
    public class Yuser{
        public int Id {get;set;}
        public string Name{get;set;}
        public string Username{get;set;}
        public string Email{get; set;}
        public address Address{get; set;}
        public string Phone{get; set;}
        public string Website{get;set;}
        public Companies Company{get; set;}
    }

    public class address{
        public string Street{get;set;}
        public string Suite{get; set;}
        public string City{get; set;}
        public string Zipcode{get; set;}
        public geometrics Geo{get; set;}
    }

    public class geometrics{
        public string Lat{get; set;}
        public string Lng{get; set;}
    }

    public class Companies{
        public string Name{get; set;}
        public string CatchPhrase{get; set;}
        public string Bs{get; set;}
    }

    public class Posts{
        public int UserId{get;set;}
        public int Id{get; set;}
        public string Title{get; set;}
        public string Body{get; set;}
    }
    public class numberThree : Posts{
        public Yuser User{get; set;}
    }

    public class Fetcher
    {
        // public static async Task<List<Yuser>> Get(){
        //     var client = new HttpClient();
        //     var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

        //     var user = JsonConvert.DeserializeObject <List<Yuser>>(result);

        //     return user;
        // }

        // public static async Task<List<Posts>> Post(){
        //     var client = new HttpClient();
        //     var result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            
        //     var post = JsonConvert.DeserializeObject<List<Posts>>(result);

        //     return post;
        // }

        public static async Task<string> NumberTres(){

            var client = new HttpClient();
            var resourceUno = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var resourceDos = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            var result = new List<numberThree>();

            var youser = JsonConvert.DeserializeObject <List<Yuser>>(resourceUno);
            var post = JsonConvert.DeserializeObject<List<Posts>>(resourceDos);
            
            foreach(var i in youser){
                var abcd = post.Where(x => x.UserId == i.Id).FirstOrDefault();
                if(post.Where(x => x.UserId == i.Id).FirstOrDefault() != null){
                    result.Add(new numberThree{
                        UserId = abcd.UserId,
                        Id = abcd.Id,
                        Title = abcd.Title,
                        Body = abcd.Body,
                        User = new Yuser{
                            Id = i.Id,
                            Name = i.Name,
                            Username = i.Username,
                            Email = i.Email,
                            Address = new address{
                                Street = i.Address.Street,
                                Suite = i.Address.Suite,
                                City = i.Address.City,
                                Zipcode = i.Address.Zipcode,
                                Geo = new geometrics{
                                    Lat = i.Address.Geo.Lat,
                                    Lng = i.Address.Geo.Lng
                                }
                            },
                            Phone = i.Phone,
                            Website = i.Website,
                            Company = new Companies{
                                Name = i.Company.Name,
                                CatchPhrase = i.Company.CatchPhrase,
                                Bs = i.Company.Bs
                            }
                        }
                    });
                }
            }

            var text = JsonConvert.SerializeObject(result);
            return text;

        }

    }


}
