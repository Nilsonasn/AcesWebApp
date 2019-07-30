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

        //The return string for the output of the student program
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
        
        //handles uploading the student code files and call compiler function at end
        [HttpPost]
        public async Task<IActionResult> Results(StudentPageModel model)
        {
            //Make sure it is a valid model
            if (ModelState.IsValid)
            {
                //string for the file name
                string fileName = null;

                //creates the needed directory if it doesn't exist
                System.IO.Directory.CreateDirectory(hostingEnvironment.WebRootPath + @"/" + "studentCode");

                //checks to make sure it is not empty. Uploads the student program code
                if (model.StudentProgramFiles != null)
                {
                    //uploads each file in the list
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
                //handles uploading from the text box for sutdent code
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

                //uploads the unit test
                if (model.StudentUnitTest != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "studentCode");
                    fileName = model.StudentUnitTest.FileName;  //Guid.NewGuid().ToString() + "_" + model.StudentUnitTest.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.StudentUnitTest.CopyToAsync(fileStream);
                    }                   

                }
                //creates file from text box for unit test
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

            //save restults of the program in the model
            model.StudentResults = Run(Path.Combine(hostingEnvironment.WebRootPath, "studentCode"));
            //returns the student page and model for proper display on same page
            return View("StudentPage", model);
        }

        //compiles and runs the students code
        public string Run(string studentProjLocation)
        {


            /// <summary>
            /// Return String
            /// </summary>
            // string RetString;
            /// <summary>
            /// Compiler location
            /// </summary>
            //string compLocation = Path.GetFullPath(@"..\G++\bin\");

            //A process is used to run commands on the command line
            Process cmd = new Process();
            cmd.StartInfo.FileName = "/bin/bash";
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardError = true;           
            cmd.Start();            

            //Build the project
            string buildCmd = String.Format("g++ {0}*.cpp -o {1}UnitTests_InstructorVersion -lm", studentProjLocation + @"/", studentProjLocation + @"/");
            cmd.StandardInput.WriteLine(buildCmd);            

            //Run the project
            string runCmd = String.Format(@"{0}/UnitTests_InstructorVersion", studentProjLocation);
            cmd.StandardInput.WriteLine(runCmd);

            cmd.StandardInput.WriteLine("exit");           


            List<string> lines = new List<string>();

            bool startOfStudentOutput = false;

            // cycle through the lines of output untill it runs out and get the last line 
            string output = cmd.StandardOutput.ReadLine();            

            //cycles through the lines of output until i find the start of the student units tests
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