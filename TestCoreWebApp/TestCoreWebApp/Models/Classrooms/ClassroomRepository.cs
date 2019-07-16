using AcesWebApp.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models.Classrooms
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassroomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Classroom> GetAllClassrooms()
        {
            return _appDbContext.Classrooms;
        }

        public Classroom GetClassroomById(int classId)
        {
            return _appDbContext.Classrooms.FirstOrDefault(c => c.classId == classId);
        }
    }
}
