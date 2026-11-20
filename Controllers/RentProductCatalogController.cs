using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.Controllers
{
    public class RentProductCatalogController : Controller
    {
        [HttpGet]
        public IActionResult ProductCatalog()
        {
            return View("~/Views/WindowProductCatalog/catalog.cshtml");
        }

        [HttpGet]
        public IActionResult ProductRent()
        {
            return View("~/Views/RentWindow/rentwindow.cshtml");
        }
    }
}