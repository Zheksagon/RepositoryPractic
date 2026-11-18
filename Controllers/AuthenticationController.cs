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
            return View("~/Views/WindowsAuthentication/WindowsRegistration/UserRegistration(Main)/main.cshtml");
        }

        [HttpPost]
        public IActionResult MainAuthentication(AuthenticationModel model, string passwordRepeat)
        {
            string MainWindow = "~/Views/WindowsAuthentication/WindowsRegistration/UserRegistration(Main)/main.cshtml";

            model.Role = 0;

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"логин {model.Login},почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}");
            Console.WriteLine($"роль: {model.Role}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            if (model.Password != passwordRepeat)
            {
                return View(MainWindow, model);
            }

            return Content
            (
                $"логин {model.Login},почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}, роль: {model.Role}"
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