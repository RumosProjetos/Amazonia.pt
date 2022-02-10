using Amazonia.eCommerceRazor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazonia.eCommerceRazor.ViewComponents
{
    public class ClienteViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(List<Cliente> clientes)
        {
            return Task.FromResult<IViewComponentResult>(View("ClienteTable", clientes));
        }
    }
}
