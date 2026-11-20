using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Profile()
        {
            return View("~/Views/WindowProfile/profile.cshtml");
        }
    }
}