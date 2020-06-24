using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBank.DAL;
using System.Data;
using BlueBank.Types;

namespace BlueBank.Repository
{
    public class LoginRepository
    {
        private DataAccess db = new DataAccess();
        public LoginDTO GetLoginInformation(Login login)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", login.EmployeeId, SqlDbType.Int),
                new ParmStruct("@Password", login.Password, SqlDbType.NVarChar,size:50)
            };
            DataTable dt = db.Execute("GetLoginInformation", CommandType.StoredProcedure, parms);
            return dt.Rows.Count > 0 ? PopulateLoginDTO(dt.Rows[0]) : null;
        }

        public bool Create (Login login)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", login.EmployeeId, SqlDbType.Int),
                new ParmStruct("@Password", login.Password, SqlDbType.NVarChar,size:50)
            };
            if (IsValidId(login.EmployeeId))
            {
                return db.ExecuteNonQuery("CreateLogin", CommandType.StoredProcedure, parms) > 0;
            }
            else
            {
                login.AddError(new Error(login.Errors.Count() + 1, "This employee Id does not exist.", "Business"));
                return false;
            }
            
        }

        private bool IsValidId(int employeeId)
        {
            return (int)db.ExecuteScaler($"SELECT COUNT(*) FROM Employee WHERE EmployeeId = {employeeId}", CommandType.Text) > 0;
        }

        private LoginDTO PopulateLoginDTO(DataRow row)
        {
            return new LoginDTO(Convert.ToInt32(row["EmployeeId"]), row["EmployeeName"].ToString(), (EmployeeType)Convert.ToInt32(row["EmployeeType"]), (EmploymentStatus)row["Status"], row["Department"].ToString());
        }
    }
}
