using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AquaparkSystemApi.Models;
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

        [AcceptVerbs("POST")]
        [ActionName("AddZonesWithTickets")]
        public IEnumerable<ZoneWithTicketsDto> AddZonesWithTickets(IEnumerable<ZoneWithTicketsDto> zonesWithTickets)
        {
            try
            {
                // remove Zone references

                _dbContext.Attractions.ToList().ForEach(x => x.Zone = null);
                _dbContext.ZoneHistories.ToList().ForEach(x => x.Zone = null);
                _dbContext.Tickets.ToList().ForEach(x => x.Zone = null);
                _dbContext.SaveChanges();

                // remove Ticket references

                _dbContext.Positions.ToList().ForEach(x => x.Ticket = null);
                _dbContext.SaveChanges();

                // remove all records from Zone and Ticket table

                _dbContext.Zones.RemoveRange(_dbContext.Zones);
                _dbContext.Tickets.RemoveRange(_dbContext.Tickets);
                _dbContext.SaveChanges();

                // Add new records to Zone table

                var zones = zonesWithTickets.Select(x => new Zone()
                {
                    Name = x.ZoneName
                });
                _dbContext.Zones.AddRange(zones);
                _dbContext.SaveChanges();

                // Add new records to Ticket table

                var tickets = new List<Ticket>();
                zonesWithTickets
                    .ToList()
                    .ForEach(z => z.TicketTypes
                        .ToList()
                        .ForEach(t => tickets.Add(new Ticket()
                        {
                            Name = t.TicketTypeName,
                            Price = t.Price,
                            Zone = _dbContext.Zones
                                    .Where(j => j.Name == z.ZoneName)
                                    .FirstOrDefault()
                                    ?? new Zone()
                                    {
                                        Name = z.ZoneName
                                    },
                            PeriodicDiscount = t.PeriodDiscount == null
                                ? null : new PeriodicDiscount()
                                {
                                    StartTime = t.PeriodDiscount.StartTimeDate,
                                    FinishTime = t.PeriodDiscount.FinishTimeDate,
                                    Value = t.PeriodDiscount.Value
                                },
                            StartHour = t.StartHour,
                            EndHour = t.EndHour,
                            Days = t.Days,
                            Months = t.Months
                        })
                        ));
                _dbContext.Tickets.AddRange(tickets);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return this.GetAllZonesWithTickets();
            }

            return this.GetAllZonesWithTickets();
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
                        Where(j => j.Zone.Id == i.Id).
                        Select(j => new AttractionPrimaryInformationDto()
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