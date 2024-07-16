using DeliveryService.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using DeliveryService.DataLayer.Interfaces;

namespace DeliveryService.Controllers
{
    public class SpedizioniController : Controller
    {
        private readonly ISpedizioneService _spedizioneService;

        public SpedizioniController(ISpedizioneService spedizioneService)
        {
            _spedizioneService = spedizioneService;
        }
        public IActionResult Index()
        {
            var spedizioni = _spedizioneService.GetAllSpedizioni();
            return View(spedizioni);
        }
        public IActionResult Details(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }
            var spedizione = _spedizioneService.GetSpedizioneById(id.Value);
            if (spedizione == null)
            {
                return NotFound();
            }
            return View(spedizione);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Spedizione spedizione)
        {
            if (ModelState.IsValid)
            {

               _spedizioneService.AddSpedizione(spedizione);
                return RedirectToAction(nameof(Index));
            }
            return View(spedizione);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizione = _spedizioneService.GetSpedizioneById(id.Value);
            if (spedizione == null)
            {
                return NotFound();
            }
            return View(spedizione);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Spedizione spedizione)
        {
            if (id != spedizione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _spedizioneService.UpdateSpedizione(spedizione);
                return RedirectToAction(nameof(Index));
            }
            return View(spedizione);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizione = _spedizioneService.GetSpedizioneById(id.Value);
            if (spedizione == null)
            {
                return NotFound();
            }

            return View(spedizione);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _spedizioneService.DeleteSpedizione(id);
            return RedirectToAction(nameof(Index));
        }
    }
}