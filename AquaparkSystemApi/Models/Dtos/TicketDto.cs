using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ZoneWithAttractionsInformationDto Zone { get; set; }
        public TicketTypeDto TicketType { get; set; }
    }
}