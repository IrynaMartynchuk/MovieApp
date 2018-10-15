using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string ImageAddress { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Genre { get; set; }
        public virtual List<Orderline> Orderlines { get; set; }
    }
}