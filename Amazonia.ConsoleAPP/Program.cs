using System;
using System.Configuration;
using Amazonia.DAL.Repositorios;
using Amazonia.DAL.Utils;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
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
