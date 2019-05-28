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

            Assignment tempAssignment = new Assignment() { AssignmentName = "Test Assignment",
                                                           StudentName = "Joe Biden",
                                                           Score = 100.00,
                                                           Compiler = "G++",
                                                           Rating = 50,
                                                           NumCommits = 10,
                                                           AvgTimeCommit = 15,
                                                           StDevCommit = 2,
                                                           SourceCode = "stdout >> \"Hello World\"; "};
            Assignment tempAssignment2 = new Assignment(){  AssignmentName = "Test Assignment",
                                                           StudentName = "Jack Black",
                                                           Score = 100.00,
                                                           Compiler = "G++",
                                                           Rating = 90,
                                                           NumCommits = 5,
                                                           AvgTimeCommit = 2,
                                                           StDevCommit = .5,
                                                           SourceCode = "stdout >> \"Hello World\"; "
            };

            assignments.Add(tempAssignment);
            assignments.Add(tempAssignment2);
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
