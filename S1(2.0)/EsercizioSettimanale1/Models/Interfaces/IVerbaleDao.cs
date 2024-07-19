using EsercitazioneSettimanale1.Models;

namespace EsercitazioneSettimanale1.Models.Interfaces
{
    public interface IVerbaleDao
    {
        IEnumerable<VerbaleEntity> GetVerbaliPerTrasgressore();
        IEnumerable<VerbaleEntity> GetPuntiPerTrasgressore();
        IEnumerable<VerbaleEntity> GetViolazioniOltre10Punti();
        IEnumerable<VerbaleEntity> GetViolazioniOltre400Euro();
        void Save(VerbaleEntity verbale);
    }
}
