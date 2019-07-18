using AcesWebApp.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _appDbContext.Students;
        }

        public Student GetStudentById(int studentId)
        {
            return _appDbContext.Students.FirstOrDefault(s => s.id == studentId);
        }
    }
}
