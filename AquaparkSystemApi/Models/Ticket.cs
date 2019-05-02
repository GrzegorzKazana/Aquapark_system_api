using System.ComponentModel.DataAnnotations;

namespace AquaparkSystemApi.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Number { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Zone Zone { get; set; }
        public TicketType TicketType { get; set; }
    }
}