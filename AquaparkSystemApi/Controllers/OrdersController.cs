using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AquaparkSystemApi.Controllers
{
    public class OrdersController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public OrdersController()
        {
                _dbContext = new AquaparkDbContext();
        }
    }
}
