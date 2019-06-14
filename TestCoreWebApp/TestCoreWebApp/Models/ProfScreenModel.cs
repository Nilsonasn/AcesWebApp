using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models
{

    public class ProfScreenModel
    {
        public List<Services.ClassRoom> classList { get; set; }
        public string className { get; set; }

        public ProfScreenModel()
        {
            classList = new List<Services.ClassRoom>();
        }
    }
}
