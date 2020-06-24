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
    public class ReviewService
    {
        ReviewRepository reviewRepository = new ReviewRepository();
        public bool CreateReview(Review review)
        {
            if (IsValid(review))
            {
                return reviewRepository.InsertReview(review);
            }
            return false;
        }

        public List<Review> GetReviews(int employeeId)
        {
            return reviewRepository.GetEmployeeReviews(employeeId);
        }

        private bool IsValid(Review review)
        {
            return IsValidEntity(review) && IsValidQuarter(review);
        }

   /*     public int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 1;
            else if (date.Month >= 7 && date.Month <= 9)
                return 2;
            else if (date.Month >= 10 && date.Month <= 12)
                return 3;
            else
                return 4;
        }*/
        public int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 2;
            else if (date.Month >= 7 && date.Month <= 9)
                return 3;
            else if (date.Month >= 10 && date.Month <= 12)
                return 4;
            else
                return 1;
        }

        private bool IsValidQuarter(Review review)
        {
            DateTime? lastReviewDate = reviewRepository.GetLastReviewDate(review.EmployeeId);
            if(review.Date > DateTime.Now)
            {
                review.AddError(new Error(review.Errors.Count() + 1, "An employee performance review cannot be added with a future date", "Business"));
            }
            if(review.Date < DateTime.Now && GetQuarter(review.Date) != GetQuarter(DateTime.Now))
            {
                review.AddError(new Error(review.Errors.Count() + 1, "You must select a date in the current quarter", "Business"));
                return false;
            }
            if (lastReviewDate.HasValue)
            {
                if(GetQuarter(review.Date) == GetQuarter(lastReviewDate.Value) && lastReviewDate.Value.Year == review.Date.Year)
                {
                    review.AddError(new Error(review.Errors.Count() + 1, "This employee already has a review for this quarter", "Business"));
                    return false;
                }
            }

            return true;
        }

        private bool IsValidEntity(Review review)
        {
            ValidationContext context = new ValidationContext(review);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(review, context, results, true);

            foreach (ValidationResult r in results)
            {
                review.AddError(new Error(review.Errors.Count + 1, r.ErrorMessage, "Model"));
            }

            return isValid;
        }
    }
}
