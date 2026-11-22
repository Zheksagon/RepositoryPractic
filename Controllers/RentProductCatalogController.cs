using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadacha1zhd.DataBase;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.Controllers
{
    public class RentProductCatalogController : Controller
    {
        private readonly DataBaseContext BDcontext;

        public RentProductCatalogController(
            DataBaseContext context)
        {
            BDcontext = context;
        }
        [HttpGet]
        public async Task<IActionResult> ProductCatalog()
        {
            var query = BDcontext.Products.AsQueryable();

            var products = await query.ToListAsync();
            return View("~/Views/WindowProductCatalog/catalog.cshtml", products);
        }

        [HttpGet]
        public IActionResult ProductRent()
        {
            return View("~/Views/RentWindow/rentwindow.cshtml");
        }
    }
}