using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class SocialClassDiscountCollectionDto
    {
        [JsonProperty("userToken")]
        public string UserToken { get; set; }

        [JsonProperty("socialClassDiscounts")]
        public IEnumerable<SocialClassDiscount> SocialClassDiscounts { get; set; }
    }
}