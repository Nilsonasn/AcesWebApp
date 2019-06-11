using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AcesWebApp.Controllers
{
    public class LoginController : Controller
    {
        [Route("")]
        public IActionResult Login()
        {
            return View();
        }
    }
}