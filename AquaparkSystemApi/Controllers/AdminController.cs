using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using AquaparkSystemApi.Exceptions;
using AquaparkSystemApi.Models;
using AquaparkSystemApi.Models.Dtos;
using AquaparkSystemApi.Models.PassedParameters;

namespace AquaparkSystemApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public AdminController()
        {
            _dbContext = new AquaparkDbContext();
        }

        [AcceptVerbs("POST")]
        [ActionName("SendNewsletter")]
        public ResultInfoDto SendNewsletter(EmailPassedParameters emailPassedParameters)
        {
            string status = "";
            bool success = false;
            try
            {
                if (Security.Security.UserTokens.Any(i => i.Value == emailPassedParameters.UserToken))
                {
                    var userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == emailPassedParameters.UserToken).Key;

                    var user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                    if (user == null)
                    {
                        throw new UserNotFoundException("There is no user with given data.");
                    }

                    List<User> users = _dbContext.Users.ToList();

                    foreach (User userToSendEmail in users)
                    {
                        Email.SendEmail(userToSendEmail.Email, emailPassedParameters.Message, "Newsletter");
                    }

                    success = true;
                    status = $"Wysłano do: {users.Count} użytkowników.";
                }
                else
                {
                    throw new Exception("User identification failed.");
                }
            }
            catch (Exception e)
            {
                success = false;
                status = e.Message;
            }

            return new ResultInfoDto()
            {
                Success = success,
                Status = status
            };
        }

    }
}