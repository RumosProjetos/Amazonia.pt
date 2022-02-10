using Amazonia.eCommerceRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amazonia.eCommerceRazor.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            var restaurant = new Restaurant() {
                Id = 1, 
                Name = "My Kitchen 1", 
                Address = "New Brunswick, 2657 Webster Street", 
                Speciality = "Hamburgers", 
                Open = true, 
                Review = 4,
            Password = "teste"};


            return View(restaurant);
        }
    }
}
