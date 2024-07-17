using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers
{
    [Authorize]
    public class ContattiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InviaContatto(string nome, string email, string messaggio)
        {
            // Logica per inviare il messaggio di contatto (da implementare)
            ViewBag.Message = "Messaggio inviato con successo!";
            return View("Index");
        }
    }
}