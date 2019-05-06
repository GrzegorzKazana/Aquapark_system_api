using System.Collections.Generic;

namespace AquaparkSystemApi.Models.Dtos
{
    public class ZoneWithAttractionsInformationDto
    {
        public int ZoneId { get; set; }
        public string Name { get; set; }
        public IEnumerable<AttractionPrimaryInformationDto> Attractions { get; set; }
    }
}