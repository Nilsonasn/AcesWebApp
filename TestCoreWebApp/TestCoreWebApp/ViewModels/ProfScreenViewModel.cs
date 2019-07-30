using AcesWebApp.Models.Classrooms;
using AcesWebApp.Models.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.ViewModels
{
    public class ProfScreenViewModel
    {
        public string Title { get; set; }
        public List<Classroom> Classrooms { get; set; }
        public List<Student> Students { get; set; }

        public Classroom classroom { get; set; }

        public List<Services.ClassRoom> classList { get; set; }
        public string className { get; set; }

        public string assignmentName { get; set; }
        public string unitTestFileLocation { get; set; }
        public string studentRepoLocation { get; set; }
        public string securityKey { get; set; }
        public IFormFile professorUnitTest { get; set; }
        public int classId { get; set; }

        public string ClassDelete { get; set; }

        public string createClassName { get; set; }
        public string createOrgName { get; set; }
        public IFormFile roster { get; set; }

        public int assingnmentID { get; set; }
        public List<Assignment> assignments { get; set; }
        public Assignment assignment { get; set; }

        public string githubUser { get; set; }
        public string githubPass { get; set; }

        public ProfScreenViewModel()
        {
            classList = new List<Services.ClassRoom>();
        }
    }
}
