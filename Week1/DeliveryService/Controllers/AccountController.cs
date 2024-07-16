using DeliveryService.DataLayer.Services;
using DeliveryService.DataLayer.Services.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeliveryService.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService authenticationService;

        public AccountController(IAuthService authenticationService)
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
                    new Claim(ClaimTypes.Role, "Amministratore") //claim per il ruolo
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, //qui dico al server di autenticare l'utente specificato dall'oggetto di tipo ClaimsPrincipal come utente correttamente collegato all'applicazione
                    new ClaimsPrincipal(identity) //SingnInAsync che l'óperazione viene gestita in un tread a se stante
                    );
            }
            catch (Exception ex)
            {
                // Gestire l'eccezione o registrare l'errore
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
