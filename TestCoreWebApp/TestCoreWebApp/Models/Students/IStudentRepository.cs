using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models.Students
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        IEnumerable<Student> GetAllStudentsInClass(int classId);
        void AddStudent(Student student);
    }
}
