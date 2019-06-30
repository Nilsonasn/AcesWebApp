using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AcesWebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace AcesWebApp.Controllers
{
    public class StudentPageController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private string RetString;

        public StudentPageController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("StudentPage")]
        public IActionResult StudentPage(StudentPageModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Results(StudentPageModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                //creates the needed directory if it doesn't exist
                System.IO.Directory.CreateDirectory(hostingEnvironment.WebRootPath + @"/" + "studentCode");


                if (model.StudentProgramFiles != null)
                {

                    foreach (IFormFile studentFile in model.StudentProgramFiles)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                        fileName = studentFile.FileName;  //Guid.NewGuid().ToString() + "_" + model.StudentUnitTest.FileName;
                        string filePath = Path.Combine(uploadsFolder, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await studentFile.CopyToAsync(fileStream);
                        }
                           
                    }               

                }
                else if (model.StudentProgramCode != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    fileName = "StudentProgram.cpp";   //Guid.NewGuid().ToString() + "_StudentCode.cpp";
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (System.IO.StreamWriter file = new StreamWriter(System.IO.File.Create(filePath)))
                    {
                        file.WriteLine(model.StudentProgramCode.ToString());
                    }
                }

                if (model.StudentUnitTest != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    fileName = model.StudentUnitTest.FileName;  //Guid.NewGuid().ToString() + "_" + model.StudentUnitTest.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.StudentUnitTest.CopyToAsync(fileStream);
                    }
                    //model.StudentUnitTest.CopyTo(new FileStream(filePath, FileMode.Create));

                }
                else if (model.StudentUnitCode != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    fileName = "StudentUnitTests.cpp";   //Guid.NewGuid().ToString() + "_StudentCode.cpp";
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (System.IO.StreamWriter file = new StreamWriter(System.IO.File.Create(filePath)))
                    {
                        file.WriteLine(model.StudentUnitCode.ToString());
                    }
                }          

            }            

            model.StudentResults = Run(Path.Combine(hostingEnvironment.WebRootPath, "studentCode"));
            return View("StudentPage", model);
        }

        public string Run(string studentProjLocation)
        {


            /// <summary>
            /// Return String
            /// </summary>
            // string RetString;
            /// <summary>
            /// Compiler location
            /// </summary>
            string compLocation = Path.GetFullPath(@"..\G++\bin\");

            //A process is used to run commands on the command line
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardError = true;           
            cmd.Start();


            //Move to compiler location
            cmd.StandardInput.WriteLine("cd " + compLocation);

            //Build the project
            string buildCmd = String.Format("g++ {0}*.cpp -o {1}UnitTests_InstructorVersion -lm", studentProjLocation + @"\", studentProjLocation + @"\");
            cmd.StandardInput.WriteLine(buildCmd);            

            //Run the project
            string runCmd = String.Format(@"{0}\UnitTests_InstructorVersion", studentProjLocation);
            cmd.StandardInput.WriteLine(runCmd);

            cmd.StandardInput.WriteLine("exit");           


            List<string> lines = new List<string>();

            bool startOfStudentOutput = false;

            // cycle though the lines of output untill it runs out and get the last line 
            string output = cmd.StandardOutput.ReadLine();            

            while (output != null)
            {

                if (output.Contains("Passed") || output.Contains("Failed"))
                {
                    startOfStudentOutput = true;
                }

                if (startOfStudentOutput)
                {
                    lines.Add(output);                    
                }
                output = cmd.StandardOutput.ReadLine();
            }

            // cycle though the lines of output untill it runs out and get the last line 
            string error = cmd.StandardError.ReadLine();
            while (error != null)
            {
                // get the last line in output. 
                lines.Add(error);               
                error = cmd.StandardError.ReadLine();                
            }

            foreach (string line in lines)
            {
                RetString += line + "\n";
            }

            return RetString;

        }
    }
}