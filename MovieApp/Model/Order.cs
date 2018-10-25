using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Model
{
    public class Order
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public bool Confirmed { get; set; }
        public string SessionId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Orderline> OrderLines { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Order)
            {
                Order other = (Order)obj;
                return Equals(other.Id, this.Id) && Equals(other.Confirmed, this.Confirmed) && Equals(other.SessionId, this.SessionId) &&
                    Equals(other.Customer, this.Customer);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}