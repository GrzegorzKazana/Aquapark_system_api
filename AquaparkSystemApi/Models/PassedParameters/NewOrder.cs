using System.Collections.Generic;
using AquaparkSystemApi.Models.Dtos;
using Newtonsoft.Json;

namespace AquaparkSystemApi.Models.PassedParameters
{
    public class NewOrder
    {
        [JsonProperty("userToken")]
        public string UserToken { get; set; }

        [JsonProperty("userData")]
        public UserDataDto UserData { get; set; }
        [JsonProperty("ticketsWithClassDiscounts")]
        public IEnumerable<NewTicketWithClassDiscount> TicketsWithClassDiscounts { get; set; }

    }
}