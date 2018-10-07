﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Confirmed { get; set; }
        public string SessionId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Orderline> OrderLines { get; set; }
    }
}