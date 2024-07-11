using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.Interfaces
{
    public interface IStudentRepo : IGenericRepo<Student>
    {
        IEnumerable<Student> getAllStudent();

        void createStudent(Student user);

        Student findStudent(int? id);

        void editStudent(Student user);

        void deleteStudent(int id);
    }
}
