using DailyProject.Classi;
using DailyProject.Services.Interface;
using System.Collections.Generic;

namespace DailyProject.Services
{
    public class VenditeService : IVenditeService
    {
        private static List<Vendita> vendite = new List<Vendita>();

        public List<Vendita> GetVendite()
        {
            return vendite;
        }

        public void AddVendita(Vendita vendita)
        {
            vendite.Add(vendita);
        }
    }
}
