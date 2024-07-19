using Microsoft.AspNetCore.Mvc;
using EsercitazioneSettimanale1.Services;
using EsercitazioneSettimanale1.Models;

namespace EsercitazioneSettimanale1.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService verbaleService;
        private readonly TrasgressoreService trasgressoreService;
        private readonly ViolazioneService violazioneService;

        public VerbaleController(VerbaleService verbaleService, TrasgressoreService trasgressoreService, ViolazioneService violazioneService)
        {
            this.verbaleService = verbaleService;
            this.trasgressoreService = trasgressoreService;
            this.violazioneService = violazioneService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Trasgressori = trasgressoreService.GetAll();
            ViewBag.Violazioni = violazioneService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VerbaleEntity verbale)
        {
            if (ModelState.IsValid)
            {
                verbaleService.Save(verbale);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Trasgressori = trasgressoreService.GetAll();
            ViewBag.Violazioni = violazioneService.GetAll();
            return View(verbale);
        }

        public IActionResult VerbaliPerTrasgressore()
        {
            var verbali = verbaleService.GetVerbaliPerTrasgressore();
            return View(verbali);
        }

        public IActionResult PuntiPerTrasgressore()
        {
            var punti = verbaleService.GetPuntiPerTrasgressore();
            return View(punti);
        }

        public IActionResult ViolazioniOltre10Punti()
        {
            var violazioni = verbaleService.GetViolazioniOltre10Punti();
            return View(violazioni);
        }

        public IActionResult ViolazioniOltre400Euro()
        {
            var violazioni = verbaleService.GetViolazioniOltre400Euro();
            return View(violazioni);
        }

        public IActionResult Report()
        {
            return View();
        }
    }
}
