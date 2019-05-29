using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Entities
{
    public class Assignment
    {
        public string AssignmentName{ get; set; }
        public string StudentName { get; set; }
        public double Rating { get; set; }
        public Score _Score { get; set; }
        public string Compiler { get; set; }
        public int NumCommits { get; set; }
        public double AvgTimeCommit { get; set; }
        public double StDevCommit { get; set; }
        public string SourceCode { get; set; }
    }
}
