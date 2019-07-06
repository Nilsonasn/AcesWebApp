using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models
{

    public class ProfScreenModel : PageModel
    {
        public List<Services.ClassRoom> classList { get; set; }
        public string className { get; set; }

        public string assignmentName { get; set; }
        public string unitTestFileLocation { get; set; }
        public string studentRepoLocation { get; set; }
        public string securityKey { get; set; }
        public IFormFile professorUnitTest { get; set; }

        public string createClassName { get; set; }
        public string createOrgName { get; set; }
        public IFormFile roster { get; set; }

        public int assingnmentID { get; set; }

        public ProfScreenModel()
        {
            classList = new List<Services.ClassRoom>();
        }
    }
}
