using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult UserRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/userreg.cshtml");
        }

        [HttpPost]
        public IActionResult UserRegistration(AuthenticationModel model, string passwordRepeat)
        {
            string MainWindowReg = "~/Views/WindowsAuthentication/WindowsRegistration/userreg.cshtml";

            model.Role = 0;

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"имя {model.FirstName}, фамилия {model.LastName}, отчество {model.Patronymic}, логин {model.Login}, почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}, роль: {model.Role}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            if (model.Password != passwordRepeat)
            {
                return View(MainWindowReg, model);
            }

            return Content
            (
                $"имя {model.FirstName}, фамилия {model.LastName}, отчество {model.Patronymic}, логин {model.Login}, почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}, роль: {model.Role}"
            );
        }

        [HttpGet]
        public IActionResult ManagerRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/managerreg.cshtml");
        }

        [HttpPost]
        public IActionResult ManagerRegistration(AuthenticationModel model, string passwordRepeat)
        {
            string ManagerReg = "~/Views/WindowsAuthentication/WindowsRegistration/managerreg.cshtml";

            model.Role = 1;

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"имя {model.FirstName}, фамилия {model.LastName}, отчество {model.Patronymic}, логин {model.Login}, почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}, роль: {model.Role}, пинкод {model.PINcode}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            if (model.Password != passwordRepeat)
            {
                return View(ManagerReg, model);
            }

            return Content
            (
                $"имя {model.FirstName}, фамилия {model.LastName}, отчество {model.Patronymic}, логин {model.Login}, почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}, роль: {model.Role}, пинкод {model.PINcode}"
            );
        }

        [HttpGet]
        public IActionResult AdministratorRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/adminreg.cshtml");
        }

                [HttpPost]
        public IActionResult AdministratorRegistration(AuthenticationModel model, string passwordRepeat)
        {
            string AdminReg = "~/Views/WindowsAuthentication/WindowsRegistration/adminreg.cshtml";

            model.Role = 2;

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"имя {model.FirstName}, фамилия {model.LastName}, отчество {model.Patronymic}, логин {model.Login}, почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}, роль: {model.Role}, пинкод {model.PINcode}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            if (model.Password != passwordRepeat)
            {
                return View(AdminReg, model);
            }

            return Content
            (
                $"имя {model.FirstName}, фамилия {model.LastName}, отчество {model.Patronymic}, логин {model.Login}, почта или телефон {model.PhoneNumberEmail}, пароль {model.Password}, повтор пароля {passwordRepeat}, роль: {model.Role}, пинкод {model.PINcode}"
            );
        }

        [HttpGet]
        public IActionResult UserAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/userauth.cshtml");
        }

        [HttpPost]
        public IActionResult UserAuthorization(AuthenticationModel model)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"логин или почта или телефон {model.LoginEmailPhoneNumber}, пароль {model.Password}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            return Content
            (
                $"логин или почта или телефон {model.LoginEmailPhoneNumber}, пароль {model.Password}"
            );
        }

        [HttpGet]
        public IActionResult ManagerAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/managerauth.cshtml");
        }

        [HttpPost]
        public IActionResult ManagerAuthorization(AuthenticationModel model)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"логин или почта или телефон {model.LoginEmailPhoneNumber}, пароль {model.Password}, пинкод: {model.PINcode}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            return Content
            (
                $"логин или почта или телефон {model.LoginEmailPhoneNumber}, пароль {model.Password}, пинкод: {model.PINcode}"
            );
        }

        [HttpGet]
        public IActionResult AdministratorAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/adminauth.cshtml");
        }

        [HttpPost]
        public IActionResult AdministratorAuthorization(AuthenticationModel model)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"логин или почта или телефон {model.LoginEmailPhoneNumber}, пароль {model.Password}, пинкод: {model.PINcode}");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            return Content
            (
                $"логин или почта или телефон {model.LoginEmailPhoneNumber}, пароль {model.Password}, пинкод: {model.PINcode}"
            );
        }
    }
}