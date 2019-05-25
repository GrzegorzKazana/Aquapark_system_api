using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AquaparkSystemApi.Exceptions;
using AquaparkSystemApi.Models;
using AquaparkSystemApi.Models.Dtos;
using AquaparkSystemApi.Models.PassedParameters;

namespace AquaparkSystemApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntriesController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public EntriesController()
        {
            _dbContext = new AquaparkDbContext();
        }
        [AcceptVerbs("POST")]
        [ActionName("NoticeNewZoneEntry")]
        public void NoticeNewZoneEntry(ZoneEntry zoneEntry)
        {

            try
            {
                double currentHour = DateTime.Now.Hour;
                double currentMinute = DateTime.Now.Minute;
                if (currentMinute > 0)
                    currentHour += 1;
                currentHour %= 24;

                if (Security.Security.UserTokens.Any(i => i.Value == zoneEntry.UserToken) || zoneEntry.UserToken == string.Empty)
                {
                    Position positionAvailableForZone;
                    int userId = -1;
                    if (zoneEntry.UserToken != string.Empty)
                    {
                        userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == zoneEntry.UserToken).Key;
                        var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                        if (user == null)
                        {
                            throw new UserNotFoundException("There is no user with given data.");
                        }

                        positionAvailableForZone = _dbContext.Orders.Where(i => i.User.Id == userId).
                            SelectMany(i => i.Positions.Where(j => j.Ticket.Zone.Id == zoneEntry.ZoneId && j.CanBeUsed &&
                                                                   j.Ticket.StartHour <= currentHour && j.Ticket.EndHour >= currentHour))
                            .FirstOrDefault();
                    }
                    else
                    {
                        positionAvailableForZone = _dbContext.Orders.Where(i => i.UserData.Email == zoneEntry.Email)
                            .SelectMany(
                                i => i.Positions.Where(j => j.Ticket.Zone.Id == zoneEntry.ZoneId && j.CanBeUsed && 
                                                            j.Ticket.StartHour <= currentHour && j.Ticket.EndHour >= currentHour))
                            .FirstOrDefault();
                    }


                    _dbContext.ZoneHistories.Add(new ZoneHistory()
                    {
                        Position = positionAvailableForZone,
                        StartTime = DateTime.Now,
                        Zone = _dbContext.Zones.FirstOrDefault(i=> i.Id == zoneEntry.ZoneId)
                    });

                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User identification failed.");
                }
            }
            catch (Exception ex)
            {
                
            }

            
        }
    }
}
