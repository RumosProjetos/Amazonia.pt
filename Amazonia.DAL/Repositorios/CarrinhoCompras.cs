using Amazonia.DAL.Desconto;
using Amazonia.DAL.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Repositorios
{
    public class CarrinhoCompras : ICarrinhoCompras
    {
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }

        //Comentado apenas para guardar o exemplo
        //public decimal AplicarDesconto(decimal valorDesconto)
        //{
        //    var fatorDesconto = (100 - valorDesconto)/100;  

        //    var valorCalculado = Livros.Sum(x => x.ObterPreco());
        //    var valorComDesconto =  valorCalculado * fatorDesconto;

        //    return valorComDesconto;
        //}

        public decimal AplicarDesconto(IDesconto tipoDeDesconto)
        {
            var valorCalculado = Livros.Sum(x => x.ObterPreco()); //Trago o somatório de todos os livros (que tenham ou não descontos particulares)
            var valorComDesconto = tipoDeDesconto.Aplicar(valorCalculado); //Cálculo com base na regra
            return valorComDesconto;
        }

        public decimal CalcularPreco()
        {
            #region Explicacao de Como chegamos ao Linq.Sum
            ////Opcao1
            //foreach (var item in livros)
            //{
            //    valorCalculado = valorCalculado + item.ObterPreco();
            //}

            ////Opcao2
            //foreach (var item in livros)
            //{
            //    valorCalculado += item.ObterPreco();
            //} 
            #endregion


            //Opcao3
            var valorCalculado = Livros.Sum(x => x.ObterPreco());
            return valorCalculado;
        }
    }
}
