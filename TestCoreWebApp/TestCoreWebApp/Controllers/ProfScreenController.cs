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

namespace AcesWebApp.Controllers
{
    public class ProfScreenController : Controller
    {

        private IHostingEnvironment _hostingEnvironment;

        public ProfScreenController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

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
        
	    [HttpPost]
        public IActionResult Index(List<IFormFile> files)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(files[0].OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }
            String Content = result.ToString();
                //Do something with the files here. 
                return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UploadSmallFile(IFormFile file)
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok();
        }


        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            /* long size = files.Sum(f => f.Length);

             // full path to file in temp location
             var filePath = Path.GetTempFileName();

             foreach (var formFile in files)
             {
                 if (formFile.Length > 0)
                 {
                     using (var stream = new FileStream(filePath, FileMode.Create))
                     {
                         await formFile.CopyToAsync(stream);
                     }
                 }
             }*/

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "UploadedFiles");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {

                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            //return Ok(new { count = files.Count, size, filePath });
            return Ok();
        }


    }
}