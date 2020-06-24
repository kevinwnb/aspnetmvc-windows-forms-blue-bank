using BlueBank.Model;
using BlueBank.Service;
using BlueBank.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBank.WebAPI.Controllers
{
    [RoutePrefix("api/employees")]
    public class EmployeeController : ApiController
    {
        EmployeeService employeeService = new EmployeeService();

        [Route("{id}")]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                //Employee employee = employeeService.GetEmployeesByFilter(id)[0];
                List<Job> jobs = new JobService().GetJobs();

                List<Employee> employees = employeeService.GetAllEmployees();

                employees = employees.Where(emp => emp.DepartmentId == id).ToList();
                if (employees == null)
                {
                    return NotFound();
                }
                List<EmployeeAndroidVM> vm = new List<EmployeeAndroidVM>();

                foreach (Employee employee in employees)
                {
                    EmployeeAndroidVM emp = new EmployeeAndroidVM()
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        MiddleInitial = employee.MiddleInitial,
                        LastName = employee.LastName,
                        EmailAddress = employee.EmailAddress,
                        OfficeLocation = employee.OfficeLocation,
                        JobPosition = jobs.FirstOrDefault(j => j.Id == employee.JobId).Name,
                        WorkPhoneNumber = employee.WorkPhoneNumber

                    };
                    vm.Add(emp);
                }

                return Ok(vm.OrderBy(v => v.LastName));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.ToString());
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllEmployees(string lastName = "")
        {
            try
            {
                
                List<Employee> employees = employeeService.GetAllEmployees();

                if (lastName != "")
                {
                    employees = employees.Where(a => a.LastName.ToLower().StartsWith(lastName.ToLower())).ToList();
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            try
            {
                //List<Employee> employees = employeeService.GetAllEmployees();

                //return Ok(employees);

                List<Employee> employees = employeeService.GetAllEmployees();
                List<Job> jobs = new JobService().GetJobs();

                List<EmployeeAndroidVM> vm = new List<EmployeeAndroidVM>();

                foreach(Employee employee in employees)
                {
                    EmployeeAndroidVM emp = new EmployeeAndroidVM()
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        MiddleInitial = employee.MiddleInitial,
                        LastName = employee.LastName,
                        EmailAddress = employee.EmailAddress,
                        OfficeLocation = employee.OfficeLocation,
                        JobPosition = jobs.FirstOrDefault(j => j.Id == employee.JobId).Name,
                        WorkPhoneNumber = employee.WorkPhoneNumber

                    };
                    vm.Add(emp);
                }

                return Ok(vm.OrderBy(v => v.LastName));
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

      
        [HttpGet]
        [Route("departments")]
        public IHttpActionResult GetAllDepartments()
        {
            try
            {

                List<DepartmentLookup> departmentLookups = new DepartmentService().GetDepartmentLookups();

                
                return Ok(departmentLookups);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
    }
}
