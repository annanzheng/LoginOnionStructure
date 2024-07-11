using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IStudentService
    {
        List<ServiceStudent> getAllStudent();
        void createStudent(ServiceStudent user);

        ServiceStudent findStudent(int? id);

        void editStudent(ServiceStudent user);

        void deleteStudent(int id);
    }
}
