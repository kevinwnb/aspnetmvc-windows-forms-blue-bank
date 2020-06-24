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
    public class ReviewRepository
    {
        public bool InsertReview(Review review)
        {
            List<ParmStruct> parms = new List<ParmStruct>();

            parms.Add(new ParmStruct("@EmployeeId", review.EmployeeId, SqlDbType.Int));
            parms.Add(new ParmStruct("@SupervisorId", review.SupervisorId, SqlDbType.Int));
            parms.Add(new ParmStruct("@Date", review.Date, SqlDbType.Date));
            parms.Add(new ParmStruct("@Performance", EnumObject.GetDescription(review.Performance), SqlDbType.NVarChar, size: 50));
            parms.Add(new ParmStruct("@Comment", review.Comment, SqlDbType.Text));

            DataAccess db = new DataAccess();

            return db.ExecuteNonQuery("InsertReview", CommandType.StoredProcedure, parms) > 0;

        }

        public DateTime? GetLastReviewDate(int employeeId)
        {
            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", employeeId,SqlDbType.Int)
            };

            DataAccess db = new DataAccess();

            return db.ExecuteScaler("GetLastReviewDate", CommandType.StoredProcedure, parms) == DBNull.Value ? null : (DateTime?)db.ExecuteScaler("GetLastReviewDate", CommandType.StoredProcedure, parms);

        }

        public List<Review> GetEmployeeReviews(int employeeId)
        {
            /*GetEmployeeReview*/

            List<ParmStruct> parms = new List<ParmStruct>()
            {
                new ParmStruct("@EmployeeId", employeeId,SqlDbType.Int)
            };

            DataAccess db = new DataAccess();
            DataTable dt = db.Execute("GetEmployeeReview", CommandType.StoredProcedure, parms);

            List<Review> reviews = new List<Review>();
            foreach (DataRow row in dt.Rows)
            {
                Review review = new Review();

                review.ReviewId = (int)row["ReviewId"];
                review.EmployeeId = (int)row["EmployeeId"];
                review.SupervisorId = (int)row["SupervisorId"];
                review.Comment = row["Comment"].ToString();
                review.Date = (DateTime)row["Date"];

                if(row["Performance"].ToString() == "Exceeds Expectation")
                {
                    review.Performance = Performance.ExceedsExpetation;
                }
                else if(row["Performance"].ToString() == "Meets Expectation")
                {
                    review.Performance = Performance.MeetExpectation;
                }
                else
                {
                    review.Performance = Performance.BellowExpectation;
                }

                reviews.Add(review);
            }

            return reviews;
        }
    }


}
