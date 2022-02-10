using Amazonia.DAL.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Amazonia.eCommerceRazor.ViewComponents
{
    public class MoradaViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Morada morada)
        {
            return Task.FromResult<IViewComponentResult>(View("MoradaCard", morada));
        }
    }
}
