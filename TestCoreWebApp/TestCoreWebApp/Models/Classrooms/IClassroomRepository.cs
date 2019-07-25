using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcesWebApp.Models.Classrooms
{
    public interface IClassroomRepository
    {
        IEnumerable<Classroom> GetAllClassrooms();
        Classroom GetClassroomById(int classId);
        void AddClassroom(Classroom classroom);
        void RemoveClassroomById(int classId);
        int GetIdByName(string name);
    }
}
