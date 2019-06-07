using Services.Entities;
using System;
using System.Collections.Generic;

namespace Services
{
    public class AssignmentService
    {
        private List<Assignment> assignments;
        public AssignmentService()
        {
            assignments = new List<Assignment>();

            ClassRoom classRoom = new ClassRoom("Test", "..\\ACESTestClassroom\\classroom_roster.csv", "Test");

            Analyzer Analyze = new Analyzer();

            Analyze.run(classRoom, "Test-Assignment", "..\\ACESClassroom\\TestClassroom", "CS4450-Final-Group-Summer2019:PassW0rd4450",
                        "..\\ACESClassroom\\UnitTests_InstructorVersion.cpp", "23456");

            Assignment tempAssignment = new Assignment() { AssignmentName = "Test Assignment",
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
            /*Assignment tempAssignment2 = new Assignment(){  AssignmentName = "Test Assignment",
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
            tempAssignment2._Score.NumberIncorrect = 5;*/

            assignments.Add(tempAssignment);
            //assignments.Add(tempAssignment2);

            SystemInterface sysinterface = new SystemInterface();
            sysinterface.BuildAssignment("test", "test", "test");
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
