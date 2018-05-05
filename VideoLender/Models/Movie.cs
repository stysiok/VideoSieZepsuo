using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLender.Models
{
    public class MovieResult
    {
        public IEnumerable<Movie> Results { get; set; }
    }

    public class Movie
    {
        
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public string Director { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("overview")]
        public string Description { get; set; }

        //"http://image.tmdb.org/t/p/w500/" + PosterPath
        [JsonProperty("poster_path")]
        public string PosterPath
        {
            get; set;
        }

        public bool IsReserved { get; set; }

        public bool IsLended { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

    }
}