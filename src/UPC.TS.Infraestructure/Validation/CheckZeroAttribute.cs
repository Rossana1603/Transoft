using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.TS.Infraestructure.Validation
{
    public class CheckZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //the error message
            string sErrorMessage = "Different from zero";
            //implement appropriate validation logic here

            if ((decimal)value < 0) { return new ValidationResult(sErrorMessage); }
            return ValidationResult.Success;
        }
    }
}
