using Amazonia.DAL.Modelo;
using Amazonia.eCommerceRazor.Contants;
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
        public string Nome { get; set; }

        [Required]
        [MinLength(5), MaxLength(255)]
        [EmailAddress]
        [Display(Name = Language.Name)]
        public string UserName { get; set; }

        [Required]
        [MinLength(32), MaxLength(32)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MinLength(9), MaxLength(9)]        
        public string NumeroIdentificacaoFiscal { get; set; }

        [NotMapped]
        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        public Morada Morada { get; set; }


        public string UrlFotoCliente { get; set; }

        public List<Product> ListaProdutosComprados { get; set; }

    }
}
