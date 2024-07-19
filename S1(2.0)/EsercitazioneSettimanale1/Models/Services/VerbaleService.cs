using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.Models.Interfaces;
using EsercitazioneSettimanale1.Models.Services;

namespace EsercitazioneSettimanale1.Services
{
    public class VerbaleService
    {
        private readonly IVerbaleDao verbaleDao;

        public VerbaleService(IVerbaleDao verbaleDao)
        {
            this.verbaleDao = verbaleDao;
        }

        public IEnumerable<VerbaleEntity> GetVerbaliPerTrasgressore()
        {
            return verbaleDao.GetVerbaliPerTrasgressore();
        }

        public IEnumerable<VerbaleEntity> GetPuntiPerTrasgressore()
        {
            return verbaleDao.GetPuntiPerTrasgressore();
        }

        public IEnumerable<VerbaleEntity> GetViolazioniOltre10Punti()
        {
            return verbaleDao.GetViolazioniOltre10Punti();
        }

        public IEnumerable<VerbaleEntity> GetViolazioniOltre400Euro()
        {
            return verbaleDao.GetViolazioniOltre400Euro();
        }

        public void Save(VerbaleEntity verbale)
        {
            verbaleDao.Save(verbale);
        }
    }
}
