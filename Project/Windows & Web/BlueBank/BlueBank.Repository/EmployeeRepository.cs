using BlueBank.DAL;
using BlueBank.Model;
using BlueBank.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Repository
{
    public class EmployeeRepository
    {
        public List<EmployeeLookup> GetEmployeeLookups(string filter)
        {
            List<EmployeeLookup> employeeLookups = new List<EmployeeLookup>();
            List<Employee> employees;

            if (int.TryParse(filter, out int employeeId))
            {
                employees = GetEmployeesByFilter(employeeId);
            }
            else
            {
                employees = GetEmployeesByFilter(filter);
            }

            foreach (Employee employee in employees)
            {
                employeeLookups.Add(new EmployeeLookup(employee.EmployeeId, $"{employee.FirstName}, {employee.LastName}"));
            }

            return employeeLookups;

        }

        public List<Employee> GetAll()
        {
            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("GetAllEmployee", CommandType.StoredProcedure);

            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in dt.Rows)
            {
                Employee employee = PopulateEmployeeObject(row);
                employees.Add(employee);
            }
            return employees;
        }

        public List<Employee> GetAllUnreviewed()
        {
            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("GetUnReviewedEmployees", CommandType.StoredProcedure);

            List<Employee> employees = new List<Employee>();
            foreach (DataRow row in dt.Rows)
            {
                Employee employee = PopulateEmployeeObject(row);
                employees.Add(employee);
            }
            return employees;
        }

        public List<SupervisorLookup> GetSupervisorsByDepartment(int departmentId, int employeeType)
        {
            DataAccess db = new DataAccess();

            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@DepartmentId", departmentId, SqlDbType.Int)
            };
            string spName = "";

            if (employeeType == (int)EmployeeType.HREmployee)
            {
                spName = "GetHREmployees";
            }
            else
            {
                spName = "GetRegularEmployees";
            }
            DataTable dt = db.Execute(spName, CommandType.StoredProcedure, parms);

            List<SupervisorLookup> supervisors = new List<SupervisorLookup>();
            foreach (DataRow row in dt.Rows)
            {
                SupervisorLookup supervisor = new SupervisorLookup()
                {
                    EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                    FullName = row["FullName"].ToString()
                };

                supervisors.Add(supervisor);

            }

            return supervisors;
        }

        public EmployeeDTO GetEmployeeInformation(int employeeId)
        {
            DataAccess db = new DataAccess();

            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", employeeId, SqlDbType.Int)
            };

            DataTable dt = db.Execute("GetEmployeeInformation", CommandType.StoredProcedure, parms);

            return dt.Rows.Count > 0 ? PopulateEmployeeDTOObject(dt.Rows[0]) : null;
        }

        public List<Employee> GetEmployeesByFilter(string lastName)
        {
            DataAccess db = new DataAccess();

            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", 0, SqlDbType.Int, ParameterDirection.Input, 0),
                new ParmStruct("@LastName", lastName, SqlDbType.NVarChar, ParameterDirection.Input, 50)
            };

            DataTable dt = db.Execute("GetEmployeesByFilter", CommandType.StoredProcedure, parms);

            List<Employee> matchingEmployees = new List<Employee>();

            foreach (DataRow row in dt.Rows)
            {
                Employee employee = PopulateEmployeeObject(row);

                matchingEmployees.Add(employee);

            }

            return matchingEmployees;
        }

        public bool SetEmployeeSupervisor(Employee employee)
        {
            DataAccess db = new DataAccess();

            int supervisorType = employee.EmployeeType == EmployeeType.RegularEmployee ? (int)EmployeeType.RegularSupervisor : (int)EmployeeType.HRSupervisor;

            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", employee.SupervisorId, SqlDbType.Int),
                new ParmStruct("@EmployeeType", supervisorType, SqlDbType.Int)
            };

            return db.ExecuteNonQuery("SetEmployeeSupervisor", CommandType.StoredProcedure, parms) > 0;
        }
        public List<Employee> GetEmployeesByFilter(int employeeId)
        {
            DataAccess db = new DataAccess();

            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", employeeId, SqlDbType.Int, ParameterDirection.Input, 0),
                new ParmStruct("@LastName", "NULL", SqlDbType.NVarChar, ParameterDirection.Input, 50)
            };

            DataTable dt = db.Execute("GetEmployeesByFilter", CommandType.StoredProcedure, parms);

            List<Employee> matchingEmployees = new List<Employee>();

            foreach (DataRow row in dt.Rows)
            {
                Employee employee = PopulateEmployeeObject(row);

                matchingEmployees.Add(employee);

            }

            return matchingEmployees;
        }

        public bool Insert(Employee employee)
        {

            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@EmployeeId", 0, SqlDbType.Int, ParameterDirection.InputOutput));
            parms.Add(new ParmStruct("@SIN", employee.SIN, SqlDbType.NVarChar, ParameterDirection.InputOutput, 11));
            parms.Add(new ParmStruct("@FirstName", employee.FirstName, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@MiddleInitial", employee.MiddleInitial, SqlDbType.Char, ParameterDirection.Input, 1));
            parms.Add(new ParmStruct("@LastName", employee.LastName, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@DateOfBirth", employee.DOB, SqlDbType.Date, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@StreetAddress", employee.StreetAddress, SqlDbType.NVarChar, ParameterDirection.Input, 200));
            parms.Add(new ParmStruct("@Country", employee.Country, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@Province", employee.Province, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@City", employee.City, SqlDbType.NVarChar, ParameterDirection.Input, 255));
            parms.Add(new ParmStruct("@PostalCode", employee.PostalCode, SqlDbType.NVarChar, ParameterDirection.Input, 7));
            parms.Add(new ParmStruct("@SeniorityDate", employee.SeniorityDate, SqlDbType.Date, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@WorkPhoneNumber", employee.WorkPhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input, 15));
            parms.Add(new ParmStruct("@CellPhoneNumber", employee.CellPhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input, 15));
            parms.Add(new ParmStruct("@EmailAddress", employee.EmailAddress, SqlDbType.NVarChar, ParameterDirection.Input, 255));
            parms.Add(new ParmStruct("@DepartmentId", employee.DepartmentId, SqlDbType.Int, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@EmployeeType", employee.EmployeeType, SqlDbType.Int, ParameterDirection.Input, 0));

            if (employee.SupervisorId != 0)
            {
                parms.Add(new ParmStruct("@SupervisorId", employee.SupervisorId, SqlDbType.Int, ParameterDirection.Input, 0));
            }

            parms.Add(new ParmStruct("@JobId", employee.JobId, SqlDbType.Int, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@JobStartDate", employee.JobStartDate, SqlDbType.Date, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@Status", (int)employee.Status, SqlDbType.Int, ParameterDirection.Input, 0));


            DataAccess db = new DataAccess();
            bool isSupervisor = false;
            if (GetSupervisorsByDepartment(employee.DepartmentId, (int)employee.EmployeeType).Count() == 0)
            {
                isSupervisor = true;
            }
            if (db.ExecuteNonQuery("InsertEmployee", CommandType.StoredProcedure, parms) > 0)
            {
                employee.EmployeeId = (int)parms[0].Value;

                if (isSupervisor)
                {
                    if (SetEmployeeSupervisor(employee))
                    {
                        return true;
                    }
                        
                }
                return true;
            }
            return false;
        }

        public bool HasBeenUpdated(Employee employee)
        {
            byte[] timestamp = (byte[])new DataAccess().ExecuteScaler($"SELECT Timestamp From employee WHERE EmployeeID = {employee.EmployeeId}", CommandType.Text);

            for (int i = 0; i < timestamp.Length; i++)
            {
                if(timestamp[i] != employee.TimeStamp[i])
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasBeenUpdated(EmployeePersonalInfoDTO employee)
        {
            byte[] timestamp = (byte[])new DataAccess().ExecuteScaler($"SELECT Timestamp From employee WHERE EmployeeID = {employee.EmployeeId}", CommandType.Text);

            for (int i = 0; i < timestamp.Length; i++)
            {
                if (timestamp[i] != employee.TimeStamp[i])
                {
                    return true;
                }
            }

            return false;
        }

        public bool Update(Employee employee)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@Timestamp", employee.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
            parms.Add(new ParmStruct("@EmployeeId", employee.EmployeeId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@SIN", employee.SIN, SqlDbType.NVarChar, ParameterDirection.InputOutput, 11));
            parms.Add(new ParmStruct("@FirstName", employee.FirstName, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@MiddleInitial", employee.MiddleInitial, SqlDbType.Char, ParameterDirection.Input, 1));
            parms.Add(new ParmStruct("@LastName", employee.LastName, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@DateOfBirth", employee.DOB, SqlDbType.Date, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@StreetAddress", employee.StreetAddress, SqlDbType.NVarChar, ParameterDirection.Input, 200));
            parms.Add(new ParmStruct("@Country", employee.Country, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@Province", employee.Province, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@City", employee.City, SqlDbType.NVarChar, ParameterDirection.Input, 255));
            parms.Add(new ParmStruct("@PostalCode", employee.PostalCode, SqlDbType.NVarChar, ParameterDirection.Input, 7));
            parms.Add(new ParmStruct("@SeniorityDate", employee.SeniorityDate, SqlDbType.Date, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@WorkPhoneNumber", employee.WorkPhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input, 15));
            parms.Add(new ParmStruct("@CellPhoneNumber", employee.CellPhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input, 15));
            parms.Add(new ParmStruct("@EmailAddress", employee.EmailAddress, SqlDbType.NVarChar, ParameterDirection.Input, 255));
            parms.Add(new ParmStruct("@DepartmentId", employee.DepartmentId, SqlDbType.Int, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@EmployeeType", employee.EmployeeType, SqlDbType.Int, ParameterDirection.Input, 0));
            if(employee.SupervisorId != 0)
            {
                parms.Add(new ParmStruct("@SupervisorId", employee.SupervisorId, SqlDbType.Int, ParameterDirection.Input, 0));
            }
            else
            {
                parms.Add(new ParmStruct("@SupervisorId", DBNull.Value, SqlDbType.Int, ParameterDirection.Input, 0));
            }
            
            parms.Add(new ParmStruct("@JobId", employee.JobId, SqlDbType.Int, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@JobStartDate", employee.JobStartDate, SqlDbType.Date, ParameterDirection.Input, 0));
            parms.Add(new ParmStruct("@Status", (int)employee.Status, SqlDbType.Int, ParameterDirection.Input, 0));
            if (employee.TerminatedDate.HasValue)
            {
                parms.Add(new ParmStruct("@TerminatedDate", employee.TerminatedDate.Value, SqlDbType.Date, ParameterDirection.Input, 0));
            }
            else
            {
                parms.Add(new ParmStruct("@TerminatedDate", DBNull.Value, SqlDbType.Date, ParameterDirection.Input, 0));

            }

            if (employee.RetiredDate.HasValue)
            {
                parms.Add(new ParmStruct("@RetiredDate", employee.RetiredDate.Value, SqlDbType.Date, ParameterDirection.Input, 0));
            }
            else
            {
                parms.Add(new ParmStruct("@RetiredDate",DBNull.Value, SqlDbType.Date, ParameterDirection.Input, 0));
            }


            DataAccess db = new DataAccess();
            bool isSupervisor = false;
            if (GetSupervisorsByDepartment(employee.DepartmentId, (int)employee.EmployeeType).Count() == 0)
            {
                isSupervisor = true;
            }
            if (db.ExecuteNonQuery("UpdateEmployee", CommandType.StoredProcedure, parms) > 0)
            {
                employee.TimeStamp = (byte[])parms[0].Value;

                if (isSupervisor)
                {
                    SetEmployeeSupervisor(employee);
                }
                return true;
            }
            return false;
        }

        public bool UpdatePersonalInfo(EmployeePersonalInfoDTO employee)
        {
            /*UpdatePersonalInfo*/
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@Timestamp", employee.TimeStamp, SqlDbType.Timestamp, ParameterDirection.InputOutput));
            parms.Add(new ParmStruct("@EmployeeId", employee.EmployeeId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@StreetAddress", employee.StreetAddress, SqlDbType.NVarChar, ParameterDirection.Input, 200));
            parms.Add(new ParmStruct("@Country", employee.Country, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@Province", employee.Province, SqlDbType.NVarChar, ParameterDirection.Input, 50));
            parms.Add(new ParmStruct("@City", employee.City, SqlDbType.NVarChar, ParameterDirection.Input, 255));
            parms.Add(new ParmStruct("@PostalCode", employee.PostalCode, SqlDbType.NVarChar, ParameterDirection.Input, 7));
            parms.Add(new ParmStruct("@WorkPhoneNumber", employee.WorkPhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input, 15));
            parms.Add(new ParmStruct("@CellPhoneNumber", employee.CellPhoneNumber, SqlDbType.NVarChar, ParameterDirection.Input, 15));
           

            DataAccess db = new DataAccess();
            bool isSupervisor = false;
           
            if (db.ExecuteNonQuery("UpdatePersonalInfo", CommandType.StoredProcedure, parms) > 0)
            {
                employee.TimeStamp = (byte[])parms[0].Value;
                return true;
            }
            return false;

        }

        public bool IsNewSupervisor(Employee employee)
        {
            DataAccess db = new DataAccess();
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@DepartmentId", employee.DepartmentId, SqlDbType.Int),
                new ParmStruct("@SupervisorId", employee.SupervisorId, SqlDbType.Int)
            };
            int employeeCount = Convert.ToInt32(db.ExecuteScaler("GetEmployeeCountByDepartment", CommandType.StoredProcedure, parms));

            return employeeCount == 10;

        }

        public Employee PopulateEmployeeObject(DataRow row)
        {
            Employee employee = new Employee();

            employee.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
            employee.SIN = row["SIN"].ToString();
            employee.LastName = row["LastName"].ToString();
            employee.MiddleInitial = row["MiddleInitial"].ToString();
            employee.FirstName = row["FirstName"].ToString();
            employee.DOB = Convert.ToDateTime(row["DateOfBirth"]);
            employee.Country = row["Country"].ToString();
            employee.Province = row["Province"].ToString();
            employee.StreetAddress = row["StreetAddress"].ToString();
            employee.City = row["City"].ToString();
            employee.PostalCode = row["PostalCode"].ToString();
            employee.SeniorityDate = Convert.ToDateTime(row["SeniorityDate"]);
            employee.WorkPhoneNumber = row["WorkPhoneNumber"].ToString();
            employee.CellPhoneNumber = row["CellPhoneNumber"].ToString();
            employee.EmailAddress = row["EmailAddress"].ToString();
            employee.DepartmentId = Convert.ToInt32(row["DepartmentId"]);
            employee.EmployeeType = (EmployeeType)row["EmployeeType"];
            employee.OfficeLocation = row["OfficeLocation"].ToString();
            if (row["SupervisorId"] != DBNull.Value)
            {
                employee.SupervisorId = Convert.ToInt32(row["SupervisorId"]);
            }
            employee.JobId = Convert.ToInt32(row["JobId"]);
            employee.JobStartDate = Convert.ToDateTime(row["JobStartDate"]);
            employee.Status = (EmploymentStatus)row["Status"];
            employee.TimeStamp = (byte[])row["TimeStamp"];

            return employee;
        }

        public EmployeeDTO PopulateEmployeeDTOObject(DataRow row)
        {
            EmployeeDTO employee = new EmployeeDTO();


            employee.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
            employee.SIN = row["SIN"].ToString();
            employee.LastName = row["LastName"].ToString();
            employee.MiddleInitial = row["MiddleInitial"].ToString();
            employee.FirstName = row["FirstName"].ToString();
            employee.DOB = Convert.ToDateTime(row["DateOfBirth"]);
            employee.Country = row["Country"].ToString();
            employee.Province = row["Province"].ToString();
            employee.StreetAddress = row["StreetAddress"].ToString();
            employee.City = row["City"].ToString();
            employee.PostalCode = row["PostalCode"].ToString();
            employee.SeniorityDate = Convert.ToDateTime(row["SeniorityDate"]);
            employee.WorkPhoneNumber = row["WorkPhoneNumber"].ToString();
            employee.CellPhoneNumber = row["CellPhoneNumber"].ToString();
            employee.EmailAddress = row["EmailAddress"].ToString();
            employee.DepartmentName = row["DepartmentName"].ToString();
            employee.EmployeeType = (EmployeeType)row["EmployeeType"];
            employee.SupervisorName = row["Supervisor"].ToString();
            employee.JobPosition = row["JobPosition"].ToString();
            employee.JobStartDate = Convert.ToDateTime(row["JobStartDate"]);
            employee.Status = (EmploymentStatus)row["Status"];

            //if (row["TerminatedDate"] != DBNull.Value)
            //{
            //    employee.TerminatedDate = (DateTime)row["TerminatedDate"];
            //}
            // if (row["RetiredDate"] != DBNull.Value)
            //{
            //    employee.RetiredDate = (DateTime)row["RetiredDate"];
            //}


            return employee;
        }
    }
}
