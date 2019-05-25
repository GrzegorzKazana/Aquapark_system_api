using AquaparkSystemApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AquaparkSystemApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TicketsController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public TicketsController()
        {
            _dbContext = new AquaparkDbContext();
        }

        [AcceptVerbs("GET")]
        [ActionName("GetAllTickets")]
        public IEnumerable<TicketDto> GetAllTickets()
        {
                foreach (var entity in _dbContext.ChangeTracker.Entries())
                {
                    entity.Reload();
                }
            List<TicketDto> ticketDtos = new List<TicketDto>();
            try
            {
                ticketDtos = _dbContext.Tickets.Select(i => new TicketDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    StartHour = i.StartHour,
                    EndHour = i.EndHour,
                    Days = i.Days,
                    Months = i.Months,
                    Zone = new ZoneWithAttractionsInformationDto()
                        {
                            ZoneId = i.Zone.Id,
                            Name = i.Zone.Name,
                            Attractions = _dbContext.Attractions.Where(j => j.Zone.Id == i.Zone.Id).
                                Select(j =>
                                new AttractionPrimaryInformationDto()
                                {
                                    AttractionId = j.Id,
                                    Name = j.Name
                                })
                        }

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
