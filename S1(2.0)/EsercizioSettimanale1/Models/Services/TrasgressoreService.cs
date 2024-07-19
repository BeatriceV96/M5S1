using System.Collections.Generic;
using EsercitazioneSettimanale1.Models;

namespace EsercitazioneSettimanale1.Services
{
    public class TrasgressoreService 
    {
        private readonly ITrasgressoreDao trasgressoreDao;

        public TrasgressoreService(ITrasgressoreDao trasgressoreDao)
        {
            this.trasgressoreDao = trasgressoreDao;
        }

        public IEnumerable<TrasgressoreEntity> GetAll()
        {
            return trasgressoreDao.GetAll();
        }

        public TrasgressoreEntity GetById(int id)
        {
            return trasgressoreDao.GetById(id);
        }

        public TrasgressoreEntity Save(TrasgressoreEntity trasgressore)
        {
            return trasgressoreDao.Save(trasgressore);
        }
    }
}
