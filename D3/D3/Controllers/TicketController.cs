using D3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace D3.Controllers
{
    public class TicketController : Controller
    {
        private static List<Ticket> tickets = new List<Ticket>
        {
            // Esempio di biglietti pre-esistenti
            new Ticket { Sala = "SALA NORD", Tipo = Models.TipoBiglietto.Intero, Nome = "Mario", Cognome = "Rossi" },
            // Aggiungi altri biglietti di esempio se necessario
        };

        private static int maxCapacity = 120;

        public IActionResult Index()
        {
            return View(tickets);
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (tickets.Count(t => t.Sala == ticket.Sala) < maxCapacity)
            {
                tickets.Add(ticket);
                return RedirectToAction("Index");
            }
            else
            {
                return Content("I biglietti sono esauriti!");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Ticket()); // Passa un'istanza vuota del modello Ticket alla vista
        }

        public IActionResult Statistics()
        {
            var stats = tickets.GroupBy(t => t.Sala)
                               .Select(group => new
                               {
                                   Sala = group.Key,
                                   Totale = group.Count(),
                                   Ridotti = group.Count(t => t.Tipo == Models.TipoBiglietto.Ridotto)
                               }).ToList();

            return View(stats);
        }
    }
}
