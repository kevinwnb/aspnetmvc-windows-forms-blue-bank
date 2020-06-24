using BlueBank.Model;
using BlueBank.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBank.WebFrontEnd.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            DepartmentService departmentService = new DepartmentService();

            List<DepartmentLookup> departments = new List<DepartmentLookup>();

            if((int)Session["employeeType"] == (int)EmployeeType.HRSupervisor || (int)Session["employeeType"] == (int)EmployeeType.HREmployee)
            {
                departments = departmentService.GetDepartmentLookups();
            }
            else
            {
                Department department = departmentService.GetDepartment((int)Session["employeeId"]);

                DepartmentLookup dep = new DepartmentLookup() { Id = department.DepartmentId, Name = department.Name };

                departments.Add(dep);
            }

            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentService departmentService = new DepartmentService();

            Department department = departmentService.GetDepartmentById(id);
            Session["TimeStamp"] = department.TimeStamp;

            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                DepartmentService departmentService = new DepartmentService();
                department.TimeStamp = (byte[])Session["TimeStamp"];

                if (departmentService.UpdateDepartment(department))
                {
                    ViewBag.Updated = true;
                }

                return View(department);
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
