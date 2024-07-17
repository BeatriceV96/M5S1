using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Contatti()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult InviaContatto(string nome, string email, string messaggio)
        {
            ViewBag.Message = "Messaggio inviato con successo!";
            return View("Contatti");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
