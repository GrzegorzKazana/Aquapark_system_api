using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models
{
    public class Position
    {

        public Position()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public Ticket Ticket { get; set; }
        public PeriodicDiscount PeriodicDiscount { get; set; }
        public SocialClassDiscount SocialClassDiscount { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<AttractionHistory> AttractionHistories { get; set; }
        public virtual ICollection<ZoneHistory> ZoneHistories { get; set; }
    }
}