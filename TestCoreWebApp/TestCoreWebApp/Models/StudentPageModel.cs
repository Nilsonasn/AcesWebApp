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
        //list that hold student codes if they have multiple files
        public List<IFormFile> StudentProgramFiles { get; set; }
        //hold the unti test file 
        public IFormFile StudentUnitTest { get; set; }
        //string that hold the program code textbox text
        public string StudentProgramCode { get; set; } 
        //string hold student unit code from unit code textbox
        public string StudentUnitCode { get; set; }
        //string holds the output from the sutdents program
        public string StudentResults { get; set; }
    }
}
