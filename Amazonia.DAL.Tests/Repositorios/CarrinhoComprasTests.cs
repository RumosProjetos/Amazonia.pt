using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios.Tests
{
    [TestClass()]
    public class CarrinhoComprasTests
    {
        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosImpressosTest()
        {
            //arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso 02" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 60M;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert            
            Assert.AreEqual(valorEsperado, valorObtido);
        }


        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisTest()
        {
            //arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital 01" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital 02" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 54M;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert            
            Assert.AreEqual(valorEsperado, valorObtido);
        }


        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressosTest()
        {
            //arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital 01" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital 02" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital 03" });
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso 02" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 114M; //54 + 60 = 114

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert            
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void AplicarDescontoTest()
        {
            //arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 60, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso 02" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 80M;
            var valorDesconto = 20;
            carrinho.Livros = livrosFake;

            //act
            var valorObtidoDesconto = carrinho.AplicarDesconto(valorDesconto);

            //assert
            Assert.AreEqual(valorEsperado, valorObtidoDesconto);
        }
    }
}