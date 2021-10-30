namespace Amazonia.DAL.Entidades
{
    public abstract class Livro : Entidade
    {
        public decimal Preco { protected get;  set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public Idioma Idioma { get; set; }   //Portugues, Espanhol, Ingles, Frances

        public virtual decimal ObterPreco(){
            return Preco;
        }

      //Poderia ter feito assim, mas preferimos, usando a observacao do colega, modificar a acessibilidade da propriedade preco
        //public virtual void InformarPreco(decimal precoSemDesconto)
        //{
        //    Preco = precoSemDesconto;
        //}
    }
}

