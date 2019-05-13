using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
        public IEnumerable<SocialClassDiscountDto> AddSocialClassDiscounts(IEnumerable<SocialClassDiscount> socialClassDiscounts)
        {
            try
            {
                _dbContext.Positions.ToList().ForEach(x => x.SocialClassDiscount = null);

                _dbContext.SaveChanges();

                _dbContext.SocialClassDiscounts.RemoveRange(_dbContext.SocialClassDiscounts);
                _dbContext.SocialClassDiscounts.AddRange(socialClassDiscounts);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return this.GetAllSocialClassDiscounts();
            }

            return this.GetAllSocialClassDiscounts();
        }

        [AcceptVerbs("POST")]
        [ActionName("AddPeriodicDiscounts")]
        public IEnumerable<PeriodicDiscountDto> AddPeriodicDiscounts(IEnumerable<PeriodicDiscount> periodicDiscounts)
        {
            try
            {
                _dbContext.Tickets.ToList().ForEach(x => x.PeriodicDiscount = null);
                _dbContext.Positions.ToList().ForEach(x => x.PeriodicDiscount = null);
                _dbContext.SaveChanges();

                _dbContext.PeriodicDiscounts.RemoveRange(_dbContext.PeriodicDiscounts);
                _dbContext.PeriodicDiscounts.AddRange(periodicDiscounts);
                _dbContext.SaveChanges();
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
