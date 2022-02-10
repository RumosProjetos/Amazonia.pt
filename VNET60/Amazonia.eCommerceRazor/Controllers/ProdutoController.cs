using Microsoft.AspNetCore.Mvc;

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
