using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DeveloperAPI.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ScrumDataContext db;

        public HomeController(ScrumDataContext dbContext)
        {
            db = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        { 
            ViewData["Test"] = db.Attachments.Count();
            return View();
        }
    }
}
