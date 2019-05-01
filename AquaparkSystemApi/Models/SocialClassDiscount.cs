using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models
{
    public class SocialClassDiscount
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string SocialClassName { get; set; }
    }
}