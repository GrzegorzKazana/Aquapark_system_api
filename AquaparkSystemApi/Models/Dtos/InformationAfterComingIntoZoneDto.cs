using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class InformationAfterComingIntoZoneDto
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public int? ZoneId { get; set; }
        public int? PositionId { get; set; }
    }
}