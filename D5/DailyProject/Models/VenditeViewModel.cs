using DailyProject.Classi;
using System.Collections.Generic;

namespace DailyProject.Models
{
    public class VenditeViewModel
    {
        public int ArticoloId { get; set; }
        public string NomeCliente { get; set; }
        public string CognomeCliente { get; set; }
        public List<Articolo> Articoli { get; set; }
    }
}
