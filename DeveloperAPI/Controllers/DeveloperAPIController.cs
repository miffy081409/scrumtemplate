using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DeveloperAPI.Controllers
{
    public class DeveloperAPIController : Controller
    {
        // GET: /<controller>/
        public IActionResult Register()//so that we can have uniform view and no need to create new page every time we add new api
        {
            return View();
        }
    }
}
