using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Validation
{
    public class ValidationAttributeModels : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            return char.IsUpper(value.ToString()[0]);
        }
    }
}