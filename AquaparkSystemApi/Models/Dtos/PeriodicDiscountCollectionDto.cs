using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class PeriodicDiscountCollectionDto
    {
        [JsonProperty("userToken")]
        public string UserToken { get; set; }

        [JsonProperty("periodicDiscounts")]
        public IEnumerable<PeriodicDiscount> PeriodicDiscounts { get; set; }
    }
}