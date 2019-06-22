using Services.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Services
{
    public class AssignmentService
    {
        private List<Assignment> assignments;

        private Analyzer Analyze = new Analyzer();

        public AssignmentService()
        {
             assignments = new List<Assignment>();

            String here = Directory.GetCurrentDirectory();

            //roster Location
            String rosterLocation = Path.GetFullPath(@"..\Services\TestingResources\classroom_roster.csv");
            //repo location
            String repoLocation = Path.GetFullPath(@"..\Services\TestingResources\ClassRepo");
            //instructor unit test UnitLocation
            String instUnitLocation = Path.GetFullPath(@"..\Services\TestingResources\UnitTests_InstructorVersion.cpp");

            UserInfo currentUser = new UserInfo("CS4450-Final-Group-Summer2019", "PassW0rd4450");

            
            ClassRoom classroom = new ClassRoom("weberstate4450summer2019", rosterLocation, "4450FinalClassroom");

            string useKey = currentUser.UserName + ":" + currentUser.Password;
            
            Analyze.run(classroom, "test-assignment", repoLocation, useKey, instUnitLocation, "23456");

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
