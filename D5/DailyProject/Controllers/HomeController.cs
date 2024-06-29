using Microsoft.AspNetCore.Mvc;
using DailyProject.Services.Interface;
using DailyProject.Classi;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DailyProject.Models;

namespace DailyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticoloService _articoloService;
        private readonly IWebHostEnvironment _env;

        public HomeController(IArticoloService articoloService, IWebHostEnvironment env)
        {
            _articoloService = articoloService;
            _env = env;
        }

        public IActionResult Index()
        {
            var articoli = _articoloService.GetArticoli();
            return View(articoli);
        }

        public IActionResult Dettagli(int id)
        {
            var articolo = _articoloService.GetArticoli().FirstOrDefault(a => a.Id == id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }

        public IActionResult CreaProdotto()
        {
            return View(new ArticoloViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreaProdotto(Articolo modello, IFormFile fileImmagineCopertina)
        {
            if (fileImmagineCopertina != null && fileImmagineCopertina.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileImmagineCopertina.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileImmagineCopertina.CopyToAsync(stream);
                }
                modello.ImmagineCopertina = "/images/" + fileImmagineCopertina.FileName;
            }
            else
            {
                modello.ImmagineCopertina = "/images/images.jpg";
            }

            _articoloService.AddArticolo(modello);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult ModificaProdotto(int id)
        {
            var articoloDaModificare = _articoloService.GetArticoli().FirstOrDefault(a => a.Id == id);

            if (articoloDaModificare == null)
            {
                return NotFound();
            }

            var modello = new ArticoloViewModel
            {
                Id = articoloDaModificare.Id,
                Nome = articoloDaModificare.Nome,
                Prezzo = articoloDaModificare.Prezzo,
                Descrizione = articoloDaModificare.Descrizione,
                Tipo = articoloDaModificare.Tipo.ToString()
            };

            return View(modello);
        }

        [HttpPost]
        public async Task<IActionResult> ModificaProdotto(int id, ArticoloViewModel modello)
        {
            if (!ModelState.IsValid)
            {
                return View(modello);
            }

            var articoloDaAggiornare = _articoloService.GetArticoli().FirstOrDefault(a => a.Id == id);
            if (articoloDaAggiornare == null)
            {
                return NotFound();
            }

            if (modello.ImmagineCopertina != null && modello.ImmagineCopertina.Length > 0)
            {
                var filePath = Path.Combine(_env.WebRootPath, "images", modello.ImmagineCopertina.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await modello.ImmagineCopertina.CopyToAsync(stream);
                }
                articoloDaAggiornare.ImmagineCopertina = "/images/" + modello.ImmagineCopertina.FileName;
            }

            articoloDaAggiornare.Nome = modello.Nome;
            articoloDaAggiornare.Descrizione = modello.Descrizione;
            articoloDaAggiornare.Prezzo = modello.Prezzo;
            if (Enum.TryParse<TipoArticolo>(modello.Tipo, out var tipoArticolo))
            {
                articoloDaAggiornare.Tipo = tipoArticolo;
            }

            _articoloService.UpdateArticolo(articoloDaAggiornare);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminaProdotto(int id)
        {
            var articoloDaEliminare = _articoloService.GetArticoli().FirstOrDefault(a => a.Id == id);
            if (articoloDaEliminare == null)
            {
                return NotFound();
            }

            _articoloService.DeleteArticolo(id);
            return RedirectToAction("Index");
        }
    }
}


