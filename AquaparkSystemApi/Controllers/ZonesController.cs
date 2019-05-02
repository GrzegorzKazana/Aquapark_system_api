using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AquaparkSystemApi.Models.Dtos;

namespace AquaparkSystemApi.Controllers
{
    public class ZonesController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public ZonesController()
        {
            _dbContext = new AquaparkDbContext();
        }

        [AcceptVerbs("GET")]
        [ActionName("GetAllZones")]
        public IEnumerable<ZonePrimaryInformationDto> GetAllZones()
        {
            List<ZonePrimaryInformationDto> zones = new List<ZonePrimaryInformationDto>();
            try
            {
                zones = _dbContext.Zones.Select(i => new ZonePrimaryInformationDto()
                {
                    Name = i.Name
                }).ToList();
            }
            catch (Exception)
            {
                return zones;
            }

            return zones;
        }

        [AcceptVerbs("GET")]
        [ActionName("GetAllZonesWithAttractions")]
        public IEnumerable<ZoneWithAttractionsInformationDto> GetAllZonesWithAttractions()
        {
            List<ZoneWithAttractionsInformationDto> zones = new List<ZoneWithAttractionsInformationDto>();
            try
            {
                zones = _dbContext.Zones.Select(i => new ZoneWithAttractionsInformationDto()
                {
                    Name = i.Name,
                    Attractions = _dbContext.Attractions.
                        Where(j=> j.Zone.Id == i.Id).
                        Select(j=> new AttractionPrimaryInformationDto()
                    {
                        Id = j.Id,
                        Name = j.Name
                    })
                }).ToList();
            }
            catch (Exception)
            {
                return zones;
            }

            return zones;
        }
    }
}