using Amazonia.DAL.Modelo;
using Amazonia.eCommerceRazor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerceRazor.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public ActionResult Index()
        {
            var listaFakeClientes = new List<Cliente> {
                new Cliente {Nome = "Joao", UserName = "joao@email.pt", Morada = new Morada{Distrito = "Setubal", Localidade = "Barreiro" }, ListaProdutosComprados = new List<Product>()},
                new Cliente {Nome = "Maria", UserName = "maria@email.pt", Morada = new Morada(), ListaProdutosComprados = new List<Product>()},
                new Cliente {
                    Nome = "Marta", UserName = "marta@email.pt",
                    Morada = new Morada{Distrito = "Setubal", Localidade = "Quinta do Conde" },
                    ListaProdutosComprados = new List<Product>
                    {
                        new Product {Name = "Televisão", Id = new Random().Next()},
                        new Product {Name = "Playstation", Id = new Random().Next()},
                        new Product {Name = "God of War", Id = new Random().Next()},
                    }
                },
            };

            return View(listaFakeClientes);
        }

        //https://localhost:44328/cliente2
        [Route("Cliente2")]
        public ActionResult IndexComViewComponent()
        {
            return View();
        }





        public ContentResult ObterFotografia()
        {
            return Content("https://localhost:44328/img/homem.jpg");
        }



        public IActionResult CriarNovoCliente()
        {
            var cliente = new Cliente();
            return View(cliente);
        }


        public IActionResult Detalhes(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View("CriarNovoCliente", cliente);
            }

            return View(cliente);
        }
    }
}
