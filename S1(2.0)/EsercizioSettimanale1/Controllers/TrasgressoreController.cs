using Microsoft.AspNetCore.Mvc;
using EsercitazioneSettimanale1.Services;
using EsercitazioneSettimanale1.Models;
using System;

namespace EsercitazioneSettimanale1.Controllers
{
    public class TrasgressoreController : Controller
    {
        private readonly TrasgressoreService trasgressoreService;

        public TrasgressoreController(TrasgressoreService trasgressoreService)
        {
            this.trasgressoreService = trasgressoreService;
        }

        public IActionResult Index()
        {
            
                var trasgressori = trasgressoreService.GetAll();
                var newTrasgressore = new TrasgressoreEntity();
                var viewModel = Tuple.Create(trasgressori, newTrasgressore);
                return View(viewModel);
         
        }
        [HttpPost]
        public IActionResult Create(TrasgressoreEntity trasgressore)
        {
            if (ModelState.IsValid)
            {
                trasgressoreService.Save(trasgressore);
                return RedirectToAction(nameof(Index));
            }
            var trasgressori = trasgressoreService.GetAll();
            var viewModel = Tuple.Create(trasgressori, trasgressore);
            return View("Index", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var trasgressore = trasgressoreService.GetById(id);
            if (trasgressore == null)
            {
                return NotFound();
            }
            var trasgressori = trasgressoreService.GetAll();
            var viewModel = Tuple.Create(trasgressori, trasgressore);
            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult EditConfirmed(TrasgressoreEntity trasgressore)
        {
            if (ModelState.IsValid)
            {
                trasgressoreService.Save(trasgressore);
                return RedirectToAction(nameof(Index));
            }
            var trasgressori = trasgressoreService.GetAll();
            var viewModel = Tuple.Create(trasgressori, trasgressore);
            return View("Index", viewModel);
        }

        public IActionResult Delete(int id)
        {
            var trasgressore = trasgressoreService.GetById(id);
            if (trasgressore == null)
            {
                return NotFound();
            }
            return View(trasgressore);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            trasgressoreService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}