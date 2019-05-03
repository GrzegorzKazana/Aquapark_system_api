using System.Collections.Generic;

namespace AquaparkSystemApi.Models.PassedParameters
{
    public class NewOrder
    {
        public string UserToken { get; set; }
        public IEnumerable<NewTicketWithClassDiscount> TicketsWithClassDiscounts { get; set; }
    }
}