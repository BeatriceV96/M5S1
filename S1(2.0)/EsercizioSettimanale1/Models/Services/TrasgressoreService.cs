using System.Collections.Generic;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.DAO;


namespace EsercitazioneSettimanale1.Services
{
    public class TrasgressoreService
    {
        private readonly TrasgressoreDao trasgressoreDao;

        public TrasgressoreService(TrasgressoreDao trasgressoreDao)
        {
            this.trasgressoreDao = trasgressoreDao;
        }

        public IEnumerable<TrasgressoreViewModel> GetAll()
        {
            return trasgressoreDao.GetAll();
        }

       

        public void Create(TrasgressoreViewModel trasgressore)
        {
            trasgressoreDao.Create(trasgressore);
        }

        
    }
}
