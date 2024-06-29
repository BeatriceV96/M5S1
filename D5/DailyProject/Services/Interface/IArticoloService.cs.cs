using DailyProject.Classi;
using System.Collections.Generic;

namespace DailyProject.Services.Interface
{
    public interface IArticoloService
    {
        List<Articolo> GetArticoli();
        void AddArticolo(Articolo articolo);
        void UpdateArticolo(Articolo articolo);

    }
}