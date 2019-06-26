using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.IO;
using System.Collections.ObjectModel;
using AcesWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;//
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Services;

namespace AcesWebApp.Controllers
{
    public class ProfScreenController : Controller
    {

        private IHostingEnvironment _hostingEnvironment;
        private AssignmentService _assignmentService;

        //public List<Services.ClassRoom> classList;

        public ProfScreenController(IHostingEnvironment environment, AssignmentService assignmentService)
        {
            _hostingEnvironment = environment;
            _assignmentService = assignmentService;
            

        }

        //ObservableCollection<Services.ClassRoom> classList = new ObservableCollection<Services.ClassRoom>();
        //List<Services.ClassRoom> classList2 = new List<Services.ClassRoom>();
        

        [Route("ProfScreen")]
        public IActionResult ProfScreen()
        {
            //classList = new List<Services.ClassRoom>();
            GetClassList();
            //ViewBag.classList = classList;
            //ViewBag.classList2 = new SelectList(classList2, "className", "className");
            return View();
        }

        private IActionResult GetClassList()
        {
            var vm = new ProfScreenModel();

            // create a default path that is only used in the program. 
            //string path = "classlist.csv";
            string path = "C:\\Users\\User\\Desktop\\classlist.csv";

                if (System.IO.File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamReader sr = System.IO.File.OpenText(path))
                    {
                        string currentLine = "";
                        while ((currentLine = sr.ReadLine()) != null && currentLine != "")
                        {
                            string[] items = currentLine.Split(',');
                            vm.classList.Add(new Services.ClassRoom(items[0], items[1], items[2]));
                    }

                    }
                }

            //vm.classList.Add(new Services.ClassRoom("weberstate4450summer2019", "C:\\Users\\User\\Desktop\\classroom_roster1.csv", "4450FinalClassroom"));

            return View(vm);
        }

        [HttpPost]
        public IActionResult Assignments(ProfScreenModel model)
        {
            string instructorUTPath = "";
            ClassRoom classR = null;

            if (ModelState.IsValid)
            {
                if(model.professorUnitTest != null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "instructorUnitTest");
                    instructorUTPath = Path.Combine(uploadFolder, model.assignmentName + "InstructorUnitTest.cpp");
                    model.professorUnitTest.CopyTo(new FileStream(instructorUTPath, FileMode.Create));
                }
            }

            List<Services.ClassRoom> classList = new List<Services.ClassRoom>();
            string path = "C:\\Users\\User\\Desktop\\classlist.csv";

            if (System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamReader sr = System.IO.File.OpenText(path))
                {
                    string currentLine = "";
                    while ((currentLine = sr.ReadLine()) != null && currentLine != "")
                    {
                        string[] items = currentLine.Split(',');
                        classList.Add(new Services.ClassRoom(items[0], items[1], items[2]));
                    }

                }
            }


            foreach (Services.ClassRoom c in classList)
            {
                if (c.Name == model.className)
                {
                    classR = c;
                }
            }

            string studentRepo = Path.Combine(_hostingEnvironment.WebRootPath, "studentRepo");

            //To do: create new assignment service odjecct passing in correct info
            _assignmentService = new AssignmentService(classR, instructorUTPath, model.assignmentName, model.securityKey, studentRepo);
            

            var assignments = _assignmentService.GetAssignment();

            return View(assignments);

            //return View();
        }


    }
}