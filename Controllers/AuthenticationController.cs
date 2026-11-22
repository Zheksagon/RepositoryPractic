using System.Linq;
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
                ViewBag.ErrorMessage = "Пароли не совпадают";
                return View(MainWindowReg, model);
            }

            var result = await BDuserManager.CreateAsync(model, model.Password);

            if (result.Succeeded)
            {
                await BDsignInManager.SignInAsync(model, isPersistent: false);
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            ViewBag.ErrorMessage = string.Join(" ", result.Errors.Select(e => e.Description));
            return View(MainWindowReg, model);
        }

        [HttpGet]
        public IActionResult ManagerRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/managerreg.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ManagerRegistration(AuthenticationModel model, string passwordRepeat)
        {
            string ManagerReg = "~/Views/WindowsAuthentication/WindowsRegistration/managerreg.cshtml";

            model.Role = 1;
            model.UserName = model.Login;
            placeEmailOrPhone(model);

            if (model.Password != passwordRepeat)
            {
                ViewBag.ErrorMessage = "Пароли не совпадают";
                return View(ManagerReg, model);
            }

            if (model.PINcode <= 0)
            {
                ViewBag.ErrorMessage = "Введите ПИН-код";
                return View(ManagerReg, model);
            }

            var result = await BDuserManager.CreateAsync(model, model.Password);

            if (result.Succeeded)
            {
                BDcontext.PinCodes.Add(new PinCodeModel
                {
                    PinCode = model.PINcode.ToString(),
                    UserId = model.Id
                });
                await BDcontext.SaveChangesAsync();

                await BDsignInManager.SignInAsync(model, isPersistent: false);
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            ViewBag.ErrorMessage = string.Join(" ", result.Errors.Select(e => e.Description));
            return View(ManagerReg, model);
        }

        [HttpGet]
        public IActionResult AdministratorRegistration()
        {
            return View("~/Views/WindowsAuthentication/WindowsRegistration/adminreg.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AdministratorRegistration(AuthenticationModel model, string passwordRepeat)
        {
            string AdminReg = "~/Views/WindowsAuthentication/WindowsRegistration/adminreg.cshtml";

            model.Role = 2;
            model.UserName = model.Login;
            placeEmailOrPhone(model);

            if (model.Password != passwordRepeat)
            {
                ViewBag.ErrorMessage = "Пароли не совпадают";
                return View(AdminReg, model);
            }

            if (model.PINcode <= 0)
            {
                ViewBag.ErrorMessage = "Введите ПИН-код";
                return View(AdminReg, model);
            }

            var result = await BDuserManager.CreateAsync(model, model.Password);

            if (result.Succeeded)
            {
                BDcontext.PinCodes.Add(new PinCodeModel
                {
                    PinCode = model.PINcode.ToString(),
                    UserId = model.Id
                });
                await BDcontext.SaveChangesAsync();

                await BDsignInManager.SignInAsync(model, isPersistent: false);
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            ViewBag.ErrorMessage = string.Join(" ", result.Errors.Select(e => e.Description));
            return View(AdminReg, model);
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
                ViewBag.ErrorMessage = "Пользователь не найден";
                return View(MainUserAuth, model);
            }

            var result = await BDsignInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            ViewBag.ErrorMessage = "Неверный пароль";
            return View(MainUserAuth, model);
        }

        [HttpGet]
        public IActionResult ManagerAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/managerauth.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ManagerAuthorization(AuthenticationModel model)
        {
            string MainManagerAuth = "~/Views/WindowsAuthentication/WindowsAuthorization/managerauth.cshtml";

            var user = await findUserLoginOrPhoneNumberOrEmail(model.LoginEmailPhoneNumber);

            if (user == null || user.Role != 1)
            {
                ViewBag.ErrorMessage = "Менеджер не найден";
                return View(MainManagerAuth, model);
            }

            var pin = await BDcontext.PinCodes.FirstOrDefaultAsync(p => p.UserId == user.Id && p.PinCode == model.PINcode.ToString());
            if (pin == null)
            {
                ViewBag.ErrorMessage = "Неверный ПИН-код";
                return View(MainManagerAuth, model);
            }

            var result = await BDsignInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            ViewBag.ErrorMessage = "Неверный пароль";
            return View(MainManagerAuth, model);
        }

        [HttpGet]
        public IActionResult AdministratorAuthorization()
        {
            return View("~/Views/WindowsAuthentication/WindowsAuthorization/adminauth.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> AdministratorAuthorization(AuthenticationModel model)
        {
            string MainAdminAuth = "~/Views/WindowsAuthentication/WindowsAuthorization/adminauth.cshtml";

            var user = await findUserLoginOrPhoneNumberOrEmail(model.LoginEmailPhoneNumber);

            if (user == null || user.Role != 2)
            {
                ViewBag.ErrorMessage = "Администратор не найден";
                return View(MainAdminAuth, model);
            }

            var pin = await BDcontext.PinCodes.FirstOrDefaultAsync(p => p.UserId == user.Id && p.PinCode == model.PINcode.ToString());
            if (pin == null)
            {
                ViewBag.ErrorMessage = "Неверный ПИН-код";
                return View(MainAdminAuth, model);
            }

            var result = await BDsignInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("ProductCatalog", "RentProductCatalog");
            }

            ViewBag.ErrorMessage = "Неверный пароль";
            return View(MainAdminAuth, model);
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