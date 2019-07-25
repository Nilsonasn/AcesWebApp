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
            List<string> roster = new List<string>();
            if (profScreenViewModel.roster != null)
            {
               roster = iformreader.ReadAsList(profScreenViewModel.roster);
            }
            foreach (string input in roster)
            {
                if (input != "\"identifier\",\"github_username\",\"github_id\",\"name\"")
                {
                    string[] line = input.Split(',');

                    // only input students that have connected to github classroom 
                    if (line[1].Trim('"') != "")
                    {
                        // get the student username and id set by the teacher. 
                        if (line[3].Trim('"') == "")
                        {
                            // Students.Add(new Student(line[0].Trim('"'), line[1].Trim('"'), line[0].Trim('"')));
                            Models.Students.Student student = new Models.Students.Student()
                            {
                                githubEmail = line[0].Trim('"'),
                                githubUrsName = line[1].Trim('"'),
                                name = line[0].Trim('"'),
                                classId = profScreenViewModel.classroom.classId

                            };
                            _studentRepository.AddStudent(student);
                        }
                        else
                        {
                            // Students.Add(new Student(line[3].Trim('"'), line[1].Trim('"'), line[0].Trim('"')));
                            Models.Students.Student student = new Models.Students.Student()
                            {
                                githubEmail = line[0].Trim('"'),
                                githubUrsName = line[1].Trim('"'),
                                name = line[3].Trim('"'),
                                classId = profScreenViewModel.classroom.classId

                            };
                            _studentRepository.AddStudent(student);

                        }

                    }
                }
            }
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

        private Services.ClassRoom GetClassroom(ProfScreenViewModel model)
        {
            //_classroomRepository.AddClassroom(model.classroom);
            var classes = _classroomRepository.GetAllClassrooms().OrderBy(c => c.className);
            var students = _studentRepository.GetAllStudents().OrderBy(s => s.classId);
            model = new ProfScreenViewModel()
            {
                Classrooms = classes.ToList(),
                Students = students.ToList()

            };

            /*IEnumerable<Models.Students.Student> ClassStudents = _studentRepository.GetAllStudentsInClass(model.classId);
            List<Models.Students.Student> studentList = ClassStudents.ToList();
            ObservableCollection<Services.Student> classStuds = new ObservableCollection<Services.Student>();

            foreach (Models.Students.Student s in studentList)
            {
                Services.Student tempStudent = new Services.Student(s.name, s.githubUrsName, s.githubEmail);
                classStuds.Add(tempStudent);
            }
            */

            //string className = _classroomRepository.GetClassroomById(model.classId).className;
            //string orgName = _classroomRepository.GetClassroomById(model.classId).orgName;

            //string className = model.Classrooms.ElementAt(model.classId).className;
            //string orgName = model.Classrooms.ElementAt(model.classId).orgName;

            string className = model.Classrooms.ElementAt(model.classId).className;
            string orgName = model.Classrooms.ElementAt(model.classId).orgName;

            int classId  = _classroomRepository.GetIdByName(className);

            IEnumerable<Models.Students.Student> ClassStudents = _studentRepository.GetAllStudentsInClass(classId);
            List<Models.Students.Student> studentList = ClassStudents.ToList();
            ObservableCollection<Services.Student> classStuds = new ObservableCollection<Services.Student>();

            foreach (Models.Students.Student s in studentList)
            {
                Services.Student tempStudent = new Services.Student(s.name, s.githubUrsName, s.githubEmail);
                classStuds.Add(tempStudent);
            }


            return new Services.ClassRoom(orgName, className, classStuds);

        }

        [HttpPost]
        public IActionResult Assignments(ProfScreenViewModel model)
        {

            string instructorUTPath = "";
            Services.ClassRoom classR = GetClassroom(model);

            if (ModelState.IsValid)
            {
                if(model.professorUnitTest != null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "instructorUnitTest");
                    instructorUTPath = Path.Combine(uploadFolder, model.assignmentName + "InstructorUnitTest.cpp");
                    model.professorUnitTest.CopyTo(new FileStream(instructorUTPath, FileMode.Create));
                }
            }

            /*
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
            */

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

    public static class iformreader
    {
        public static List<string> ReadAsList(this IFormFile file)
        {
            List<string> result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.Add(reader.ReadLine());
            }

            return result;
        }
    } 
}