using System.Collections.Generic;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.Models.Interfaces;

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
            if (trasgressore.IdAnagrafica == 0)
            {
                return trasgressoreDao.Create(trasgressore);
            }
            else
            {
                return trasgressoreDao.Update(trasgressore);
            }
        }

        public void Delete(int id)
        {
            trasgressoreDao.Delete(id);
        }
    }
}
