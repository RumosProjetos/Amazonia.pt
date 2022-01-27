using System.ComponentModel.DataAnnotations;

namespace Amazonia.eCommerceRazor.Services.NIFValidator
{
    public class NifDataTypeAttribute : DataTypeAttribute
    {

        public NifDataTypeAttribute(string customDataType) : base(customDataType)
        {

        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Length == 9)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Nif com valor invalido");
        }

    }
}
