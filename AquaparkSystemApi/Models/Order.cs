using System;
using System.Collections.Generic;

namespace AquaparkSystemApi.Models
{
    public class Order
    {
        public Order()
        {
            this.Positions = new HashSet<Position>();
        }
        public int Id { get; set; }
        public DateTime DateOfOrder { get; set; }
        public virtual ICollection<Position> Positions { get; set; }

    }
}