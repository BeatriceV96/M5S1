using DeliveryService.DataLayer.Entities;
using DeliveryService.DataLayer.Services;
using DeliveryService.DataLayer.Services.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeliveryService.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService authenticationService;
 

        public AccountController(IAuthService authenticationService, SpedizioneService spedizioneService)
        {
            this.authenticationService = authenticationService;

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
                var u = authenticationService.Login(user.UserName, user.Password);

                //creiamo le claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"Utente di nome {u.UserName}"), //claim per il nome e prendo il nome dinamicamente dell'utente
                    new Claim(ClaimTypes.Role, "Amministratore") //claim per il ruolo
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

               await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, //qui dico al server di autenticare l'utente specificato dall'oggetto di tipo ClaimsPrincipal come utente correttamente collegato all'applicazione
                    new ClaimsPrincipal(identity) //SingnInAsync che l'óperazione viene gestita in un tread a se stante
                    );
            }
            catch (Exception ex)
            {
                // Gestire l'eccezione o registrare l'errore
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Amministratore")]
        public IActionResult RegistraClienteESpedizione(ClienteSpedizioneModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Logica per salvare il cliente e la spedizione nel database
                    //  gestire sia clienti privati che aziende
                    // e di registrare tutti i dettagli della spedizione forniti nel modello

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    // Gestire l'eccezione o registrare l'errore
                }
            }

            // Se siamo arrivati qui, qualcosa è andato storto, ri-mostra il form
            return View(model);
        }

        /*public IActionResult VerificaStatoSpedizione(string codiceIdentificativo, string numeroSpedizione)
        {
            try
            {
                var aggiornamentiSpedizione = spedizioneService.GetAggiornamentiSpedizione(codiceIdentificativo, numeroSpedizione);

                // Ordina gli aggiornamenti in ordine cronologico inverso prima di passarli alla vista
                aggiornamentiSpedizione = aggiornamentiSpedizione.OrderByDescending(a => a.DataOraAggiornamento).ToList();

                return View(aggiornamentiSpedizione); // Passa la lista alla vista
            }
            catch (Exception)
            {
                // Gestire l'eccezione o registrare l'errore
                //  voler reindirizzare a una pagina di errore o visualizzare un messaggio di errore
            }

            return View(new List<AggiornamentoSpedizione>()); // Passa una lista vuota se si verifica un errore
        }*/

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
