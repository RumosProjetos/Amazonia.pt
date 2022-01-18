using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerceRazor.Controllers
{
    public class MoradaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
