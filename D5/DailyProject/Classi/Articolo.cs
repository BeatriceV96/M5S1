using DailyProject.Classi;


namespace DailyProject.Classi
{
        public class Articolo : ClassBase
        {
            public string Nome { get; set; }
            public decimal Prezzo { get; set; }
            public string Descrizione { get; set; }
            public string ImmagineCopertina { get; set; }
            public string ImmagineAggiuntiva1 { get; set; }
            public string ImmagineAggiuntiva2 { get; set; }
            public TipoArticolo Tipo { get; set; }
        }
}
