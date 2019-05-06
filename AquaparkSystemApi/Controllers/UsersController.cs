using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AquaparkSystemApi.Exceptions;
using AquaparkSystemApi.Models;
using AquaparkSystemApi.Models.Dtos;
using AquaparkSystemApi.Models.PassedParameters;

namespace AquaparkSystemApi.Controllers
{
    public class UsersController : ApiController
    {
        private AquaparkDbContext _dbContext;

        public UsersController()
        {
            _dbContext = new AquaparkDbContext();
        }
        
        [AcceptVerbs("POST")]
        [ActionName("RegisterUser")]
        public UserRegisteredDto RegisterUser(UserToRegister userToRegister)
        {
            Guid userGuid = Guid.NewGuid();
            string hashedPassword = Security.Security.HashSHA1(userToRegister.Password + userGuid.ToString());
            string statusMessage = "";
            bool wasUserAdded = false;

            bool doesUserWithGivenLoginExist = _dbContext.Users.Any(i => i.Login == userToRegister.Login 
            || i.Email == userToRegister.Email );
            if (!doesUserWithGivenLoginExist)
            {
                _dbContext.Users.Add(
                    new User()
                    {
                        Login = userToRegister.Login,
                        Name = userToRegister.Name,
                        Surname = userToRegister.Surname,
                        Password = hashedPassword,
                        UserGuid = userGuid,
                        Email = userToRegister.Email,
                        IsAdmin = false,
                    });
                _dbContext.SaveChanges();
                wasUserAdded = true;
            }
            else
            {
                statusMessage = "There is a user with given login or email.";
            }

            return new UserRegisteredDto()
            {
                Success = wasUserAdded,
                Status = statusMessage
            };
        }

        [AcceptVerbs("POST")]
        [ActionName("LogIn")]
        public UserLoggedInDto LogIn(UserToLogIn userToLogIn)
        {
            string userToken = "";
            string name = "";
            string surname = "";
            bool success = false;
            string statusMessage = "";
            bool isAdmin = false;

            try
            {
                User user = _dbContext.Users.FirstOrDefault(i => i.Email == userToLogIn.Email);
                if (user == null)
                    throw new UserNotFoundException("There is no user with given data.");

                string hashedPassword = Security.Security.HashSHA1(userToLogIn.Password + user.UserGuid);

                if (user.Password.Trim() == hashedPassword)
                {
                    string generatedToken = Security.Security.GenerateToken(user.Email);
                    if (Security.Security.UserTokens.All(i => i.Key != user.Id))
                    {
                        Security.Security.UserTokens.Add(user.Id, generatedToken);
                        userToken = generatedToken;
                        name = user.Name;
                        surname = user.Surname;
                        success = true;
                        statusMessage = "";
                        isAdmin = user.IsAdmin;
                    }
                }
            }
            catch (Exception e)
            {
                userToken = name = surname = "";
                success = false;
                statusMessage = e.Message;
            }

            return new UserLoggedInDto()
            {
                UserToken = userToken,
                Name = name,
                Surname = surname,
                Success = success,
                Status = statusMessage,
                IsAdmin = isAdmin
            };
        }

        [AcceptVerbs("POST")]
        [ActionName("EditUser")]
        public UserEditedPersonalDataDto EditUser(UserToEditPersonalData editedUser)
        {
            string userToken = "";
            string name = "";
            string surname = "";
            string email = "";
            bool success = false;
            string statusMessage = "";

            try
            {
                int userId;
                if (Security.Security.UserTokens.Any(i => i.Value == editedUser.UserToken))
                {
                    userId = Security.Security.UserTokens.FirstOrDefault(i => i.Value == editedUser.UserToken).Key;

                    User user = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
                    if (user == null)
                        throw new UserNotFoundException("There is no user with given data.");

                    _dbContext.Entry(user).State = EntityState.Modified;
                    email = user.Email = editedUser.Email;
                    name = user.Name = editedUser.Name;
                    surname = user.Surname = editedUser.Surname;
                    userToken = editedUser.UserToken;
                    success = true;
                    statusMessage = "";
                }
                else
                {
                    throw new Exception("User identification failed.");
                }
                    
            }
            catch (Exception e)
            {
                userToken = name = surname = "";
                success = false;
                statusMessage = e.Message;
            }

            return new UserEditedPersonalDataDto()
            {
                UserToken = userToken,
                Name = name,
                Surname = surname,
                Email = email,
                Success = success,
                Status = statusMessage
            };
        }
    }
}
