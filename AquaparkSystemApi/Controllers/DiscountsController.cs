using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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

        [AcceptVerbs("GET")]
        [ActionName("GetAllPeriodicDoscunts")]
        public IEnumerable<PeriodicDiscountDto> GetAllPeriodicDoscunts()
        {
            List<PeriodicDiscountDto> periodicDiscountDtos = new List<PeriodicDiscountDto>();
            try
            {
                periodicDiscountDtos = _dbContext.PeriodicDiscounts.Select(i => new PeriodicDiscountDto()
                {
                     Id = i.Id,
                     StartTime = i.StartTime.ToString("yyyy-MM-dd;HH-mm"),
                     FinishTime = i.FinishTime.ToString("yyyy-MM-dd;HH-mm"),
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
