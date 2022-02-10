using Amazonia.eCommerceRazor.Models;
using System.ComponentModel.DataAnnotations;

namespace Amazonia.eCommerceRazor.Services.IdadeValidator
{
    public class ClienteMaiorDeIdadeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cliente = (Cliente)validationContext.ObjectInstance;

            if (cliente.Idade < 18)
            {
                return new ValidationResult("Ops, cliente tem que ter mais do que 18 anos");
            }

            return ValidationResult.Success;
        }
    }
}
