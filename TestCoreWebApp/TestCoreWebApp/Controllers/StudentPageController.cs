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
                string fileName = null;

                //creates the needed directory if it doesn't exist
                System.IO.Directory.CreateDirectory(hostingEnvironment.WebRootPath + @"/" + "studentCode");

                if (model.StudentUnitTest != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    fileName = model.StudentUnitTest.FileName;  //Guid.NewGuid().ToString() + "_" + model.StudentUnitTest.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    model.StudentUnitTest.CopyTo(new FileStream(filePath, FileMode.Create));

                }

                if (model.StudentProgramFiles != null)
                {
                    foreach (IFormFile studentFile in model.StudentProgramFiles)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                        fileName = studentFile.FileName;  //Guid.NewGuid().ToString() + "_" + studentFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, fileName);
                        studentFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    }               

                }

               if(model.StudentProgramCode != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    fileName = "StudentProgram.cpp";   //Guid.NewGuid().ToString() + "_StudentCode.cpp";
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (System.IO.StreamWriter file = new StreamWriter(System.IO.File.Create(filePath)))
                    {
                        file.WriteLine(model.StudentProgramCode.ToString());
                    }                    
                }

                if (model.StudentUnitCode != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    fileName = "StudentUnitTests.cpp";   //Guid.NewGuid().ToString() + "_StudentCode.cpp";
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (System.IO.StreamWriter file = new StreamWriter(System.IO.File.Create(filePath)))
                    {
                        file.WriteLine(model.StudentUnitCode.ToString());
                    }
                }

            }            

            return View();
        }


    }
}