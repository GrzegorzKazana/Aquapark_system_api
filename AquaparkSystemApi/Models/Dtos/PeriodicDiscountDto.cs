using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class PeriodicDiscountDto
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public decimal Value { get; set; }

    }
}