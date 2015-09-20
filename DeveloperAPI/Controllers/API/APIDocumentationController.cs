using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DeveloperAPI.Models;
using Microsoft.Data.Entity;

using static System.Threading.Tasks.Task;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperAPI.Controllers.API
{
    [Route("scrum-template/api/documentation/")]
    public class APIDocumentationController : Controller
    {
        private ScrumDataContext db;

        public APIDocumentationController(ScrumDataContext dbContext)
        {
            db = dbContext;
        }


        //custom query
        [HttpGet("{q}/{value}")]
        public async Task<IEnumerable<APIDocumentation>> Get(string q, string value)
        {
            var list = new List<APIDocumentation>();

            await Run(() =>
            {
                switch (q.ToLower())
                {
                    case "top":
                        var top = int.Parse(value);
                        list = db.APIDocumentations.Take(top).ToList();
                        break;

                    case "latest":
                        var latest = int.Parse(value);
                        list = (from x in db.APIDocumentations orderby x.AddedOn descending select x).Take(latest).ToList();
                        break;

                    case "single":
                        var id = int.Parse(value);
                        var entity = db.APIDocumentations.FirstOrDefault(x => x.ID == id);

                        if (entity != null)
                        {
                            list.Add(entity);
                        }
                        break;

                    case "search":
                        list = (from x in db.APIDocumentations where x.Name.ToLower().Contains(value.ToLower()) || x.Description.ToLower().Contains(value.ToLower()) select x).ToList();
                        break;
                }
            });
            
            return list;
        }
        
        [HttpPost]
        public async System.Threading.Tasks.Task<object> Post([FromBody]APIDocumentation value)
        {
            try
            {
                //validate model here
                if (string.IsNullOrWhiteSpace(value.Name))
                {
                    return new { Message = "Provide your API name.", Validation = "Failed" };
                }

                if (string.IsNullOrWhiteSpace(value.Url))
                {
                    return new { Message = "Provide your API url.", Validation = "Failed" };
                }

                if (string.IsNullOrWhiteSpace(value.Description))
                {
                    return new { Message = "A description is needed to describe how your API behave.", Validation = "Failed" };
                }

                if (string.IsNullOrWhiteSpace(value.SampleImplementation))
                {
                    return new { Message = "A sample implementation is need to guide your consumer.", Validation = "Failed" };
                }

                var entity = new APIDocumentation();
                entity.Name = value.Name;
                entity.Url = value.Url;
                entity.Description = value.Description;
                entity.SampleImplementation = value.SampleImplementation;
                entity.UserID = value.UserID;

                db.APIDocumentations.Add(entity);
                await db.SaveChangesAsync();

                return new { Message = "", Validation = "Success" };
            }
            catch (Exception ex)
            {
                throw;
            }
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
