using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerceRazor.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Valor = 10;
            return View();
        }
    }
}
