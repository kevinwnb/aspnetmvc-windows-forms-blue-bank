using BlueBank.DAL;
using BlueBank.Model;
using BlueBank.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Repository
{
    public class DepartmentRepository
    {
        public List<DepartmentLookup> GetDepartmentLookups()
        {
            DataAccess db = new DataAccess();

            DataTable dt = db.Execute("GetDepartmentLookups", CommandType.StoredProcedure);

            List<DepartmentLookup> departments = new List<DepartmentLookup>();
            foreach (DataRow row in dt.Rows)
            {
                DepartmentLookup department = new DepartmentLookup()
                {
                    Id = Convert.ToInt32(row["DepartmentId"]),
                    Name = row["Name"].ToString()
                };

                departments.Add(department);
            }
            return departments;
        }

        public bool Insert(Department department)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@Name", department.Name, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@Description", department.Description, SqlDbType.NVarChar, ParameterDirection.Input, 255));
            parms.Add(new ParmStruct("@InvocationDate", department.InvocationDate, SqlDbType.Date, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("InsertDepartment", CommandType.StoredProcedure, parms) > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsEmpty(Department department)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@DepartmentId", department.DepartmentId, SqlDbType.Int, ParameterDirection.Input, 30));

            DataAccess db = new DataAccess();
            int count = (int)db.ExecuteScaler("GetEmployeesByDepartment", CommandType.StoredProcedure, parms);

            return count == 0;

        }

        public bool Delete(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@DepartmentId", id, SqlDbType.Int, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("DeleteDepartment", CommandType.StoredProcedure, parms) > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(Department department)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@DepartmentId", department.DepartmentId, SqlDbType.Int, ParameterDirection.Input));
            parms.Add(new ParmStruct("@Name", department.Name, SqlDbType.NVarChar, ParameterDirection.Input, 30));
            parms.Add(new ParmStruct("@Description", department.Description, SqlDbType.NVarChar, ParameterDirection.Input, 255));
            parms.Add(new ParmStruct("@InvocationDate", department.InvocationDate, SqlDbType.Date, ParameterDirection.Input));

            DataAccess db = new DataAccess();
            if (db.ExecuteNonQuery("UpdateDepartment", CommandType.StoredProcedure, parms) > 0)
            {
                return true;
            }
            return false;
        }

        public Department GetDepartment(int employeeId)
        {
            /*            GetDepartment
            */
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@EmployeeId", employeeId, SqlDbType.Int, ParameterDirection.Input));

            DataTable dt = new DataAccess().Execute("GetDepartment", CommandType.StoredProcedure, parms);

            List<Department> departments = new List<Department>();

            foreach (DataRow row in dt.Rows)
            {
                Department department = new Department();
                department.DepartmentId = (int)row["DepartmentId"];
                department.Name = row["Name"].ToString();
                department.InvocationDate = (DateTime)row["InvocationDate"];
                department.Description = row["Description"].ToString();
                department.TimeStamp = (byte[])row["TimeStamp"];

                departments.Add(department);
            }

            return departments[0];
        }
        public Department GetDepartmentById(int id)
        {
            List<ParmStruct> parms = new List<ParmStruct>();
            parms.Add(new ParmStruct("@DepartmentId", id, SqlDbType.Int, ParameterDirection.Input));

            DataTable dt = new DataAccess().Execute("GetDepartmentById", CommandType.StoredProcedure, parms);

            List<Department> departments = new List<Department>();

            foreach (DataRow row in dt.Rows)
            {
                Department department = new Department();
                department.DepartmentId = (int)row["DepartmentId"];
                department.Name = row["Name"].ToString();
                department.InvocationDate = (DateTime)row["InvocationDate"];
                department.Description = row["Description"].ToString();
                department.TimeStamp = (byte[])row["TimeStamp"];

                departments.Add(department);
            }

            return departments[0];
        }

        public bool HasBeenUpdated(Department department)
        {
            byte[] timestamp = (byte[])new DataAccess().ExecuteScaler($"SELECT Timestamp From department WHERE DepartmentId = {department.DepartmentId}", CommandType.Text);

            for (int i = 0; i < timestamp.Length; i++)
            {
                if (timestamp[i] != department.TimeStamp[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
