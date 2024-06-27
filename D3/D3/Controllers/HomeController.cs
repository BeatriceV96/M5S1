using D3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic; // Aggiungi questo per utilizzare le liste

namespace D3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Definizione delle liste statiche
        public static List<Ospite> Ospiti = new List<Ospite>();
        public static List<Biglietto> Biglietti = new List<Biglietto>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(Biglietti);
        }

        // Altri metodi del controller...

        // Metodo per aggiungere un ospite e un biglietto (esempio)
        public void AggiungiOspiteEBiglietto(string nome, string cognome, string sala, TipoBiglietto tipo)
        {
            var ospite = new Ospite { Nome = nome, Cognome = cognome };
            var biglietto = new Biglietto { Ospite = ospite, Sala = sala, Tipo = tipo };

            Ospiti.Add(ospite);
            Biglietti.Add(biglietto);
        }
    }

    // Definizione della classe Ospite
    public class Ospite
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
    }

    // Definizione della classe Biglietto
    public class Biglietto
    {
        public Ospite Ospite { get; set; }
        public string Sala { get; set; }
        public TipoBiglietto Tipo { get; set; }
    }

    // Enumerazione per il tipo di biglietto
    public enum TipoBiglietto
    {
        Intero,
        Ridotto
    }
}
