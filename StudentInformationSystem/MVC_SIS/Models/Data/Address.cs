using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Address : IValidatableObject
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Street1))
            {
                errors.Add(new ValidationResult("Please enter the street address",
                    new[] { "Street1" }));
            }
            if (string.IsNullOrEmpty(City))
            {
                errors.Add(new ValidationResult("Please enter the city",
                    new[] { "City" }));
            }
            if (string.IsNullOrEmpty(PostalCode))
            {
                errors.Add(new ValidationResult("Please enter the zip code",
                    new[] { "PostalCode" }));
            }
            return errors;
        }
    }
}