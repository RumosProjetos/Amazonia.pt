using Amazonia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Repositorios
{
    public class CarrinhoCompras : ICarrinhoCompras
    {
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }

        public decimal AplicarDesconto(decimal valorDesconto)
        {
            var fatorDesconto = (100 - valorDesconto)/100;  

            var valorCalculado = Livros.Sum(x => x.ObterPreco());
            var valorComDesconto =  valorCalculado * fatorDesconto;

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
