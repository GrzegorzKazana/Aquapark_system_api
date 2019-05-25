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
                if (Security.Security.UserTokens.Any(i => i.Value == zoneEntry.UserToken) || zoneEntry.UserToken == string.Empty)
                {
                    List<Position> userPositions = new List<Position>();
                    int userId = -1;
                    if (zoneEntry.UserToken != string.Empty)
                    {
                        userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == zoneEntry.UserToken).Key;
                        var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                        if (user == null)
                        {
                            throw new UserNotFoundException("There is no user with given data.");
                        }

                        userPositions = _dbContext.Orders.Where(i => i.User.Id == userId).SelectMany(i => i.Positions)
                            .ToList();
                    }
                    else
                    {
                        var asd = _dbContext.Orders.Where(i => i.UserData.Email == zoneEntry.Email).ToList();
                        userPositions = _dbContext.Orders.Where(i => i.UserData.Email == zoneEntry.Email)
                            .SelectMany(i => i.Positions).ToList();
                    }
                    
                    
                    
                }
                else
                {
                    throw new Exception("User identification failed.");
                }
            }
            catch (Exception)
            {
                
            }

            
        }
    }
}
