using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcesWebApp.Models.Classrooms;
using AcesWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace AcesWebApp.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IClassroomRepository _classRepository;

        public LoginController(IClassroomRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [Route("")]
        public IActionResult Login()
        {
            var classes = _classRepository.GetAllClassrooms().OrderBy(c => c.className);

            var loginViewModel = new LoginViewModel()
            {
                Title = "Login Page",
                Classrooms = classes.ToList()
            };

            return View(loginViewModel);
        }
    }
}