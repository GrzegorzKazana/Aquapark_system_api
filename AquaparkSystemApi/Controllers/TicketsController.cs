using AquaparkSystemApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AquaparkSystemApi.Controllers
{
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
            List<TicketDto> ticketDtos = new List<TicketDto>();
            try
            {
                ticketDtos = _dbContext.Tickets.Select(i => new TicketDto()
                {
                    Id = i.Id,
                    Number = i.Number,
                    Name = i.Name,
                    Price = i.Price,
                    Zone = new ZoneWithAttractionsInformationDto()
                        {
                            Name = i.Zone.Name,
                            Attractions = _dbContext.Attractions.Where(j => j.Zone.Id == i.Zone.Id).
                                Select(j =>
                                new AttractionPrimaryInformationDto()
                                {
                                    Id = j.Id,
                                    Name = j.Name
                                })
                        },
                    TicketType = new TicketTypeDto()
                    {
                        Id = i.TicketType.Id,
                        Name = i.TicketType.Name
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
