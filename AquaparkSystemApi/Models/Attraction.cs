using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Zone Zone { get; set; }
    }
}