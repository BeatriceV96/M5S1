using DeliveryService.DataLayer.Entities;
using DeliveryService.DataLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DeliveryService.Controllers
{
    [Authorize]
    public class SpedizioniController : Controller
    {
        private readonly ISpedizioneDao _spedizioneDao;

        public SpedizioniController(ISpedizioneDao spedizioneDao)
        {
            _spedizioneDao = spedizioneDao;
        }

        public IActionResult Index()
        {
            var spedizioni = _spedizioneDao.ReadAll();
            return View(spedizioni);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spedizione = _spedizioneDao.Read(id.Value);
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
        public IActionResult Create(Spedizione spedizione)
        {
            if (ModelState.IsValid)
            {
                _spedizioneDao.Create(spedizione);
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

            var spedizione = _spedizioneDao.Read(id.Value);
            if (spedizione == null)
            {
                return NotFound();
            }
            return View(spedizione);
        }

        [HttpPost]
        public IActionResult Edit(int id, Spedizione spedizione)
        {
            if (id != spedizione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _spedizioneDao.Update(spedizione);
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

            var spedizione = _spedizioneDao.Read(id.Value);
            if (spedizione == null)
            {
                return NotFound();
            }

            return View(spedizione);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _spedizioneDao.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult VerificaStato()
        {
            return View(new VerificaSpedizioneModel());
        }

        [HttpPost]
        public IActionResult VerificaStato(VerificaSpedizioneModel model)
        {
            if (ModelState.IsValid)
            {
                var aggiornamenti = _spedizioneDao.GetAggiornamenti(model.CodiceFiscalePartitaIVA, model.NumeroSpedizione);
                return View("RisultatoStatoSpedizione", aggiornamenti);
            }

            return View(model);
        }

        [Authorize(Roles = "Amministratore")]
        public IActionResult InConsegnaOggi()
        {
            var spedizioni = _spedizioneDao.GetInConsegnaOggi();
            return View(spedizioni);
        }

        [Authorize(Roles = "Amministratore")]
        public IActionResult InAttesaDiConsegna()
        {
            var spedizioni = _spedizioneDao.GetInAttesaDiConsegna();
            return View(spedizioni);
        }

        [Authorize(Roles = "Amministratore")]
        public IActionResult RaggruppatePerCitta()
        {
            var spedizioni = _spedizioneDao.GetRaggruppatePerCitta();
            return View(spedizioni);
        }
    }
}
