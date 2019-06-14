using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AcesWebApp.Controllers
{
    public class ProfScreenController : Controller
    {
        [Route("ProfScreen")]
        public IActionResult ProfScreen()
        {
            return View();
        }
    }
}