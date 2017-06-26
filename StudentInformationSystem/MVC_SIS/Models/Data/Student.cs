using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student : IValidatableObject
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("Please enter your first name",
                    new[] { "FirstName" }));
            }
            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Please enter your last name", new[] { "LastName" }));
            }
            if (GPA > decimal.Parse("4.0"))
            {
                errors.Add(new ValidationResult("Please enter a valid GPA", new[] { "GPA" }));
            }
            if (GPA < decimal.Parse("0.0"))
            {
                errors.Add(new ValidationResult("Please enter a valid GPA", new[] { "GPA" }));
            }
            return errors;
        }

    }

   
}