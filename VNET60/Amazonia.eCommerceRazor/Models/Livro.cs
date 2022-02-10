using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public class Livro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Preco { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(255)]
        public string Autor { get; set; }


        [NotMapped]
        public virtual decimal ObterPreco => Preco;

        [NotMapped]
        public virtual string TipoPorEscrito => "Não Informado";


        public string UrlCapaDoLivro { get; set; }
    }
}

