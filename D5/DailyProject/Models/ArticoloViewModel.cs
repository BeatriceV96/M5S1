using Microsoft.AspNetCore.Http; // Aggiungi questo using per IFormFile
using System.ComponentModel.DataAnnotations;

namespace DailyProject.Models
{
    public class ArticoloViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome"), Required]
        public string Nome { get; set; }
        [Display(Name = "Prezzo"), Required]
        public decimal Prezzo { get; set; }
        [Display(Name = "Descrizione"), Required]
        public string Descrizione { get; set; }
        [Display(Name = "Immagine Copertina"), Required]
        public IFormFile? ImmagineCopertina { get; set; } // Modificato da string a IFormFile
        [Display(Name = "Immagine Aggiuntiva 1")]
        public IFormFile? ImmagineAggiuntiva1 { get; set; }
        [Display(Name = "Immagine Aggiuntiva 2")]
        public IFormFile? ImmagineAggiuntiva2 { get; set; }
        [Display(Name = "Tipo"), Required]
        public string Tipo { get; set; } = string.Empty;
    }
}
