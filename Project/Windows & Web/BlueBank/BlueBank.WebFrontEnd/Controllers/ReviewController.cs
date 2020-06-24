using BlueBank.Model;
using BlueBank.Service;
using BlueBank.WebFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBank.WebFrontEnd.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            EmployeeService employeeService = new EmployeeService();

            int supervisorId = (int)Session["employeeId"];

            EmployeeDTO supervisor = employeeService.GetEmployeeInformation(supervisorId);


            SupervisorEmployeesVM vm = new SupervisorEmployeesVM();

            if (supervisor.MiddleInitial != "NULL" && supervisor.MiddleInitial.Trim() != string.Empty)
            {
                vm.SupervisorFullName = $"{supervisor.FirstName} {supervisor.MiddleInitial} {supervisor.LastName}";
            }
            else
            {
                vm.SupervisorFullName = $"{supervisor.FirstName} {supervisor.LastName}";
            }
            
            vm.employees = employeeService.GetAllUnReviwedEmployees().Where(emp => emp.SupervisorId == supervisorId).ToList();

            return View(vm);
        }

        public ActionResult List()
        {
            if (System.Web.HttpContext.Current.Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ReviewService reviewService = new ReviewService();

            int employeeId = (int)Session["employeeId"];

            List<ReviewVM> vm = new List<ReviewVM>();

            foreach (Review review in reviewService.GetReviews(employeeId))
            {
                ReviewVM reviewVM = new ReviewVM();

                Employee employee = new EmployeeService().GetAllEmployees().Where(emp => emp.EmployeeId == employeeId).ToList()[0];
                Employee supervisor = new EmployeeService().GetAllEmployees().Where(emp => emp.EmployeeId == review.SupervisorId).ToList()[0];

                if (employee.MiddleInitial != "NULL" && employee.MiddleInitial.Trim() != string.Empty)
                {
                    reviewVM.EmployeeFullName = $"{employee.FirstName} {employee.MiddleInitial} {employee.LastName}";
                }
                else
                {
                    reviewVM.EmployeeFullName = $"{employee.FirstName} {employee.LastName}";
                }


                if (supervisor.MiddleInitial != "NULL" && supervisor.MiddleInitial.Trim() != string.Empty)
                {
                    reviewVM.SupervisorFullName = $"{supervisor.FirstName} {supervisor.MiddleInitial} {supervisor.LastName}";
                }
                else
                {
                    reviewVM.SupervisorFullName = $"{supervisor.FirstName} {supervisor.LastName}";
                }

                reviewVM.Quarter = reviewService.GetQuarter(review.Date);

                reviewVM.review = review;
                Session["vm"] = vm;
                vm.Add(reviewVM);
            }

            foreach(ReviewVM rvm in vm)
            {
                
            }

            vm = vm.OrderBy(v => v.review.Date).ToList();

            return View(vm);
        }

        public ActionResult Details(int id)
        {
            List<ReviewVM> vms = (List<ReviewVM>)Session["vm"];


            ReviewVM vm = vms.FirstOrDefault(v => v.review.ReviewId == id);

            return View(vm);

        }

        // GET: Review/Create
        public ActionResult Create(int id)
        {
            ReviewVM vm = new ReviewVM();
            vm.review = new Review();
            EmployeeService employeeService = new EmployeeService();

            vm.review.EmployeeId = id;
            vm.review.SupervisorId = (int)Session["employeeId"];
            vm.review.Date = DateTime.Now;
            vm.review.Errors = new List<Error>();

            Employee employee = employeeService.GetAllEmployees().Where(emp => emp.EmployeeId == vm.review.EmployeeId).ToList()[0];

            if (employee.MiddleInitial != "NULL" && employee.MiddleInitial.Trim() != string.Empty)
            {
                vm.EmployeeFullName = $"{employee.FirstName} {employee.MiddleInitial} {employee.LastName}";
            }
            else
            {
                vm.EmployeeFullName = $"{employee.FirstName} {employee.LastName}";
            }


            Employee supervisor = employeeService.GetAllEmployees().Where(emp => emp.EmployeeId == vm.review.SupervisorId).ToList()[0];

            if (supervisor.MiddleInitial != "NULL" && supervisor.MiddleInitial.Trim() != string.Empty)
            {
                vm.SupervisorFullName = $"{supervisor.FirstName} {supervisor.MiddleInitial} {supervisor.LastName}";
            }
            else
            {
                vm.SupervisorFullName = $"{supervisor.FirstName} {supervisor.LastName}";
            }

            return View(vm);
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(ReviewVM vm)
        {
            try
            {
                ReviewService reviewService = new ReviewService();
                if (reviewService.CreateReview(vm.review)){
                    ViewBag.Success = true;
                }
                
                return View(vm);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
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
