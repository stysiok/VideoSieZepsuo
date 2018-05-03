using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLender.Models
{
    public class Lend
    {
        public int Id { get; set; }

        public Movie Movie { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime PeriodOfLending { get; set; }
    }
}