using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Interfaces;
using DomainLayer.Models;

namespace RepoLayer.Repositories
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        private readonly GenericRepo<Student> _studentRepo;

        public StudentRepo(StudentContext context) : base(context)
        {
            _studentRepo = new GenericRepo<Student>(context);
        }

        public IEnumerable<Student> getAllStudent()
        {
            var entities = _context.Set<Student>().ToList();

            if (!entities.Any())
            {
                entities = new List<Student>
                {
                    new Student
                    {
                        userID = 1,
                        username = "dummyUser1",
                        email = "dummy1@example.com",
                        password = "password1",
                        confirmedPassword = "password1"
                    },
                    new Student
                    {
                        userID = 2,
                        username = "dummyUser2",
                        email = "dummy2@example.com",
                        password = "password2",
                        confirmedPassword = "password2"
                    }
                };
            }

            return entities;
        }

        public void createStudent(Student user)
        {
            _studentRepo.add(user);
        }

        public Student findStudent(int? id)
        {
            return _studentRepo.getByID(id);
        }

        public void editStudent(Student user)
        {
            var existingStudent = findStudent(user.userID);
            if (existingStudent != null)
            {
                existingStudent.username = user.username;
                existingStudent.email = user.email;
                existingStudent.password = user.password;
                existingStudent.confirmedPassword = user.confirmedPassword;
                _studentRepo.update(existingStudent);
            }
        }

        public void deleteStudent(int id)
        {
            var student = findStudent(id);
            if (student != null)
            {
                _studentRepo.delete(student);
            }
        }
    }
}
