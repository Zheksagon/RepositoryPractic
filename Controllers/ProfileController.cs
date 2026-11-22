using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadacha1zhd.DataBase;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DataBaseContext DBcontext;
        private readonly SignInManager<AuthenticationModel> DBsignInManager;

        public ProfileController(
            DataBaseContext context,
            SignInManager<AuthenticationModel> signInManager)
        {
            DBcontext = context;
            DBsignInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var currentUserName = User.Identity?.Name;
            if (string.IsNullOrEmpty(currentUserName))
            {
                return RedirectToAction("UserAuthorization", "Authentication");
            }

            var user = await DBcontext.Users
                .Include(user => user.Bookings)
                    .ThenInclude(booking => booking.Product)
                .FirstOrDefaultAsync(user => user.UserName == currentUserName);

            if (user == null)
            {
                return RedirectToAction("UserAuthorization", "Authentication");
            }

            return View("~/Views/WindowProfile/Profile.cshtml", user);
        }

        [HttpPost]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var booking = await DBcontext.Bookings.FirstOrDefaultAsync(booking => booking.Id == id);
            if (booking != null)
            {
                if (booking.Status == BookingStatus.Confirmed)
                {
                    booking.Status = BookingStatus.CancelledConfirmed;
                }
                else if (booking.Status == BookingStatus.Pending)
                {
                    booking.Status = BookingStatus.Cancelled;
                }

                await DBcontext.SaveChangesAsync();
            }

            return RedirectToAction("Profile");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await DBsignInManager.SignOutAsync();
            return RedirectToAction("UserAuthorization", "Authentication");
        }
    }
}
