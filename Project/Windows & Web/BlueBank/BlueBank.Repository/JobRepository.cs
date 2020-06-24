using BlueBank.DAL;
using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Repository
{
    public class JobRepository
    {
        public List<Job> RetrieveJobs()
        {
            DataAccess db = new DataAccess();

            DataTable dt = db.Execute("GetJobs", CommandType.StoredProcedure);

            List<Job> jobs = new List<Job>();
            foreach(DataRow row in dt.Rows)
            {
                Job job = new Job()
                {
                    Id = Convert.ToInt32(row["JobId"]),
                    Name = row["Name"].ToString()
                };

                jobs.Add(job);
            
            }

            return jobs;
        }
    }
}
