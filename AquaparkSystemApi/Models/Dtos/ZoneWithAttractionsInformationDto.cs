using System.Collections.Generic;

namespace AquaparkSystemApi.Models.Dtos
{
    public class ZoneWithAttractionsInformationDto
    {
        public string Name { get; set; }
        public IEnumerable<AttractionPrimaryInformationDto> Attractions { get; set; }
    }
}