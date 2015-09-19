using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DeveloperAPI.Models;
using static System.Threading.Tasks.Task;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperAPI.Controllers.API
{
    [Route("scrum-template/api/documentation")]
    public class APIDocumentationController : Controller
    {
        private readonly ScrumDataContext db;

        public APIDocumentationController(ScrumDataContext dbContext)
        {
            this.db = dbContext;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<APIDocumentation>> Get()
        {
            return await Run<IEnumerable<APIDocumentation>>(()=> {
                //var list = new List<APIDocumentation>();
                //list.Add(new APIDocumentation() { ID = "1", Name = "Test API From Service 1", Description = "Lorem goes here" });
                //list.Add(new APIDocumentation() { ID = "2", Name = "Test API From Service 2", Description = "Lorem goes here" });
                //return list;
                return this.db.APIDocumentations.ToList();
            });
        }

        //convert this to async
        [HttpGet("{id}")]
        public async Task<APIDocumentation> Get(int id)
        {
            return await Run<APIDocumentation>(() => {
                return this.db.APIDocumentations.ToList().FirstOrDefault(x => x.ID == id.ToString());
            });
        }

        //custom query
        [HttpGet("{q}/{value}")]
        public string Get(string q, string value)
        {
            switch (q.ToLower())
            {
                case "top":
                    var top = int.Parse(value);
                    return $"show top {top} here.";

                case "latest":
                    var latest = int.Parse(value);
                    return $"show latest {latest} here.";
            }

            return "value";
        }

        // POST api/values
        [HttpPost]
        public async System.Threading.Tasks.Task Post([FromBody]APIDocumentation value)
        {
            //validate model here
            
            //this.db.Add(value);
            //await this.db.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new Exception("Unavailable Service");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new Exception("Unavailable Service");
        }
    }
}
