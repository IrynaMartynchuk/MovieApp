using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Model
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Image Address")]
        public string ImageAddress { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Genre")]
        public string Genre { get; set; }
        public virtual List<Orderline> Orderlines { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Movie)
            {
                Movie other = (Movie)obj;
                return Equals(other.Id, this.Id) && Equals(other.ImageAddress, this.ImageAddress) && Equals(other.Title, this.Title) &&
                    Equals(other.Description, this.Description) && Equals(other.Genre, this.Genre) && Equals(other.Price, this.Price);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}