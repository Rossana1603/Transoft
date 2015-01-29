using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UPC.TS.Web.Models
{
    public class GreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        public string DatePropertyName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            

            if (value == null)
                return ValidationResult.Success;

            var date = DateTime.Now;

            if (value is string)
            {
                date = DateTime.ParseExact(value.ToString(), "dd/MM/yyyy", null);
            }
            else
            {
                date = (DateTime)value;
            }

            if (GetValue<bool>(validationContext.ObjectInstance, DatePropertyName))
            {
                return new RequiredAttribute().IsValid(value) ?
                    ValidationResult.Success :
                    new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            DateTime dt = (DateTime)value;
            if (dt >= DateTime.UtcNow)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Make sure your date is >= than today");
        }

        private static T GetValue<T>(object objectInstance, string propertyName)
        {
            if (objectInstance == null) throw new ArgumentNullException("objectInstance");
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException("propertyName");

            var propertyInfo = objectInstance.GetType().GetProperty(propertyName);
            return (T)propertyInfo.GetValue(objectInstance);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {

            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());

            //This string identifies which Javascript function to be executed to validate this   
            rule.ValidationType = "greaterthan";
            rule.ValidationParameters.Add("otherfield", DatePropertyName);
            yield return rule;
        }

    }

    public class FutureDateAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value == null)// || (DateTime)value < DateTime.Now)
                return false;

            if (value is  string)
            {
                var date = DateTime.ParseExact(value.ToString(), "dd/MM/yyyy", null);
                if (date < DateTime.Now)
                    return false;
            }
            else
            {
                if ((DateTime)value < DateTime.Now)
                    return false;
            }


            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessage,
                ValidationType = "futuredate"
            };
        }
    }
}
