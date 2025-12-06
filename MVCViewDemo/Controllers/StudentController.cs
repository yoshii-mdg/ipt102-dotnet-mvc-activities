using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCViewDemo_DeGuzman.Models;

namespace MVCViewDemo_DeGuzman.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Create()
        {
            ViewBag.Courses = new MultiSelectList(
                new[] { "Programming", "Database", "Networking" }
            );
            return View();
        }

        // POST: Student/Create
        [HttpPost]  
        public ActionResult Create(Student student)
        {
            ViewBag.Courses = new MultiSelectList(
                new[] { "Programming", "Database", "Networking" },
                student.SelectedCourses
            );
            if (ModelState.IsValid)
            {
                return View("Details", student);
            }
            return View();
        }
    }
}