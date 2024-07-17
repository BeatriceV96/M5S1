using DeliveryService.DataLayer.Interfaces;
using DeliveryService.DataLayer.Services;
using DeliveryService.DataLayer.Services.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeliveryService.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authenticationService;
        private readonly IClienteDao _clienteDao;

        public AccountController(IAuthService authenticationService, IClienteDao clienteDao)
        {
            _authenticationService = authenticationService;
            _clienteDao = clienteDao;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser user)
        {
            try
            {
                var u = _authenticationService.Login(user.UserName, user.Password);

                // Creiamo le claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"Utente di nome {u.UserName}"), // claim per il nome
                    new Claim(ClaimTypes.Role, "Amministratore") // claim per il ruolo
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity)); // SignInAsync gestisce l'operazione in un thread separato

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Gestire l'eccezione o registrare l'errore
                ViewBag.LoginError = "Nome utente o password non validi.";
                return View();
            }
        }

        [Authorize(Roles = "Amministratore")]
        public IActionResult ListaClienti()
        {
            var clienti = _clienteDao.ReadAll();
            return View(clienti); // Passa la lista dei clienti alla vista
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
