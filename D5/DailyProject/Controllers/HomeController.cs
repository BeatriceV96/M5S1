using Microsoft.AspNetCore.Mvc;
using DailyProject.Models;
using DailyProject.Services;
using DailyProject.Services.Interface;
using DailyProject.Classi;

namespace DailyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static IArticoloService _articoloService = new ArticoloService();
        private static IVenditeService _venditeService = new VenditeService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _articoloService = new ArticoloService();
        }

        public IActionResult Index()
        {
            return View(_articoloService.GetArticoli());
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreaProdotto(Articolo modello, IFormFile fileImmagineCopertina)
        {
            if (ModelState.IsValid)
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

            return View(modello);
        }

    }
}