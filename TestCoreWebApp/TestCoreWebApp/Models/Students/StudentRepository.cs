using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models.Students
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> _students;

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentById(int studentId)
        {
            return _students.FirstOrDefault(s => s.id == studentId);
        }
    }
}
