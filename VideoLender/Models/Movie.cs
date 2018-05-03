using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLender.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public string PosterPath { get; set; }

        public bool IsReserved { get; set; }

        public bool IsLended { get; set; }

    }
}