using Microsoft.AspNetCore.Mvc;
using EsercitazioneSettimanale1.Services;

namespace EsercitazioneSettimanale1.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly ViolazioneService violazioneService;

        public ViolazioneController(ViolazioneService violazioneService)
        {
            this.violazioneService = violazioneService;
        }

        public IActionResult Index()
        {
            var violazioni = violazioneService.GetAll();
            return View(violazioni);
        }
    }
}
