using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace AcesWebApp.Controllers
{
    public class LoginController : Controller
    {

        private IUserData userData;

        [Route("")]
        public IActionResult Login(IUserData userData)
        {
            this.userData = userData;
            return View();
        }
    }
}