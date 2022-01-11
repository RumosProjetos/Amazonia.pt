using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.eCommerceRazor.Models
{
    public class Utilizador
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string PalavraPasse { get; set; }
    }
}
