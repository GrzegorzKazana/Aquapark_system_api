using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models
{
    public class AttractionHistory
    {
        public int Id { get; set; }
        public Attraction Attraction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public Position Position { get; set; }
    }
}