using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRoutingDemo_deguzman.Models;

namespace MvcRoutingDemo_deguzman.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult Index()
        {
            Student student = new Student()
            {
                Id = 1,
                FullName = "De Guzman, Murphy",
                Course = "BS Information Technology",
                Age = "20",
                YearLevel = "3rd Year"
            };

            return View(student);
        }

        // Custom Route Example
        public ActionResult Details(int id)
        {
            Student student = new Student()
            {
                Id = id,
                FullName = "Student" + id,
                Course = "SampleCourse",
                Age = "20",
                YearLevel = "3rd Year"
            };

            return View(student);
        }
        // Custom Route
        public ActionResult Course(int id)
        {
            Student student = new Student()
            {
                Id = id,
                FullName = "Student" + id,
                Course = "SampleCourse",
                Age = "20",
                YearLevel = "4th Year"
            };
            return View(student);
        }
    }
}