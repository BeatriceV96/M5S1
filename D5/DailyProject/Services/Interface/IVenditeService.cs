using DailyProject.Classi;
using System.Collections.Generic;

namespace DailyProject.Services.Interface
{
    public interface IVenditeService
    {
        List<Vendita> GetVendite();
        void AddVendita(Vendita vendita);
    }
}
