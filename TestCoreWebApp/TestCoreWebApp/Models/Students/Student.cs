using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models.Students
{
    public class Student
    {
        public int id { get; set; }
        public int classId { get; set; }
        public string githubUrsName { get; set; }
        public string githubEmail { get; set; }
        public string name { get; set; }
    }
}
