using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.PassedParameters
{
    public class AttractionEntry
    {
        public ZoneEntry ZoneEntry { get; set; }
        public int AttractionId { get; set; }
    }
}