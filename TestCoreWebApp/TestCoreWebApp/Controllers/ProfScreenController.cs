using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.IO;
using System.Collections.ObjectModel;
using AcesWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;//

namespace AcesWebApp.Controllers
{
    public class ProfScreenController : Controller
    {
        ObservableCollection<Services.ClassRoom> classList = new ObservableCollection<Services.ClassRoom>();
        List<Services.ClassRoom> classList2 = new List<Services.ClassRoom>();

        [Route("ProfScreen")]
        public IActionResult ProfScreen()
        {
            GetClassList();
            ViewBag.classList = classList;
            ViewBag.classList2 = new SelectList(classList2, "className", "className");
            return View();
        }

        private IActionResult GetClassList()
        {
            var vm = new ProfScreenModel();

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

            //vm.classList.Add(new Services.ClassRoom("weberstate4450summer2019", "C:\\Users\\User\\Desktop\\classroom_roster1.csv", "4450FinalClassroom"));

            return View(vm);
        }
    }
}