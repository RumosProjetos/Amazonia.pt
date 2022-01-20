using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Amazonia.eCommerceRazor.Services.StringValidator
{
    public class AllLettersValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null)
                return false;

            var result = ((string)value).All(char.IsLetter);
            return result;
        }
    }
}
