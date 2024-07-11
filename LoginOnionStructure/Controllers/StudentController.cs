using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using LoginOnionStructure.Models;
using ServiceLayer.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;


namespace LoginOnionStructure.Controllers
{
    public class StudentController : Controller
    {
        public IStudentService studentService;

        public StudentController() 
        {
            studentService = new StudentServices();
        }

        // GET: Students
        public ActionResult Index()
        {
            var users = studentService.getAllStudent();
            List<WebStudent> userList = new List<WebStudent>();
            foreach (var user in users)
            {
                WebStudent viewUser = new WebStudent();
                viewUser.userID = user.userID;
                viewUser.username = user.username;
                viewUser.email = user.email;
                userList.Add(viewUser);
            }
            return View(userList);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ss = studentService.findStudent(id);
            WebStudent usersWeb = new WebStudent
            {
                username = ss.username,
                email = ss.email,
            };
            if (usersWeb == null)
            {
                return HttpNotFound();
            }
            return View(usersWeb);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,username,email,password,confirmedPassword")] WebStudent student)
        {
            if (ModelState.IsValid)
            {
                var ss = new ServiceStudent()
                {
                    username = student.username,
                    email = student.email,
                    password = student.password,
                    confirmedPassword = student.confirmedPassword,
                };
                studentService.createStudent(ss);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceStudent ss = studentService.findStudent(id);
            if (ss == null)
            {
                return HttpNotFound();
            }
            var ws = new WebStudent()
            {
                userID = ss.userID,
                username = ss.username,
                email = ss.email,
            };
            return View(ws);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,username,email,password,confirmedPassword")] WebStudent student)
        {
            var ss = new ServiceStudent
            {
                userID = student.userID,
                username = student.username,
                email = student.email,
            };
            studentService.editStudent(ss);
            return RedirectToAction("Index");
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceStudent ss = studentService.findStudent(id);
            if (ss == null)
            {
                return HttpNotFound();
            }
            var ws = new WebStudent
            {
                userID = ss.userID,
                username = ss.username,
                email = ss.email,
            };
            return View(ws);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentService.deleteStudent(id);
            return RedirectToAction("Index");
        }

        
    }
}
