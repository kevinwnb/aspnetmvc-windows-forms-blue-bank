using BlueBank.Model;
using BlueBank.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlueBank.WebFrontEnd.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService employeeService = new EmployeeService();
        // GET: Employee
        public ActionResult Index(string searchBy, string search)
        {
            if (System.Web.HttpContext.Current.Session["employeeId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.errorMessage = null;
            ViewBag.firstLoad = true;

            List<EmployeeLookup> employeeLookups = new List<EmployeeLookup>();
            
            if(search == string.Empty)
            {
                ViewBag.errorMessage = "Please enter a search criteria.";
            }
            else if (searchBy == "Id" && !int.TryParse(search, out int employeeId))
            {
                ViewBag.errorMessage = "Employee Id must be 8 digit";
            }
            else if (searchBy == "LastName" && int.TryParse(search, out int _emplooyeeId))
            {
                ViewBag.errorMessage = "Please enter a valid last name";
            }

            if (ViewBag.errorMessage == null && search != null)
            {
                ViewBag.firstLoad = false;
                employeeLookups = employeeService.GetEmployeeLookups(search);
            }

            return View(employeeLookups.ToList());
            
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                Employee employee = employeeService.GetEmployeesByFilter(id.Value)[0];

                Session["TimeStamp"] = employee.TimeStamp;
                if (employee == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Employee", "Index"));
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                ViewBag.Updated = false;
                if (employee == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                EmployeePersonalInfoDTO emp = new EmployeePersonalInfoDTO()
                {
                    EmployeeId = employee.EmployeeId,
                    Country = employee.Country,
                    City = employee.City,
                    PostalCode = employee.PostalCode,
                    StreetAddress = employee.StreetAddress,
                    CellPhoneNumber = employee.CellPhoneNumber,
                    WorkPhoneNumber = employee.WorkPhoneNumber,
                    Province = employee.Province

                };

                emp.TimeStamp = (byte[])Session["TimeStamp"];
                if (employeeService.UpdatePersonalInfo(emp))
                {
                    ViewBag.Updated = true;
                    return View(employee);
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Employee", "Index"));
            }
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                EmployeeDTO employeeDTO = employeeService.GetEmployeeInformation(id.Value);

                if (employeeDTO == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

                return View(employeeDTO);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Employee", "Index"));
            }
        }
    }
}