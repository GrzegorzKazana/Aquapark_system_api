using Newtonsoft.Json;

namespace AquaparkSystemApi.Models.PassedParameters
{
    public class UserToEditPersonalData
    {
        [JsonProperty("userToken")]
        public string UserToken { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}