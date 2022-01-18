using Amazonia.Exemplo21.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
