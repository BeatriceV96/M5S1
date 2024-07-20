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
                
                return View(trasgressori);
         
        }
        
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrasgressoreViewModel trasgressore)
        {
            trasgressoreService.Create(trasgressore);
            return RedirectToAction("Index");
        }

      
    }
}