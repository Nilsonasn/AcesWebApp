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
using Services.Entities;
using AcesWebApp.Models.Classrooms;
using AcesWebApp.Models.Students;
using AcesWebApp.ViewModels;

namespace AcesWebApp.Controllers
{
    public class ProfScreenController : Controller
    {

        private IHostingEnvironment _hostingEnvironment;

        private readonly IClassroomRepository _classroomRepository;
        private readonly IStudentRepository _studentRepository;

        public ProfScreenController(IHostingEnvironment environment, IClassroomRepository classroomRepository, IStudentRepository studentRepository)
        {
            _hostingEnvironment = environment;
            _studentRepository = studentRepository;
            _classroomRepository = classroomRepository;
        }
        

        [Route("ProfScreen")]
        public IActionResult ProfScreen()
        {
            var classes = _classroomRepository.GetAllClassrooms().OrderBy(c => c.className);
            var students = _studentRepository.GetAllStudents().OrderBy(s => s.classId);
            var profScreenViewModel = new ProfScreenViewModel()
            {
                Classrooms = classes.ToList(),
                Students = students.ToList()
                
            };
            return View(profScreenViewModel);
        }

        [Route("ProfScreen")]
        [HttpPost]
        public IActionResult ProfScreen(ProfScreenViewModel profScreenViewModel)
        {
            _classroomRepository.AddClassroom(profScreenViewModel.classroom);
            var classes = _classroomRepository.GetAllClassrooms().OrderBy(c => c.className);
            var students = _studentRepository.GetAllStudents().OrderBy(s => s.classId);
            profScreenViewModel = new ProfScreenViewModel()
            {
                Classrooms = classes.ToList(),
                Students = students.ToList()

            };
            return View(profScreenViewModel);
        }
        
        public IActionResult CreateClass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteClass(ProfScreenViewModel profScreenViewModel)
        {
            _classroomRepository.RemoveClassroomById(int.Parse(profScreenViewModel.ClassDelete));
            return View();
            
        }

        private IActionResult GetClassList(ProfScreenModel vm)
        {
            //var vm = new ProfScreenModel();

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

            if (vm.createClassName != null && vm.createOrgName != null)
            {
                vm.classList.Add(new Services.ClassRoom(vm.createOrgName, "C:\\Users\\User\\Desktop\\classroom_roster1.csv", vm.createClassName));
                vm.createClassName = null;
                vm.createOrgName = null;
            }

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
            //AssignmentService _assignmentService = new AssignmentService(classR, instructorUTPath, model.assignmentName, model.securityKey, studentRepo);

            myAssignmentService.assignService = new AssignmentService(classR, instructorUTPath, model.assignmentName, model.securityKey, studentRepo);
            var assignments = myAssignmentService.assignService.GetAssignment();

            //AssignmentService _assignmentService = new AssignmentService();

            //var assignments = _assignmentService.GetAssignment();
            //model.assignments = _assignmentService.GetAssignment();
            /*
            List<Assignment> assignments = _assignmentService.GetAssignment();
            TempData["assignments"] = _assignmentService.GetAssignment();
            var assign = _assignmentService.GetAssignment();
            */

            //HttpContext.Session["assignments"] = _assignmentService.GetAssignment();
            //_contextAccessor.HttpContext.Session.SetString


            //Session["assignments"] = _assignmentService.GetAssignment();
            return View(assignments);

            //return View();
        }

        public IActionResult StudentDetails(ProfScreenModel model/*, AssignmentService _assignmentService*/)
        {
            //var assignments = TempData["assignments"];
            //List<Assignment> assignment = (List<Assignment>)assignments;
            List<Assignment> assignment = myAssignmentService.assignService.GetAssignment();
            var assign = assignment.ElementAt(model.assingnmentID);

            return View(assign);
        }


    }
}