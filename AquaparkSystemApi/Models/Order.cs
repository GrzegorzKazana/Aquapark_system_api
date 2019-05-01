using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

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