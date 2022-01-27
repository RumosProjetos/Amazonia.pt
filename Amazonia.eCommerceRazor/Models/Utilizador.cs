using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.eCommerceRazor.Models
{
    public class Utilizador
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Ops, campo obrigatório")]
        [MinLength(5, ErrorMessage = "Ops, muito pequeno")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string PalavraPasse { get; set; }


        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("PalavraPasse", ErrorMessage = "Password nao bate")]        
        public string PalavraPasseConfirmacao { get; set; }




        [DataType(DataType.Upload)]
        public byte[] Avatar { get; set; }
        public bool Ativo { get; set; }

        [HiddenInput(DisplayValue = false)]        
        public SexoEnum Sexo { get; set; }
        //public List<string> SexosPossiveis { get; set; }
        public int ContagemDeLoginNoUltimoAno { get; set; }
    }
}
