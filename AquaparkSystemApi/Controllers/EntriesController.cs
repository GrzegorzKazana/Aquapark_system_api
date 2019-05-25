using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AquaparkSystemApi.Exceptions;
using AquaparkSystemApi.Models;
using AquaparkSystemApi.Models.Dtos;

namespace AquaparkSystemApi.Controllers
{
    public class EntriesController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public EntriesController()
        {
            _dbContext = new AquaparkDbContext();
        }
        [AcceptVerbs("POST")]
        [ActionName("AddZonesWithTickets")]
        public void NoticeNewZoneEntry(ZoneWithTicketsCollectionDto zoneWithTicketsCollectionDto)
        {

            try
            {
                if (Security.Security.UserTokens.Any(i => i.Value == zoneWithTicketsCollectionDto.UserToken))
                {
                    var userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == zoneWithTicketsCollectionDto.UserToken).Key;

                    var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                    if (user == null)
                    {
                        throw new UserNotFoundException("There is no user with given data.");
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
