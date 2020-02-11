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

    public class numthree
    {
        public static async Task<string> NumberTres(){

            var client = new HttpClient();
            var resourceUno = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            var resourceDos = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");

            var result = new List<numberThree>();

            var youser = JsonConvert.DeserializeObject <List<Yuser>>(resourceUno);
            var post = JsonConvert.DeserializeObject<List<Posts>>(resourceDos);
            
            foreach(var i in post){
                var abcd = youser.Where(x => x.Id == i.UserId).FirstOrDefault();
                if(abcd != null){
                    result.Add(new numberThree{
                        UserId = i.UserId,
                        Id = i.Id,
                        Title = i.Title,
                        Body = i.Body,
                        User = new Yuser{
                            Id = abcd.Id,
                            Name = abcd.Name,
                            Username = abcd.Username,
                            Email = abcd.Email,
                            Address = new address{
                                Street = abcd.Address.Street,
                                Suite = abcd.Address.Suite,
                                City = abcd.Address.City,
                                Zipcode = abcd.Address.Zipcode,
                                Geo = new geometrics{
                                    Lat = abcd.Address.Geo.Lat,
                                    Lng = abcd.Address.Geo.Lng
                                }
                            },
                            Phone = abcd.Phone,
                            Website = abcd.Website,
                            Company = new Companies{
                                Name = abcd.Company.Name,
                                CatchPhrase = abcd.Company.CatchPhrase,
                                Bs = abcd.Company.Bs
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