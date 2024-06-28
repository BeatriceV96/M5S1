using DailyProject.Classi;
using DailyProject.Services.Interface;


namespace DailyProject.Services
{
    public class ArticoloService : IArticoloService
    {
        private static List<Articolo> articoli = new List<Articolo>
        {
            new Articolo
            {
                Id = 1,
                Nome = "Scarpe da Tennis",
                Prezzo = 59.99m,
                Descrizione = "Scarpe da tennis comode e resistenti, senza rinunciare allo stile!",
                ImmagineCopertina = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0W4MPv9ikplnBiatD382HA-kea8T6nSzFOw&s",
                Tipo = TipoArticolo.Tennis
            },
            new Articolo
            {
                Id = 2,
                Nome = "Scarpe da Running",
                Prezzo = 79.99m,
                Descrizione = "Scarpe da running leggere e performanti.",
                ImmagineCopertina = "https://dimages2.corriereobjects.it/uploads/2022/05/10/6408c5410f407.jpeg",
                Tipo = TipoArticolo.Running
            }
        };

        public List<Articolo> GetArticoli()
        {
            return articoli;
        }

        public void AddArticolo(Articolo articolo)
        {
            articolo.Id = articoli.Any() ? articoli.Max(a => a.Id) + 1 : 1;
            articoli.Add(articolo);
        }
    }
}
