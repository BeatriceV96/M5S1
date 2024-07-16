using DeliveryService.DataLayer.Services;
using DeliveryService.DataLayer.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ApplicationUser user)
        {
            try
            {
                var u = authenticationService.Login(user.UserName, user.Password);
            }
            catch (Exception ex)
            {
                // Gestire l'eccezione o registrare l'errore
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
