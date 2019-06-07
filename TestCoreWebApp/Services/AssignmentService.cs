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

            
            /* Assignment tempAssignment = new Assignment() { AssignmentName = "Test Assignment",
                                                            StudentName = "Joe Biden",
                                                            Compiler = "G++",
                                                            Rating = 50,
                                                            NumCommits = 10,
                                                            AvgTimeCommit = 15,
                                                            StDevCommit = 2,
                                                            SourceCode = "stdout >> \"Hello World\"; "};
             tempAssignment._Score = new Score();
             tempAssignment._Score.NumberCorrect = 10;
             tempAssignment._Score.NumberIncorrect = 3;
             Assignment tempAssignment2 = new Assignment(){  AssignmentName = "Test Assignment",
                                                            StudentName = "Jack Black",
                                                            Compiler = "G++",
                                                            Rating = 90,
                                                            NumCommits = 5,
                                                            AvgTimeCommit = 2,
                                                            StDevCommit = .5,
                                                            SourceCode = "stdout >> \"Hello World\"; "
             };
             tempAssignment2._Score = new Score();
             tempAssignment2._Score.NumberCorrect = 8;
             tempAssignment2._Score.NumberIncorrect = 5;

             assignments.Add(tempAssignment);
             assignments.Add(tempAssignment2);*/

             SystemInterface sysinterface = new SystemInterface();
             sysinterface.BuildAssignment("test", "test", "test");

            //Analyze = new Analyzer();

            UserInfo currentUser = new UserInfo("CS4450-Final-Group-Summer2019", "PassW0rd4450");
            //roster location hardcoded to Alex's Machine
            ClassRoom classroom = new ClassRoom("weberstate4450summer2019", "C:\\Users\\User\\Desktop\\classroom_roster1.csv", "4450FinalClassroom");

            string useKey = currentUser.UserName + ":" + currentUser.Password;

            //hardcoded to Alex's PC
            Analyze.run(classroom, "test-assignment", "C:\\Users\\User\\Desktop\\studentRepo",
                            useKey, "C:\\Users\\User\\Desktop\\UnitTests_InstructorVersion.cpp", "23456");

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
