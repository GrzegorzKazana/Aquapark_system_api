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
        [ActionName("ComeInToZone")]
        public void ComeInTooZone(ZoneEntry zoneEntry)
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
                    positionAvailableForZone.CanBeUsed = false;

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

        [AcceptVerbs("POST")]
        [ActionName("ComeOutOfZone")]
        public void ComeOutOfZone(ZoneEntry zoneEntry)
        {

            try
            {

                if (Security.Security.UserTokens.Any(i => i.Value == zoneEntry.UserToken) || zoneEntry.UserToken == string.Empty)
                {
                    ZoneHistory positionAvailableForZone;
                    int userId = -1;
                    if (zoneEntry.UserToken != string.Empty)
                    {
                        userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == zoneEntry.UserToken).Key;
                        var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                        if (user == null)
                        {
                            throw new UserNotFoundException("There is no user with given data.");
                        }

                        positionAvailableForZone = _dbContext.Orders.Where(i => i.User.Id == userId)
                            .SelectMany(
                                i => i.Positions.Where(j => j.Ticket.Zone.Id == zoneEntry.ZoneId && !j.CanBeUsed)).SelectMany(i => i.ZoneHistories.Where(k => k.FinishTime == null))
                            .FirstOrDefault();
                    }
                    else
                    {
                        positionAvailableForZone = _dbContext.Orders.Where(i => i.UserData.Email == zoneEntry.Email)
                            .SelectMany(
                                i => i.Positions.Where(j => j.Ticket.Zone.Id == zoneEntry.ZoneId && !j.CanBeUsed )).SelectMany(i => i.ZoneHistories.Where(k => k.FinishTime == null))
                            .FirstOrDefault();
                    }
                    positionAvailableForZone.FinishTime = DateTime.Now;
                    
                    // sprawdź czy pozycja jest już zużyta i jeśli tak to wyzeruj ją na false (czyli zostaw) lub jeśli 
                    // będzie mogła być jeszcze użyta to zmień ją na true
                    /// przeszukaj również wszystkie atrakcje i je też pozamykaj?? (dodatkowe zabezpieczenie po prostu)

                    //_dbContext.ZoneHistories.Add(new ZoneHistory()
                    //{
                    //    Position = positionAvailableForZone,
                    //    StartTime = DateTime.Now,
                    //    Zone = _dbContext.Zones.FirstOrDefault(i => i.Id == zoneEntry.ZoneId)
                    //});
                    //positionAvailableForZone.CanBeUsed = false;

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

        //[AcceptVerbs("POST")]
        //[ActionName("ComeInToAttraction")]
        //public void ComeInToAttraction(ZoneEntry zoneEntry)
        //{

        //    try
        //    {
        //        double currentHour = DateTime.Now.Hour;
        //        double currentMinute = DateTime.Now.Minute;
        //        if (currentMinute > 0)
        //            currentHour += 1;
        //        currentHour %= 24;

        //        if (Security.Security.UserTokens.Any(i => i.Value == zoneEntry.UserToken) || zoneEntry.UserToken == string.Empty)
        //        {
        //            Position positionAvailableForZone;
        //            int userId = -1;
        //            if (zoneEntry.UserToken != string.Empty)
        //            {
        //                userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == zoneEntry.UserToken).Key;
        //                var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
        //                if (user == null)
        //                {
        //                    throw new UserNotFoundException("There is no user with given data.");
        //                }

        //                positionAvailableForZone = _dbContext.Orders.Where(i => i.User.Id == userId).
        //                    SelectMany(i => i.Positions.Where(j => j.Ticket.Zone.Id == zoneEntry.ZoneId && j.CanBeUsed &&
        //                                                           j.Ticket.StartHour <= currentHour && j.Ticket.EndHour >= currentHour))
        //                    .FirstOrDefault();
        //            }
        //            else
        //            {
        //                positionAvailableForZone = _dbContext.Orders.Where(i => i.UserData.Email == zoneEntry.Email)
        //                    .SelectMany(
        //                        i => i.Positions.Where(j => j.Ticket.Zone.Id == zoneEntry.ZoneId && j.CanBeUsed &&
        //                                                    j.Ticket.StartHour <= currentHour && j.Ticket.EndHour >= currentHour))
        //                    .FirstOrDefault();
        //            }


        //            _dbContext.ZoneHistories.Add(new ZoneHistory()
        //            {
        //                Position = positionAvailableForZone,
        //                StartTime = DateTime.Now,
        //                Zone = _dbContext.Zones.FirstOrDefault(i => i.Id == zoneEntry.ZoneId)
        //            });
        //            positionAvailableForZone.CanBeUsed = false;

        //            _dbContext.SaveChanges();
        //        }
        //        else
        //        {
        //            throw new Exception("User identification failed.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //}
    }
}
