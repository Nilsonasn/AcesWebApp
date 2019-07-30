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

        /// <summary>
        /// This is just for testing use other constructor
        /// </summary>
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
            
            Analyze.run(classroom, "test-assignment", repoLocation, useKey,  rosterLocation, "23456");

            foreach (Student s in classroom.Students)
            {

                //Calculate the time. Integer division is done intentionally
                int seconds = (int)s.AvgTimeBetweenCommits;
                int days = seconds / 86400;
                seconds = seconds % 86400;
                int hours = seconds / 3600;
                seconds = seconds % 3600;
                int minutes = seconds / 60;
                seconds = seconds % 60;

                //format
                string AvgTimeBetweenCommits = days + ":" + hours
                    + ":" + minutes + ":" + seconds;

                Assignment assignment = new Assignment()
                {
                    AssignmentName = "test-assignment",
                    StudentName = s.Name,
                    Compiler = s.Compiler,
                    Rating = s.Rating,
                    Score = s.StudentScore.ToString(),
                    NumCommits = s.NumStudentCommits,
                    AvgTimeCommit = AvgTimeBetweenCommits,
                    StDevCommit = s.StdDev.ToString("0,0.00"),
                    ReasonsWhy = s.getReasonsWhy()
                };

                assignments.Add(assignment);
            }
            
        }

        public AssignmentService(ClassRoom classroom, string instructorUnitTestLocation, string assignName, string securityKey, string repoLocation)
        {
            assignments = new List<Assignment>();

            //this is hardcoded and needs to be fixed
            UserInfo currentUser = new UserInfo("CS4450-Final-Group-Summer2019", "PassW0rd4450");

            string useKey = currentUser.UserName + ":" + currentUser.Password;

            Analyze.run(classroom, assignName, repoLocation, useKey, instructorUnitTestLocation, securityKey);

            foreach (Student s in classroom.Students)
            {

                //Calculate the time. Integer division is done intentionally
                int seconds = (int)s.AvgTimeBetweenCommits;
                int days = seconds / 86400;
                seconds = seconds % 86400;
                int hours = seconds / 3600;
                seconds = seconds % 3600;
                int minutes = seconds / 60;
                seconds = seconds % 60;

                //format
                string AvgTimeBetweenCommits = days + ":" + hours
                    + ":" + minutes + ":" + seconds;

                Assignment assignment = new Assignment()
                {

                    AssignmentName = assignName,
                    StudentName = s.Name,
                    Compiler = s.Compiler,
                    Rating = s.Rating,
                    Score = s.StudentScore.ToString(),
                    NumCommits = s.NumStudentCommits,
                    AvgTimeCommit = AvgTimeBetweenCommits,
                    StDevCommit = s.StdDev.ToString("0,0.00"),
                    ReasonsWhy = s.getReasonsWhy()
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

    public class myAssignmentService
    {
        public static AssignmentService assignService;
    }
}
