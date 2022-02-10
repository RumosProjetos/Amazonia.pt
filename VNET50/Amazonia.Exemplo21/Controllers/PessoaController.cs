using Amazonia.Exemplo21.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amazonia.Exemplo21.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            var pessoa = new Pessoa();
            return View(pessoa);
        }


        [HttpPost]
        public IActionResult Index(Pessoa pessoa)
        {
            return View(pessoa);
        }

    }
}
