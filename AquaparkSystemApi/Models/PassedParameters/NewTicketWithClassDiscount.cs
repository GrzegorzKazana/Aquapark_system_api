using Newtonsoft.Json;

namespace AquaparkSystemApi.Models.PassedParameters
{
    public class NewTicketWithClassDiscount
    {
        [JsonProperty("ticketId")]
        public int TicketId { get; set; }
        [JsonProperty("socialClassDiscountId")]
        public int SocialClassDiscountId { get; set; }
        [JsonProperty("numberOfTickets")]
        public int NumberOfTickets { get; set; }
    }
}