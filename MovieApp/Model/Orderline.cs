using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Model
{
    public class Orderline
    {
        public int Id { get; set; }
        public int Antall { get; set; }
        public int MovieId { get; set; }
        public int OrderId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }

    }
}