using D3.Models; // Importa il namespace del modello
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace D3.Controllers
{
    public class TicketController : Controller
    {
        private static List<Ticket> tickets = new List<Ticket>
        {
            new Ticket { Sala = "SALA NORD", Tipo = TipoBiglietto.Intero },
            new Ticket { Sala = "SALA NORD", Tipo = TipoBiglietto.Ridotto },
            new Ticket { Sala = "SALA EST", Tipo = TipoBiglietto.Intero },
            new Ticket { Sala = "SALA SUD", Tipo = TipoBiglietto.Ridotto },
            new Ticket { Sala = "SALA SUD", Tipo = TipoBiglietto.Ridotto }
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

        public IActionResult Statistics()
        {
            var stats = tickets.GroupBy(t => t.Sala)
                               .Select(group => new
                               {
                                   Sala = group.Key,
                                   Totale = group.Count(),
                                   Ridotti = group.Count(t => t.Tipo == TipoBiglietto.Ridotto)
                               }).ToList();

            return View(stats);
        }
    }
}
