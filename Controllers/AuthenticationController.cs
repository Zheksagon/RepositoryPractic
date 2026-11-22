using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadacha1zhd.DataBase;
using Zadacha1zhd.Models;


namespace Zadacha1zhd.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AuthenticationModel> BDuserManager;
        private readonly SignInManager<AuthenticationModel> BDsignInManager;
        private readonly DataBaseContext BDcontext;

        public AuthenticationController(
            UserManager<AuthenticationModel> userManager,
            SignInManager<AuthenticationModel> signInManager,
            DataBaseContext context)
        {
            BDuserManager = userManager;
            BDsignInManager = signInManager;
            BDcontext = context;
        }

        [HttpGet]
        public IActionResult UserRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/userreg.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(AuthenticationModel model, string passwordRepeat)
        {
            string MainWindowReg = "~/Views/WindowsAuthentication/WindowsRegistration/userreg.cshtml";

            model.Role = 0;
            model.UserName = model.Login;
            placeEmailOrPhone(model);

            if (model.Password != passwordRepeat)
            {
                return View(MainWindowReg, model);
            }

            var result = await BDuserManager.CreateAsync(model, model.Password);

            if (result.Succeeded)
            {
                await BDsignInManager.SignInAsync(model, isPersistent: false);
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            return View(MainWindowReg, model);
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

            return RedirectToAction("ProductCatalog", "RentProductCatalog");
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

            return RedirectToAction("ProductCatalog", "RentProductCatalog");
        }

        [HttpGet]
        public IActionResult UserAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/userauth.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> UserAuthorization(AuthenticationModel model)
        {
            string MainUserAuth = "~/Views/WindowsAuthentication/WindowsAuthorization/userauth.cshtml";

            var user = await findUserLoginOrPhoneNumberOrEmail(model.LoginEmailPhoneNumber);

            if (user == null || user.Role != 0)
            {
                return View(MainUserAuth, model);
            }

            var result = await BDsignInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            return View(MainUserAuth, model);
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

            return RedirectToAction("ProductCatalog", "RentProductCatalog");
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

            return RedirectToAction("ProductCatalog", "RentProductCatalog");
        }

        private void placeEmailOrPhone(AuthenticationModel model)
        {
            if (model.PhoneNumberEmail != null)
            {
                if (model.PhoneNumberEmail.Contains("@"))
                {
                    model.Email = model.PhoneNumberEmail;
                }
                else
                {
                    model.PhoneNumber = model.PhoneNumberEmail;
                }
            }
        }

        private async Task<AuthenticationModel?> findUserLoginOrPhoneNumberOrEmail(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            return await BDcontext.Users.FirstOrDefaultAsync(user => 
            user.Login == input ||
            user.Email == input ||
            user.PhoneNumber == input);
        }
    }
}