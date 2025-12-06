using SecurityDemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityDemoMVC.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower()
                                      && u.UserPassword == model.UserPassword);

                if (user != null)
                {
                    // Get roles of the user
                    var roles = (from ur in context.UserRolesMappings
                                 join r in context.RoleMasters on ur.RoleID equals r.ID
                                 where ur.UserID == user.ID
                                 select r.RollName).ToArray();

                    // Create the auth ticket with roles
                    var authTicket = new FormsAuthenticationTicket(
                        1,                               // Version
                        user.UserName,                   // Username
                        DateTime.Now,                    // Issue date
                        DateTime.Now.AddMinutes(60),     // Expiration
                        false,                           // Persistent
                        string.Join(",", roles)          // Roles
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

                    // === START: NEW REDIRECT LOGIC ===

                    // Check if the user has the "Admin" role
                    if (roles.Contains("Admin"))
                    {
                        // Redirect Admin users to the AdminOnly page
                        return RedirectToAction("AdminOnly", "Employees");
                    }
                    else
                    {
                        // Redirect all other logged-in users to the main Employees index page
                        return RedirectToAction("Index", "Employees");
                    }
                    // === END: NEW REDIRECT LOGIC ===
                }

                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}