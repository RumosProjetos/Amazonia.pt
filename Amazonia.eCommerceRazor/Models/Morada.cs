using System.ComponentModel.DataAnnotations;

namespace Amazonia.DAL.Modelo
{
    public class Morada
    {
        public string Distrito { get; set; }

        [Display(Name = "Cidade ..." )]
        public string Localidade { get; set; }
    }
}
