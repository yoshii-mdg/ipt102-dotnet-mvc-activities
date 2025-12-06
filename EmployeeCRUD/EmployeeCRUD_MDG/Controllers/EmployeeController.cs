using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeCRUD_MDG.Models;

namespace EmployeeCRUD_MDG.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBContext db = new EmployeeDBContext();

        public ActionResult Index(string search, string sortOrder)
        {
            var employees = from e in db.Employees select e;

            // Apply search filter
            if (!string.IsNullOrEmpty(search))
                employees = employees.Where(e => e.FullName.Contains(search));

            // Sorting parameters for links
            ViewBag.SalarySortParam = String.IsNullOrEmpty(sortOrder) ? "salary_desc" : "";
            ViewBag.DeptSortParam = sortOrder == "Department" ? "dept_desc" : "Department";

            // Apply sorting based on sortOrder
            switch (sortOrder)
            {
                case "salary_desc":
                    employees = employees.OrderByDescending(e => e.Salary);
                    break;

                case "Department":
                    employees = employees.OrderBy(e => e.Department);
                    break;

                case "dept_desc":
                    employees = employees.OrderByDescending(e => e.Department);
                    break;

                default:
                    employees = employees.OrderBy(e => e.Salary);
                    break;
            }

            return View(employees.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.Employees.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            return View(db.Employees.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Employees.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var emp = db.Employees.FirstOrDefault(x => x.Id == id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



public class EmployeeDBContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
}


