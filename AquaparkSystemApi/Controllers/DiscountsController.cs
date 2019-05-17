using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AquaparkSystemApi.Exceptions;
using AquaparkSystemApi.Models;
using AquaparkSystemApi.Models.Dtos;

namespace AquaparkSystemApi.Controllers
{
    public class DiscountsController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public DiscountsController()
        {
            _dbContext = new AquaparkDbContext();
        }

        [AcceptVerbs("POST")]
        [ActionName("AddSocialClassDiscounts")]
        public IEnumerable<SocialClassDiscountDto> AddSocialClassDiscounts(SocialClassDiscountCollectionDto socialClassDiscountCollectionDto)
        {
            var socialClassDiscounts = socialClassDiscountCollectionDto.SocialClassDiscounts;

            try
            {
                if (Security.Security.UserTokens.Any(i => i.Value == socialClassDiscountCollectionDto.UserToken))
                {
                    var userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == socialClassDiscountCollectionDto.UserToken).Key;

                    var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                    if (user == null)
                    {
                        throw new UserNotFoundException("There is no user with given data.");
                    }

                    _dbContext.Positions.ToList().ForEach(x => x.SocialClassDiscount = null);

                    _dbContext.SaveChanges();

                    _dbContext.SocialClassDiscounts.RemoveRange(_dbContext.SocialClassDiscounts);
                    _dbContext.SocialClassDiscounts.AddRange(socialClassDiscounts);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User identification failed.");
                }
            }
            catch (Exception)
            {
                return this.GetAllSocialClassDiscounts();
            }

            return this.GetAllSocialClassDiscounts();
        }

        [AcceptVerbs("POST")]
        [ActionName("AddPeriodicDiscounts")]
        public IEnumerable<PeriodicDiscountDto> AddPeriodicDiscounts(PeriodicDiscountCollectionDto periodicDiscountCollectionDto)
        {
            var periodicDiscounts = periodicDiscountCollectionDto.PeriodicDiscounts;

            try
            {
                if (Security.Security.UserTokens.Any(i => i.Value == periodicDiscountCollectionDto.UserToken))
                {
                    var userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == periodicDiscountCollectionDto.UserToken).Key;

                    var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                    if (user == null)
                    {
                        throw new UserNotFoundException("There is no user with given data.");
                    }

                    _dbContext.Tickets.ToList().ForEach(x => x.PeriodicDiscount = null);
                    _dbContext.Positions.ToList().ForEach(x => x.PeriodicDiscount = null);
                    _dbContext.SaveChanges();

                    _dbContext.PeriodicDiscounts.RemoveRange(_dbContext.PeriodicDiscounts);
                    _dbContext.PeriodicDiscounts.AddRange(periodicDiscounts);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User identification failed.");
                }
            }
            catch (Exception)
            {
                return this.GetAllPeriodicDiscount();
            }

            return this.GetAllPeriodicDiscount();
        }

        [AcceptVerbs("GET")]
        [ActionName("GetAllPeriodicDiscount")]
        public IEnumerable<PeriodicDiscountDto> GetAllPeriodicDiscount()
        {
            List<PeriodicDiscountDto> periodicDiscountDtos = new List<PeriodicDiscountDto>();
            try
            {
                periodicDiscountDtos = _dbContext.PeriodicDiscounts.Select(i => new PeriodicDiscountDto()
                {
                    Id = i.Id,
                    StartTimeDate = i.StartTime,
                    FinishTimeDate = i.FinishTime,
                    Value = i.Value
                }).ToList();
            }
            catch (Exception)
            {
                return periodicDiscountDtos;
            }

            return periodicDiscountDtos;
        }

        [AcceptVerbs("GET")]
        [ActionName("GetAllSocialClassDiscounts")]
        public IEnumerable<SocialClassDiscountDto> GetAllSocialClassDiscounts()
        {
            List<SocialClassDiscountDto> socialClassDiscountDtos = new List<SocialClassDiscountDto>();
            try
            {
                socialClassDiscountDtos = _dbContext.SocialClassDiscounts.Select(i => new SocialClassDiscountDto()
                {
                    Id = i.Id,
                    SocialClassName = i.SocialClassName,
                    Value = i.Value
                }).ToList();
            }
            catch (Exception)
            {
                return socialClassDiscountDtos;
            }

            return socialClassDiscountDtos;
        }
    }
}
