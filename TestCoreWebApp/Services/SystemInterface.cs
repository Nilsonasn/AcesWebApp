using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Reflection;


namespace Services
{
    /// <summary>
    /// This class interfaces with the operating system command line
    /// </summary>
    public class SystemInterface
    {
        /// <summary>
        /// builds a students c++ assignment
        /// </summary>
        /// <param name="studentProjLocation">Folder location of the students project</param>
        /// <param name="instructorUnitTests">Directory location of the instructors unit tests</param>
        public Score BuildAssignment(string studentProjLocation, string instructorUnitTests, string securityCode)
        {
            Score tempScore = new Score();
            try
            {
                tempScore.NumberCorrect = 0;
                tempScore.NumberIncorrect = 0;

                //Compiler Location
                String compLocation = Path.GetFullPath(@"..\G++\bin\");

                //A process is used to run commands on the command line
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.Start();

                //move to the directory
                string directoryMove = "cd \"" + studentProjLocation + "\"";
                cmd.StandardInput.WriteLine(directoryMove);

                //Delete the students unit test
                string deleteCmd = "del /f UnitTests.cpp";
                cmd.StandardInput.WriteLine(deleteCmd);

                //Copy the instructors unit test
                string moveCmd = "copy \"" + instructorUnitTests + "\" \"" + studentProjLocation + "\" /Y";
                cmd.StandardInput.WriteLine(moveCmd);

                //Move to compiler location
                cmd.StandardInput.WriteLine("cd " + compLocation);

                //Build the project
                //string buildCmd = String.Format("g++ {0}*.cpp -o {1}UnitTests_InstructorVersion -lm", studentProjLocation + @"\", studentProjLocation + @"\");
                string buildCmd = String.Format("g++ {0}*.cpp -o {1}test-assignmentInstructorUnitTest -lm", studentProjLocation + @"\", studentProjLocation + @"\");
                cmd.StandardInput.WriteLine(buildCmd);
                
                 //Waits for the compiler to compile the program before continuing
                int timeOut = 0;
                //while (!(File.Exists(String.Format(@"{0}\UnitTests_InstructorVersion.exe", studentProjLocation))))
                while (!(File.Exists(String.Format(@"{0}\test-assignmentInstructorUnitTest.exe", studentProjLocation))))
                {
                    Thread.Sleep(1000);
                    timeOut++;

                    //timesout if 5 seconds have past
                    if(timeOut == 5)
                    {
                        break;
                    }
                }

                //Run the project
                //string runCmd = String.Format(@"{0}\UnitTests_InstructorVersion", studentProjLocation);
                string runCmd = String.Format(@"{0}\test-assignmentInstructorUnitTest", studentProjLocation);
                cmd.StandardInput.WriteLine(runCmd);

                cmd.StandardInput.WriteLine("exit");

                List<string> lines = new List<string>();

                // cycle though the lines of output untill it runs out and get the last line 
                string output = cmd.StandardOutput.ReadLine();
                while (output != null)
                {
                    // get the last line in output. 
                    lines.Add(output);
                    output = cmd.StandardOutput.ReadLine();
                }

                // cycle though the lines of output untill it runs out and get the last line 
                string error = cmd.StandardError.ReadLine();
                while (error != null)
                {
                    // get the last line in output. 
                    lines.Add(error);
                    //
                    error = cmd.StandardError.ReadLine();
                }

                //Count correct answers. Uses the security code the ensure that students can't write "Passed" to Command line
                string correctAnswer = securityCode + " Passed";
                foreach (var line in lines)
                {
                    string temp = line.Trim();

                    if (temp == "Failed test")
                    {
                        tempScore.NumberIncorrect++;
                    }

                    if (temp == correctAnswer)
                    {
                        tempScore.NumberCorrect++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "."
                    + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return tempScore;
        }//build assignment
    }
}
