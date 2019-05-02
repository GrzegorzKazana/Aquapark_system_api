using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Web;
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
                //if (Security.Security.UserTokens.Any(i => i.Value == userToken))
                //{
                    zones = _dbContext.Zones.Select(i => new ZonePrimaryInformationDto()
                    {
                        //do your variable mapping here 
                        Name = i.Name
                    }).ToList();
                //}
            }
            catch (Exception ex)
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
                //if (Security.Security.UserTokens.Any(i => i.Value == userToken))
                //{
                zones = _dbContext.Zones.Select(i => new ZoneWithAttractionsInformationDto()
                {
                    //do your variable mapping here 
                    Name = i.Name,
                    Attractions = _dbContext.Attractions.
                        Where(j=> j.Zone.Id == i.Id).
                        Select(j=> new AttractionPrimaryInformationDto()
                    {
                        Id = j.Id,
                        Name = j.Name
                    })
                }).ToList();
                //}
            }
            catch (Exception)
            {
                return zones;
            }

            return zones;
        }
    }
}