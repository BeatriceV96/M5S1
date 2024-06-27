using Microsoft.AspNetCore.Mvc;
using D4.Models;


namespace CinemaTicketApp.Controllers
{
    // Controller per gestire le operazioni sui biglietti
    public class TicketController : Controller
    {
        // Azione per visualizzare la lista dei biglietti venduti
        public IActionResult Index()
        {
            // Restituisce la vista con la lista dei biglietti venduti
            return View(Cinema.Biglietti);
        }

        // Azione per mostrare il form di creazione di un nuovo biglietto (metodo GET)
        [HttpGet]
        public IActionResult Create()
        {
            // Restituisce la vista del form di creazione
            return View();
        }

        // Azione per gestire l'invio del form di creazione di un nuovo biglietto (metodo POST)
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            // Controlla se la capienza della sala è sufficiente
            if (Cinema.SaleCapienza[ticket.Sala] > Cinema.SaleBigliettiVenduti[ticket.Sala])
            {
                // Aggiunge il biglietto alla lista dei biglietti venduti
                Cinema.AggiungiBiglietto(ticket);

                // Reindirizza all'azione Index per visualizzare la lista aggiornata dei biglietti
                return RedirectToAction("Index");
            }
            else
            {
                // Se la sala è piena, aggiunge un errore al ModelState e ritorna la vista del form con il modello
                ModelState.AddModelError("", "Sala piena, impossibile aggiungere altri biglietti.");
                return View(ticket);
            }
        }

        // Azione per ottenere le statistiche aggiornate dei biglietti venduti
        [HttpGet]
        public IActionResult GetStatistics()
        {
            // Crea un oggetto anonimo con le statistiche dei biglietti venduti e ridotti per ogni sala
            var stats = new
            {
                Nord = new { Totale = Cinema.SaleBigliettiVenduti["SALA NORD"], Ridotti = Cinema.SaleBigliettiRidotti["SALA NORD"] },
                Est = new { Totale = Cinema.SaleBigliettiVenduti["SALA EST"], Ridotti = Cinema.SaleBigliettiRidotti["SALA EST"] },
                Sud = new { Totale = Cinema.SaleBigliettiVenduti["SALA SUD"], Ridotti = Cinema.SaleBigliettiRidotti["SALA SUD"] }
            };

            // Restituisce le statistiche come JSON
            return Json(stats);
        }
    }
}