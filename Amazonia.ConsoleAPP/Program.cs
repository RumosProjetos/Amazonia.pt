using System;
using System.Configuration;
using System.Linq;
using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorios;
using Amazonia.DAL.Utils;
using Microsoft.EntityFrameworkCore;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AmazoniaContexto();

            //CREATE
            AdicionarClienteExemplo(ctx);
            AdicionarLivrosExemplo(ctx);
            //ImprimirValorBaseadoEmConfiguracao();

            //READ
            var livroEscolhido = ctx.Livros.FirstOrDefault(x => x.Nome.StartsWith("Harry"));
            Console.WriteLine(livroEscolhido);


            var primeiroAudioLivroEncontrato = ctx.AudioLivros.FirstOrDefault(x => x.DuracaoLivroEmMinutos >= 10);
            Console.WriteLine(primeiroAudioLivroEncontrato);


            //UPDATE
            primeiroAudioLivroEncontrato.DuracaoLivroEmMinutos = 90;
            ctx.SaveChanges();



            //Delete
            //var primeiroLivroImpressto = ctx.LivroImpressos.FirstOrDefault();
            //Console.WriteLine(primeiroLivroImpressto);
            //ctx.LivroImpressos.Remove(primeiroLivroImpressto);
            //ctx.SaveChanges();


            var exemploLeituraComSql = ctx.Livros.FromSqlRaw("SELECT TOP 10 * FROM LIVROS");

            foreach (var item in exemploLeituraComSql)
            {
                Console.WriteLine(item);
            }

        }

        private static void ImprimirValorBaseadoEmConfiguracao()
        {
            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");


            var chaveExemplo = ConfigurationManager.AppSettings["chaveExemplo"];

            var usarRegranovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegranova = Convert.ToBoolean(usarRegranovaStr);

            if (usarRegranova)
            {
                ListarClientes();
            }
            else
            {
                ListarLivros();
            }
        }

        private static void AdicionarLivrosExemplo(AmazoniaContexto ctx)
        {
            var livroDigigal = new LivroDigital
            {
                Nome = "Harry Potter Digital",
                Autor = "JK",
                Descricao = "Livro harry potter",
                FormatoFicheiro = "PDF",
                Idioma = DAL.Idioma.Portugues,
                InformacoesLicenca = "",
                Preco = 100,
                TamanhoEmMB = 10
            };

            var audioLivro = new AudioLivro
            {
                Nome = "Harry Potter Audio Livro",
                Autor = "JK",
                Descricao = "Livro harry potter",
                FormatoFicheiro = "MP3",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100,
                DuracaoLivroEmMinutos = 60
            };


            var livroImpresso = new LivroImpresso
            {
                Nome = "Harry Potter Impresso",
                Autor = "JK",
                Descricao = "Livro harry potter",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100,
                Altura = 10,
                Largura = 10,
                Profundidade = 10
            };

            ctx.Livros.Add(livroImpresso);
            ctx.Livros.Add(audioLivro);
            ctx.Livros.Add(livroDigigal);
            ctx.SaveChanges();
        }

        private static void AdicionarClienteExemplo(AmazoniaContexto ctx)
        {
            ctx.Clientes.Add(new Cliente
            {
                UserName = "joao.silva",
                DataNascimento = new DateTime(1984, 05, 29),
                Nome = "João da Silva",
                NumeroIdentificacaoFiscal = "123456789",
                Password = "senha"
            });
            ctx.SaveChanges();
        }

        public static void ListarLivros(){
            
            var repo = new RepositorioLivro();
            var listaLivros = repo.ObterTodos();

            foreach (var item in listaLivros)
            {
                System.Console.WriteLine(item);
            }
        }



        public static void ListarClientes(){
             Console.WriteLine("Consulta do Database");

            var repo = new RepositorioCliente();
            // var listaClientes = repo.ObterTodos()

            var listaClientes = repo.ObterTodosQueComecemPor("J");


            foreach (var item in listaClientes)
            {
               Console.WriteLine(item);
            }



            var listaClientesAdultos = repo.ObterTodosQueTenhamPeloMenos18Anos();
            foreach (var item in listaClientesAdultos)
            {
               Console.WriteLine(item);
            }


            var listaClientesAdultosComecandoComJ = repo.ObterTodosQueTenhamPeloMenos18AnosENomeComecePor("J");
            foreach (var item in listaClientesAdultosComecandoComJ)
            {
               Console.WriteLine(item);
            }



            var listagemTotal = repo.ObterTodos();
            var joao = repo.ObterPorNome("Joao");
            System.Console.WriteLine(joao);
            System.Console.WriteLine($"Database contem: {listagemTotal.Count} clientes");
            repo.Apagar(joao);
            

            var listagemAposApagar = repo.ObterTodos();
              System.Console.WriteLine($"Database contem: {listagemAposApagar.Count} clientes");


            var maria = repo.ObterPorNome("Maria");
            var clienteNovo = repo.Atualizar(maria.Nome, "Maria Joao da Silva");
            System.Console.WriteLine(clienteNovo);


            // Console.WriteLine("Criacao de Novos Clientes no Database");
            // do{
            //     var novoCliente = new Cliente();
            //     Console.WriteLine("Informe o nome");
            //     novoCliente.Nome = Console.ReadLine();
            //     repo.Criar(novoCliente);
            //     Console.WriteLine($"{novoCliente.Nome} Criado");
            // }while(Console.ReadKey().Key != ConsoleKey.Tab);

            // var listaClientesNovosEAntigos = repo.ObterTodos();
            // foreach (var item in listaClientesNovosEAntigos)
            // {
            //    Console.WriteLine(item);
            // }
        }
    }
}
