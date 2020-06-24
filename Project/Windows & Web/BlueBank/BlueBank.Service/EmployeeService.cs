using BlueBank.Model;
using BlueBank.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Service
{
    public class EmployeeService
    {
        bool createMode = false;

        EmployeeRepository employeeRepository = new EmployeeRepository();

        public bool SetEmployeeSupervisor (Employee employee)
        {
            return employeeRepository.SetEmployeeSupervisor(employee);
        }
        public List<EmployeeLookup> GetEmployeeLookups(string filter)
        {
            return employeeRepository.GetEmployeeLookups(filter);
        }
            public EmployeeDTO GetEmployeeInformation(int employeeId)
        {
            return employeeRepository.GetEmployeeInformation(employeeId);
        }

        public List<SupervisorLookup> GetSupervisorsByDepartment(int departmentId, int employeeType)
        {
            return employeeRepository.GetSupervisorsByDepartment(departmentId, employeeType);
        }

        public List<Employee> GetEmployeesByFilter(string lastName)
        {
            return employeeRepository.GetEmployeesByFilter(lastName);
        }
        
        public List<Employee> GetEmployeesByFilter(int employeeId)
        {
            return employeeRepository.GetEmployeesByFilter(employeeId);
        }

        public bool Create(Employee employee)
        {
            createMode = true;
            return IsValid(employee) ? employeeRepository.Insert(employee) : false;
        }

        public bool Update(Employee employee)
        {
            if (employeeRepository.HasBeenUpdated(employee))
            {
                employee.AddError(new Error(employee.Errors.Count() + 1, "This employee record has been updated after you retrieved it. Please reload before update", "Business"));
            }
            if(employee.DOB > DateTime.Now.AddYears(-55) && employee.Status == EmploymentStatus.Retired)
            {
                employee.AddError(new Error(employee.Errors.Count() + 1, "An employee cannot retire unless they have reached the age of 55", "Business"));
            }

            return IsValid(employee) ? employeeRepository.Update(employee) : false;
        }

        public bool UpdatePersonalInfo(EmployeePersonalInfoDTO employee)
        {
            if (employeeRepository.HasBeenUpdated(employee))
            {
                employee.AddError(new Error(employee.Errors.Count() + 1, "This employee record has been updated after you retrieved it. Please reload before updated", "Business"));
            }

            return IsValid(employee) ? employeeRepository.UpdatePersonalInfo(employee) : false;
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAll();
        }
        
        public List<Employee> GetAllUnReviwedEmployees()
        {
            return employeeRepository.GetAllUnreviewed();
        }

        private bool IsValidEntity(Employee employee)
        {
            ValidationContext context = new ValidationContext(employee);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(employee, context, results, true);

            foreach (ValidationResult r in results)
            {
                employee.AddError(new Error(employee.Errors.Count + 1, r.ErrorMessage, "Model"));
            }

            return isValid;
        }

        private bool IsValidEntity(EmployeePersonalInfoDTO employee)
        {
            ValidationContext context = new ValidationContext(employee);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(employee, context, results, true);

            foreach (ValidationResult r in results)
            {
                employee.AddError(new Error(employee.Errors.Count + 1, r.ErrorMessage, "Model"));
            }

            return isValid;
        }



        public bool IsValid(Employee employee)
        {

            if (createMode)
            {
                if (employee.SeniorityDate <= DateTime.Now.AddDays(-1))
                {
                    employee.AddError(new Error(employee.Errors.Count + 1, "Seniority Date cannot be earlier than the current date", "Business"));
                }
                if (employee.JobStartDate <= DateTime.Now.AddDays(-1))
                {
                    employee.AddError(new Error(employee.Errors.Count + 1, "Job Start Date cannot be earlier than the current date", "Business"));
                }
            }
           
            if (employee.DOB > DateTime.Now.AddYears(-18))
            {
                employee.AddError(new Error(employee.Errors.Count + 1, "An employee must be at least 18 years old", "Business"));
            }

            return IsValidEntity(employee) && employee.Errors.Count == 0;
        }

        public bool IsValid(EmployeePersonalInfoDTO employee)
        {

            return IsValidEntity(employee) && employee.Errors.Count == 0;
        }

        public bool NeedsNewSupervisor(Employee employee)
        {
            return employeeRepository.IsNewSupervisor(employee);
        }
    }
}
