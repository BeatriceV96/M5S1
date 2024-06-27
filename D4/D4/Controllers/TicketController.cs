using Microsoft.AspNetCore.Mvc;
using D4.Models;


namespace CinemaTicketApp.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View(Cinema.Biglietti);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (Cinema.SaleCapienza[ticket.Sala] > Cinema.SaleBigliettiVenduti[ticket.Sala])
            {
                Cinema.AggiungiBiglietto(ticket);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Sala piena, impossibile aggiungere altri biglietti.");
                return View(ticket);
            }
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            var stats = new
            {
                Nord = new { Totale = Cinema.SaleBigliettiVenduti["SALA NORD"], Ridotti = Cinema.SaleBigliettiRidotti["SALA NORD"] },
                Est = new { Totale = Cinema.SaleBigliettiVenduti["SALA EST"], Ridotti = Cinema.SaleBigliettiRidotti["SALA EST"] },
                Sud = new { Totale = Cinema.SaleBigliettiVenduti["SALA SUD"], Ridotti = Cinema.SaleBigliettiRidotti["SALA SUD"] }
            };

            return Json(stats);
        }
    }
}