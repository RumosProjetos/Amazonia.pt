using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public class Morada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Distrito { get; set; }

        [Display(Name = "Cidade ...")]
        public string Localidade { get; set; }


        //public Guid ClienteXMoradaId { get; set; }
        //public virtual ClienteXMorada Cliente { get; set; }
    }
}
