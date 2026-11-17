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

        [HttpPost]
        public IActionResult MainAuthentication(AuthenticationModel model, string passwordRepeat)
        {
            string MainWindow = "~/Views/WindowsAuthentication/WindowsRegistration/UserRegistration/main.cshtml";

            if (model.Password != passwordRepeat) 
            {
                
                return View(MainWindow, model);
            }

            return Content 
            (
                $"логин {model.Login},почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}"
            );
        }

        [HttpGet]
        public IActionResult ManagerRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/ManagerRegistration/main.cshtml");
        }

        [HttpGet]
        public IActionResult AdministratorRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/AdministratorRegistration/main.cshtml");
        }

        [HttpGet]
        public IActionResult UserAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/UserAuthorization/main.cshtml");
        }

        [HttpGet]
        public IActionResult ManagerAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/ManagerAuthorization/main.cshtml");
        }

        [HttpGet]
        public IActionResult AdministratorAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/AdministratorAuthorization/main.cshtml");
        }
    }
}