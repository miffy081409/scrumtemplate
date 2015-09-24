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


        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            try
            {

                var users = this.db.Users.ToList();
                //hide sensitive details
                foreach (var item in users)
                {
                    item.Password = "";
                }

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            try
            {
                User user = null;
                user = this.db.Users.FirstOrDefault(u => u.UserID == id);
                //hide sensitive details
                user.Password = "";
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            try
            {
                //validate data

                this.db.Users.Add(user);
                this.db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/values/5 EDIT
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]User user)
        {
            try
            {
                User userFromDB = null;
                //validate data

                userFromDB = this.db.Users.FirstOrDefault(u => u.UserID == id);

                if (userFromDB == null)
                    return;
                //map details
                userFromDB.Username = user.Username;
                //userFromDB.Username = user.Password; //e enable ba pag update sa password?
                userFromDB.IsScrumMaster = user.IsScrumMaster;
                userFromDB.AddedOn = user.AddedOn;
                this.db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {
                User userFromDB = null;
                //validate data

                userFromDB = this.db.Users.FirstOrDefault(u => u.UserID == id);

                if (userFromDB == null)
                    return;
                //map details
                this.db.Users.Remove(userFromDB);
                this.db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
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
