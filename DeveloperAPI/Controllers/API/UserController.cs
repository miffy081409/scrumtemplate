using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DeveloperAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperAPI.Controllers.API
{
    //yo jick lets use scrum-template as our prefix in out api..so that it wont confuse the routing in the developerapi registration
    [Route("scrum-template/api/[controller]")]
    public class UserController : Controller
    {
        private readonly ScrumDataContext db;

        public UserController(ScrumDataContext dbContext)
        {
            this.db = dbContext;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        //returns token
        [HttpPost("authenticate")]
        public Models.CustomResponse.Authentication Authenticate(string username, string password)
        {
            try
            {
                DeveloperAPI.Models.User user = null;

                //fetch data
                user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                //throw 400 bad request 
                if (user == null)
                    return null; // TODO: return 

                //generate new session token on db
                UserSession session = new UserSession();
                session.Token = new Guid().ToString();
                session.AddedOn = DateTime.Now;
                session.Expiration = DateTime.Now.AddHours(6);
                session.UserID = user.UserID;

                db.UserSessions.Add(session);
                db.SaveChanges();

                return new Models.CustomResponse.Authentication() { Token = session.Token };
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
