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


        private Services.ClassRoom GetClassroom(ProfScreenViewModel model)
        {
            var classes = _classroomRepository.GetAllClassrooms().OrderBy(c => c.className);
            var students = _studentRepository.GetAllStudents().OrderBy(s => s.classId);
            model = new ProfScreenViewModel()
            {
                Classrooms = classes.ToList(),
                Students = students.ToList()

            };

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
            bool login;
            if (model.githubPass == null || model.githubUser == null)
            {
                login = false;
            }
            else
            {
                login = TestGithubLogin.TestLogin(model.githubUser, model.githubPass).Result;
            }
            if (login==false)
            {
                var classes = _classroomRepository.GetAllClassrooms().OrderBy(c => c.className);
                var students = _studentRepository.GetAllStudents().OrderBy(s => s.classId);
                model.Classrooms = classes.ToList();
                model.Students = students.ToList();
                model.errorText = "ERROR: invalid login";
                return View("ProfScreen",model);
            }
            
            if (ModelState.IsValid)
            {
                if(model.professorUnitTest != null)
                {
                    //creates the needed directory if it doesn't exist
                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + @"/" + "instructorUnitTest");

                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "instructorUnitTest");
                    instructorUTPath = Path.Combine(uploadFolder, model.assignmentName + "InstructorUnitTest.cpp");
                    model.professorUnitTest.CopyTo(new FileStream(instructorUTPath, FileMode.Create));
                }
            }
            
            //creates the needed directory if it doesn't exist
            System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + @"/" + "studentRepo");

            string studentRepo = Path.Combine(_hostingEnvironment.WebRootPath, @"studentRepo/");

            //if using the return button assignname is null
            if (model.assignmentName != null)
            {
                myAssignmentService.assignService = new AssignmentService(classR, instructorUTPath, model.assignmentName, model.securityKey, studentRepo, model.githubUser, model.githubPass);
            }

            var assignments = myAssignmentService.assignService.GetAssignment();
            
            //deleted the uploaded instructor unit test after the program is done
            if(!String.IsNullOrWhiteSpace(instructorUTPath)){
                System.IO.File.Delete(instructorUTPath);
            }            

            //HttpContext.Session["assignments"] = _assignmentService.GetAssignment();
            //_contextAccessor.HttpContext.Session.SetString

            //Session["assignments"] = _assignmentService.GetAssignment();

            return View(assignments);
        }

        public IActionResult StudentDetails(ProfScreenModel model)
        {
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