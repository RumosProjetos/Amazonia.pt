using Amazonia.eCommerceRazor.Contants;
using Amazonia.eCommerceRazor.Services.IdadeValidator;
using Amazonia.eCommerceRazor.Services.StringValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.eCommerceRazor.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Nome do Cliente")]
        [AllLettersValidation(ErrorMessage = "Só aceita letras")]
        public string Nome { get; set; }

        [Required]
        [MinLength(5), MaxLength(255)]
        [EmailAddress]
        [Display(Name = Language.Name)]
        public string UserName { get; set; }

        [Required]
        [MinLength(3), MaxLength(32)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [ClienteMaiorDeIdade]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MinLength(9), MaxLength(9)]
        public string NumeroIdentificacaoFiscal { get; set; }

        [NotMapped]
        public int Idade => DateTime.Now.Year - DataNascimento.Year;


        public string UrlFotoCliente { get; set; }

        public virtual List<Product> ListaProdutosComprados { get; set; }



        //public Guid ClienteXMoradaId { get; set; }
        //public virtual ClienteXMorada Morada { get; set; }



    }
}
