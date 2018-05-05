using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VideoLender.Models;

namespace VideoLender.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMovies(int id = 1)
        {
            var text = "";
            using (var webClient = new System.Net.WebClient())
            {
                text = webClient.DownloadString($"https://api.themoviedb.org/3/movie/top_rated?api_key=2b21e74ae50a8d757b8dd9406397edbc&language=en-US&page={id}");
                
                var data = JsonConvert.DeserializeObject<MovieResult>(text);

                foreach(var val in data.Results)
                {
                    text = webClient.DownloadString($"https://api.themoviedb.org/3/movie/{val.Id}/credits?api_key=2b21e74ae50a8d757b8dd9406397edbc&language=en-US");

                    var jobj = JObject.Parse(text);

                    val.Director = (from item in (JArray)jobj["crew"]
                                    where item.Value<string>("job") == "Director"
                                    select item.Value<string>("name")).FirstOrDefault();
                }

                var appdbctx = new ApplicationDbContext();

                
                    appdbctx.Movies.AddRange(data.Results);
                appdbctx.SaveChanges();
            }

            
            return View();
        }
    }
}