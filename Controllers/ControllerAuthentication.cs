using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Authentication()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/UserRegistration/main.cshtml");
        }
        
    }
}