using Amazonia.eCommerceRazor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Amazonia.eCommerceRazor.Controllers
{
    public class MoradaController : Controller
    {

        private readonly ECommerceDbContext _context;

        public MoradaController(ECommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ListarMoradasToList()
        {
            var listagem = _context.Morada.ToList();
            return View(listagem);
        }


        public IActionResult ListarMoradas()
        {
            var listagem = _context.Morada;
            return View(listagem);
        }
    }
}
