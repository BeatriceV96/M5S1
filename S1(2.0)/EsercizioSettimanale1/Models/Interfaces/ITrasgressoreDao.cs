using System.Collections.Generic;
using EsercitazioneSettimanale1.Models;

namespace EsercitazioneSettimanale1.Services
{
    public interface ITrasgressoreDao
    {
        IEnumerable<TrasgressoreEntity> GetAll();
        TrasgressoreEntity GetById(int id);
        TrasgressoreEntity Create(TrasgressoreEntity trasgressore);
        TrasgressoreEntity Update(TrasgressoreEntity trasgressore);
        void Delete(int id);
    }
}
