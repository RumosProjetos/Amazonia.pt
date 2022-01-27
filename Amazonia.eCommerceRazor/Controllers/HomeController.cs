using Amazonia.eCommerceRazor.Models;
using Amazonia.eCommerceRazor.Services.Logging;
using Amazonia.eCommerceRazor.Services.PDFGenerator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Amazonia.eCommerceRazor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHistorico historico;

        public HomeController(ILogger<HomeController> logger, IHistorico historico)
        {
            _logger = logger;
            this.historico = historico;
        }


        public IActionResult Index()
        {
            historico.Guardar("Index");
            ViewBag.Exemplo = new List<Person>();
            return View();
        }

        public IActionResult Privacy()
        {
            historico.Guardar("Privacy");
            return View();
        }

        public IActionResult AboutUs()
        {
            historico.Guardar("AboutUs");
            return View();
        }


        public IActionResult ListagemProdutos()
        {
            historico.Guardar("Listagem Produtos");
            var prod = new List<Product> { new Product { Id = 1, Name = "exemplo" } };
            return View(prod);
        }

        public ContentResult Message(IGerador gerador)
        {
            //IGerador gerador;
            //gerador.GerarPDF("c:\temp.pdf", new byte[] { });

            return Content("Exemplo");
        }


        public IActionResult Demonstracao()
        {
            ViewBag.PrecoDosProdutos = new Dictionary<string, double>();
            ViewBag.PrecoDosProdutos.Add("Arroz", 12.2d);
            ViewBag.PrecoDosProdutos.Add("Feijao", 5.2d);
            ViewBag.PrecoDosProdutos.Add("Milho", 3.2d);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
