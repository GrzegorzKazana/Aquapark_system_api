using System;

namespace AquaparkSystemApi.Models
{
    public class PeriodicDiscount
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public decimal Value { get; set; }
    }
}