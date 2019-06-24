using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AcesWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcesWebApp.Controllers
{
    public class StudentPageController : Controller
    {
        private IHostingEnvironment hostingEnvironment;

        public StudentPageController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("StudentPage")]
        public IActionResult StudentPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Results(StudentPageModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                //creates the needed directory if it doesn't exist
                System.IO.Directory.CreateDirectory(hostingEnvironment.WebRootPath + @"/" + "studentCode");

                if (model.StudentUnitTest != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.StudentUnitTest.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.StudentUnitTest.CopyTo(new FileStream(filePath, FileMode.Create));

                }

                if (model.StudentProgramFiles != null)
                {
                    foreach (IFormFile studentFile in model.StudentProgramFiles)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + studentFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        studentFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    }               

                }

            }            

            return View();
        }


    }
}