using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Interfaces;
using DomainLayer.Models;
using RepoLayer.Repositories;
using RepoLayer;
using ServiceLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class StudentServices : IStudentService
    {
        StudentContext _context = new StudentContext();

        private readonly IUnitOfWork _unitOfWork;

        public StudentServices()
        {
            _unitOfWork = new UnitOfWork(_context);
        }

        public List<ServiceStudent> getAllStudent()
        {
            var students = _unitOfWork.StudentRepo.getAllStudent();
            List<ServiceStudent> studentList = new List<ServiceStudent>();
            foreach (var student in students)
            {
                ServiceStudent s1 = new ServiceStudent
                {
                    userID = student.userID,
                    username = student.username,
                    email = student.email
                };
                studentList.Add(s1);
            }
            return studentList;
        }

        public void createStudent(ServiceStudent s1)
        {
            var student = new Student
            {
                username = s1.username,
                email = s1.email,
                password = s1.password,
                confirmedPassword = s1.confirmedPassword
            };
            _unitOfWork.StudentRepo.createStudent(student);
            _unitOfWork.complete();
        }

        public ServiceStudent findStudent(int? id)
        {
            Student domainUser = _unitOfWork.StudentRepo.findStudent(id);
            if (domainUser == null)
            {
                return null;
            }
            return new ServiceStudent
            {
                userID = domainUser.userID,
                username = domainUser.username,
                email = domainUser.email
            };
        }

        public void editStudent(ServiceStudent ss)
        {
            var student = _unitOfWork.StudentRepo.findStudent(ss.userID);
            if (student != null)
            {
                student.username = ss.username;
                student.email = ss.email;
                _unitOfWork.StudentRepo.editStudent(student);
                _unitOfWork.complete();
            }
        }

        public void deleteStudent(int id)
        {
            _unitOfWork.StudentRepo.deleteStudent(id);
            _unitOfWork.complete();
        }
    }
}
