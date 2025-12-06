using Microsoft.AspNetCore.Mvc;

namespace Lab_MVC_Controllers_murphy.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome to the Student Portal");
        }
        public  IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
        public IActionResult RedirectAction()
        {
            return RedirectToAction("Index");
        }
    }
}
