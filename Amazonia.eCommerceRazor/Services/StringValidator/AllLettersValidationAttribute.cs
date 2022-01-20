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


            return ((string)value).All(char.IsLetter);
        }
    }
}
