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
        public async Task<IActionResult> ProductCatalog(string searchBar, int? categoryId)
        {
            ViewBag.Categories = await BDcontext.Categories.ToListAsync();
            ViewBag.SearchQuery = searchBar;
            ViewBag.SelectedCategoryId = categoryId;

            var query = BDcontext.Products.Include(product => product.Category).AsQueryable();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(product => product.CategoryId == categoryId.Value);
            }

            var products = await query.ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchBar))
            {
                string search = searchBar.Trim();
                products = products.Where(products => products.Title.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View("~/Views/WindowProductCatalog/catalog.cshtml", products);
        }

        [HttpGet]
        public async Task<IActionResult> ProductRent(int id)
        {
                var product = await BDcontext.Products
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(product => product.Id == id);

            return View("~/Views/RentWindow/rentwindow.cshtml", product);
        }

        [HttpPost]
        public async Task<IActionResult> BookingProduct(int productId, DateTime startRent, DateTime endRent)
        {
                var currentUserName = User.Identity?.Name;
                if (string.IsNullOrEmpty(currentUserName))
                {
                    return RedirectToAction("UserAuthorization", "Authentication");
                }

                var user = await BDcontext.Users.FirstOrDefaultAsync(user => user.UserName == currentUserName);
                var product = await BDcontext.Products.FirstOrDefaultAsync(product => product.Id == productId);

                if (user == null || product == null)
                {
                    return RedirectToAction("ProductCatalog");
                }

                int days = (endRent.Date - startRent.Date).Days;
                if (days < 1) 
                {
                    days = 1;
                }
                decimal totalPrice = (days * product.PricePerDay) + product.Deposit;

                var newBooking = new BookingModel
                {
                    ClientId = user.Id,
                    ProductId = product.Id,
                    StartRent = startRent,
                    EndRent = endRent,
                    TotalPrice = totalPrice,
                    Status = BookingStatus.Confirmed
                };

                BDcontext.Bookings.Add(newBooking);
                await BDcontext.SaveChangesAsync();

                return RedirectToAction("Profile", "Profile");
        }
    }
}