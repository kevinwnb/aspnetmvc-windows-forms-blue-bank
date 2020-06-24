using BlueBank.Model;
using BlueBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBank.Service
{
    public class JobService
    {
        JobRepository jobRepository = new JobRepository();
        public List<Job> GetJobs()
        {
            return jobRepository.RetrieveJobs();
        }
    }
}
