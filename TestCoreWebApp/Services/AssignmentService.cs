using Services.Entities;
using System;
using System.Collections.Generic;

namespace Services
{
    public class AssignmentService
    {
        private List<Assignment> assignments;

        private Analyzer Analyze = new Analyzer();

        public AssignmentService()
        {
             assignments = new List<Assignment>();          
            
           

            UserInfo currentUser = new UserInfo("CS4450-Final-Group-Summer2019", "PassW0rd4450");
            //roster location hardcoded to Alex's Machine
            ClassRoom classroom = new ClassRoom("weberstate4450summer2019", @"..\Services\TestingResources\classroom_roster.csv", "4450FinalClassroom");

            string useKey = currentUser.UserName + ":" + currentUser.Password;

            //hardcoded to Alex's PCC:
            Analyze.run(classroom, "test-assignment", @"C:\Users\Rhet\Source\Repos\AcesWebApp\TestCoreWebApp\Services\TestingResources\ClassRepo",
               
                            useKey, @"..\Services\TestingResources\UnitTests_InstructorVersion.cpp", "23456");

            foreach (Student s in classroom.Students)
            {
                Assignment assignment = new Assignment()
                {
                    AssignmentName = "test-assignment",
                    StudentName = s.Name,
                    Compiler = s.Compiler,
                    Rating = s.Rating,
                    Score = s.StudentScore.ToString(),
                    NumCommits = s.NumStudentCommits,
                    AvgTimeCommit = s.AvgTimeBetweenCommits,
                    StDevCommit = s.StdDev,
                    SourceCode = "stdout >> \"Hello World\"; "
                };

                assignments.Add(assignment);
            }

        }
        

        public List<Assignment> GetAssignment()
        {
            return assignments;
        }

        public List<Assignment> PostNewAssignment(Assignment assignment)
        {
            assignments.Add(assignment);

            return assignments;
        }
    }
}
