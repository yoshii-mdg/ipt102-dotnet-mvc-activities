using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace StudentMVApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Student MVC Application";
            return View();
        }
        public ActionResult Profile()
        {
            ViewBag.Name = "Grow A. Garden";
            ViewBag.Course = "BS Information Technology";
            ViewBag.Year = "3rd Year";
            ViewData["Age"] = 21;
            return View();
        }
        public ActionResult Subject()
        {
            return View();
        }
        public ActionResult StudentList()
        {
            List<string> students = new List<string>()
            {
                "Matthew Capadocia",
                "Murphy De Guzman",
                "Mark Christopher Galope",
                "Lee Bernard",
                "Zion Lozano"
            };
            return View(students);
        }
    }
}