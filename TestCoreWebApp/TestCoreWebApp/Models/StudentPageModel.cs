using System;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models
{
    public class StudentPageModel
    {
        public List<IFormFile> StudentProgramFiles { get; set; }
        public IFormFile StudentUnitTest { get; set; }
        public string StudentProgramCode { get; set; }
        public string StudentUnitCode { get; set; }
        public string StudentResults { get; set; }
    }
}
