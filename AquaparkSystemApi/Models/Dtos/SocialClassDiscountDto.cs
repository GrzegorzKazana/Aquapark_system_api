using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class SocialClassDiscountDto
    {
        public int Id { get; set; }
        public string SocialClassName { get; set; }
        public decimal Value { get; set; }
    }
}