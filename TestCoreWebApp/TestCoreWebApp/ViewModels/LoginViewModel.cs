using AcesWebApp.Models.Classrooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.ViewModels
{
    public class LoginViewModel
    {
        public string Title { get; set; }
        public List<Classroom> Classrooms {get; set;}
    }
}
