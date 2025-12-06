using Microsoft.AspNetCore.Mvc;

namespace Lab_MVC_Controllers_murphy.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome to the Student Portal");
        }
        public IActionResult Profile(string name, int age)
        {
            ViewData["Name"] = "Student Name:" + name;
            ViewData["Age"] = "Student Age:" + age;

            return View();
        }

        public IActionResult List()
        {
            List<string> student = new List<string>
            {
                "Murphy",
                "John",
                "Matthew",
                "Lee",
                "Christopher"
            };

            return View(student);
        }
        public IActionResult Redirect()
        {
            return RedirectToAction("Index");
        }
    }
}
