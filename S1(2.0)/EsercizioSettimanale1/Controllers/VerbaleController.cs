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
            List<VerbaleEntity> verbali = verbaleService.GetVerbali();
            return View(verbali);
        }

        public IActionResult Create()
        {
            ViewBag.Trasgressori = verbaleService.GetTrasgressori();
            ViewBag.Violazioni = violazioneService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VerbaleEntity verbale)
        {
            verbaleService.CreateVerbale(verbale);
            return RedirectToAction("Index");
        }

        public IActionResult VerbaliPerTrasgressore()
        {
            List<VerbaleEntity> verbali = verbaleService.GetVerbaliPerTrasgressore();
            return View(verbali);
        }

        public IActionResult ViolazioniOltre10Punti()
        {
            List<VerbaleEntity> verbali = verbaleService.GetViolazioniOltre10Punti();
            return View(verbali);
        }

        public IActionResult ViolazioniOltre400Euro()
        {
            List<VerbaleEntity> verbali = verbaleService.GetVerbaliOltre400Euro();
            return View(verbali);
        }
        
        public IActionResult TotalePunti()
        {
            List<VerbaleEntity> verbali = verbaleService.GetTotalePunti();
            return View(verbali);
        }
       
    }
}
