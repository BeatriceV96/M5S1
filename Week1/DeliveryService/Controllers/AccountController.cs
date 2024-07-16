using DeliveryService.DataLayer.Services;
using DeliveryService.DataLayer.Services.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

                //creiamo le claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, u.UserName), //claim per il nome
                    new Claim(ClaimTypes.Role, "Cliente"), //claim per il ruolo
                    new Claim(ClaimTypes.Role, "Azienda"),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                // Gestire l'eccezione o registrare l'errore
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
