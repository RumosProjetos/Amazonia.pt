using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
