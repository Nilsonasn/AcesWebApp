using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models.Classrooms
{
    public class Classroom
    {
        [Key]
        public int classId { get; set; }
        public string orgName { get; set; }
        public string className { get; set; }
    }
}
