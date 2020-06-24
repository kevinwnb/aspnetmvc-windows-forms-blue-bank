using BlueBank.Model;
using BlueBank.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Service
{
    public class DepartmentService
    {
        private DepartmentRepository departmentRepository = new DepartmentRepository();

        public List<DepartmentLookup> GetDepartmentLookups()
        {
            return departmentRepository.GetDepartmentLookups();
        }

        public bool DeleteDepartment(Department department)
        {
            if (departmentRepository.IsEmpty(department))
            {
                return departmentRepository.Delete(department.DepartmentId);

            }

            department.AddError(new Error(department.Errors.Count(), "This department is not empty, you cannot delete it.", "Business"));

            return false;

            
        }
        public bool CreateDepartment (Department department)
        {
            if (department.InvocationDate.CompareTo(DateTime.Now.Date) < 0)
            {
                department.AddError(new Error(department.Errors.Count + 1, "Invocation date cannot be earlier than today.", "Business"));
            }
            return IsValid(department) ? departmentRepository.Insert(department) : false;
        }

        public bool UpdateDepartment(Department department)
        {
            if (departmentRepository.HasBeenUpdated(department))
            {
                department.AddError(new Error(department.Errors.Count() + 1, "This department record has been updated after you retrieved it. Please reload before update", "Business"));
            }
            return IsValid(department) ? departmentRepository.Update(department) : false;
        }

        public Department GetDepartment(int employeeId)
        {
            return departmentRepository.GetDepartment(employeeId);
        } 
        
        public Department GetDepartmentById(int id)
        {
            return departmentRepository.GetDepartmentById(id);
        }

        private bool IsValidEntity(Department department)
        {
            ValidationContext context = new ValidationContext(department);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(department, context, results, true);

            foreach (ValidationResult r in results)
            {
                department.AddError(new Error(department.Errors.Count + 1,r.ErrorMessage, "Model"));
            }

            return isValid;
        }

        private bool IsValid(Department department)
        {
            
            return IsValidEntity(department) && department.Errors.Count() == 0;
        }
    }
}
