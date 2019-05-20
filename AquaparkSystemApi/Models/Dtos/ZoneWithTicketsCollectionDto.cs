using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class ZoneWithTicketsCollectionDto
    {
        [JsonProperty("userToken")]
        public string UserToken { get; set; }

        [JsonProperty("zonesWithTicketsDto")]
        public IEnumerable<ZoneWithTicketsDto> ZonesWithTicketsDto { get; set; }
    }
}