using Amazonia.eCommerceRazor.Services.NIFValidator;
using System.ComponentModel.DataAnnotations;

namespace Amazonia.eCommerceRazor.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Restaurante")]
        public string Name { get; set; }

        [Display(Name = "Endereço do Estabelecimento")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public bool Open { get; set; }
        public string Speciality { get; set; }
        public int Review { get; set; }
        public int MinhaPropriedade { get; set; }

        [DataType(DataType.CreditCard)]
        public string CartaoCredito { get; set; }

        [NifDataType("exemplo")]
        public string Contribuinte { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; internal set; }
    }
}