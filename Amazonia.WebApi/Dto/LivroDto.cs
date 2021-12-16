namespace Amazonia.WebApi.Dto
{
    public class LivroDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public EnumTipoLivro TipoLivro { get; set; } //TODO: Resolver depois
    }
}
