namespace AquaparkSystemApi.Models.PassedParameters
{
    public class NewTicketWithClassDiscount
    {
        public int TicketId { get; set; }
        public int SocialClassDiscountId { get; set; }
        public int NumberOfTickets { get; set; }
    }
}