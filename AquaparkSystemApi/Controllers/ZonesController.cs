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
                    ZoneId = i.Id,
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
                    ZoneId = i.Id,
                    Name = i.Name,
                    Attractions = _dbContext.Attractions.
                        Where(j=> j.Zone.Id == i.Id).
                        Select(j=> new AttractionPrimaryInformationDto()
                    {
                        AttractionId = j.Id,
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

        [AcceptVerbs("GET")]
        [ActionName("GetAllZonesWithTickets")]
        public IEnumerable<ZoneWithTicketsDto> GetAllZonesWithTickets()
        {
            List<ZoneWithTicketsDto> ticketDtos = new List<ZoneWithTicketsDto>();
            try
            {
                ticketDtos = _dbContext.Zones.Select(i => new ZoneWithTicketsDto()
                {
                    ZoneId = i.Id,
                    ZoneName = i.Name,
                    TicketTypes = _dbContext.Tickets.Where(j => j.Zone.Id == i.Id).
                        Select(j =>
                            new TicketWithPeriodDiscountDto()
                            {
                                TicketTypeId = j.Id,
                                Price = j.Price,
                                TicketTypeName = j.Name,
                                StartHour = j.StartHour,
                                EndHour = j.EndHour,
                                Days = j.Days,
                                Months = j.Months,
                                PeriodDiscount = j.PeriodicDiscount.StartTime != null ? new PeriodicDiscountDto()
                                {
                                    FinishTimeDate = j.PeriodicDiscount.FinishTime,
                                    Id = j.PeriodicDiscount.Id,
                                    StartTimeDate = j.PeriodicDiscount.StartTime,
                                    Value = j.PeriodicDiscount.Value
                                } : null
                            })

                }).ToList();
            }
            catch (Exception)
            {
                return ticketDtos;
            }

            return ticketDtos;
        }
    }
}