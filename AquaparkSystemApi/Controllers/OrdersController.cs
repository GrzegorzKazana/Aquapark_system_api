using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AquaparkSystemApi.Exceptions;
using AquaparkSystemApi.Models;
using AquaparkSystemApi.Models.Dtos;
using AquaparkSystemApi.Models.PassedParameters;

namespace AquaparkSystemApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public OrdersController()
        {
                _dbContext = new AquaparkDbContext();
        }

        [AcceptVerbs("POST")]
        [ActionName("MakeNewOrder")]
        public OrderDto MakeNewOrder(NewOrder newOrder)
        {
            bool success = false;
            string status = "Wrong token";
            OrderDto orderDto = new OrderDto()
            {
                Success = success,
                Status = status
            };

            try
            {
                int userId;
                if (newOrder.UserToken == string.Empty || Security.Security.UserTokens.Any(i => i.Value == newOrder.UserToken))
                {
                    User user = null;
                    if (newOrder.UserToken != string.Empty)
                    {
                        userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == newOrder.UserToken).Key;
                        user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                        if (user == null)
                            throw new UserNotFoundException("There is no user with given data.");
                    }
                    

                    Order order = new Order()
                    {
                        DateOfOrder = DateTime.Now,
                        UserData = new UserData()
                        {
                            Email = newOrder.UserData.Email,
                            Name = newOrder.UserData.Name,
                            Surname = newOrder.UserData.Surname
                        }
                    };
                    if (user == null)
                    {
                        _dbContext.Orders.Add(order);
                    }
                    else
                    {
                        user.Orders.Add(order);
                    }

                    List<Position> positionsToOrder = new List<Position>();
                    foreach (var item in newOrder.TicketsWithClassDiscounts)
                    {
                        Position position = new Position()
                        {

                            Number = item.NumberOfTickets,
                            SocialClassDiscount =
                                _dbContext.SocialClassDiscounts.FirstOrDefault(i => i.Id == item.SocialClassDiscountId),
                            Ticket = _dbContext.Tickets.Include(i => i.Zone)
                                .FirstOrDefault(i => i.Id == item.TicketTypeId),
                            PeriodicDiscount = _dbContext.PeriodicDiscounts.FirstOrDefault(i =>
                                i.StartTime >= DateTime.Now &&
                                i.FinishTime <= DateTime.Now),
                            CanBeUsed = true
                        };
                        positionsToOrder.Add(position);
                        order.Positions.Add(position);
                    }

                    _dbContext.SaveChanges();

                    success = true;
                    status = "";
                    orderDto.Status = status;
                    orderDto.Success = success;
                    orderDto.Tickets = positionsToOrder.Select(i => new TicketDto()
                    {
                        Id = i.Id,
                        Number = i.Number,
                        Name = i.Ticket.Name,
                        Price = i.Ticket.Price,
                        Zone = new ZoneWithAttractionsInformationDto()
                        {
                            ZoneId = i.Ticket.Zone.Id,
                            Name = i.Ticket.Zone.Name,
                            Attractions = _dbContext.Attractions.Where(j => j.Zone.Id == i.Ticket.Zone.Id).Select(j =>
                                new AttractionPrimaryInformationDto()
                                {
                                    AttractionId = j.Id,
                                    Name = j.Name
                                })
                        }
                    });
                    orderDto.OrderId = order.Id;
                }
            }
            catch (Exception ex)
            {
                orderDto.Status = ex.Message;
                orderDto.Success = false;
            }

            return orderDto;
        }
    }
}
