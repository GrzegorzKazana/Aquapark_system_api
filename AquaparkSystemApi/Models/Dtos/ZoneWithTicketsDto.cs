using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class ZoneWithTicketsDto
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public IEnumerable<TicketWithPeriodDiscountDto> TicketTypes { get; set; }
    }
}