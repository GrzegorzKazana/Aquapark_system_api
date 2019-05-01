using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
    }
}