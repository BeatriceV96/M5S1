using DeliveryService.DataLayer.Entities;
using System.Collections.Generic;

namespace DeliveryService.DataLayer.Interfaces
{
    public interface ISpedizioneDao
    {
        /// <summary>
        /// Crea una spedizione.
        /// </summary>
        /// <param name="spedizione">Dettagli della spedizione.</param>
        void Create(Spedizione spedizione);

        /// <summary>
        /// Elimina una spedizione.
        /// </summary>
        /// <param name="id">ID della spedizione.</param>
        void Delete(int id);

        /// <summary>
        /// Recupera i dati di una spedizione.
        /// </summary>
        /// <param name="id">ID della spedizione.</param>
        Spedizione Read(int id);

        /// <summary>
        /// Aggiorna i dati di una spedizione.
        /// </summary>
        /// <param name="spedizione">Dettagli aggiornati della spedizione.</param>
        void Update(Spedizione spedizione);

        /// <summary>
        /// Recupera tutte le spedizioni.
        /// </summary>
        List<Spedizione> ReadAll();

        /// <summary>
        /// Recupera gli aggiornamenti di una spedizione.
        /// </summary>
        /// <param name="codiceFiscalePartitaIVA">Codice fiscale o partita IVA.</param>
        /// <param name="numeroSpedizione">Numero di spedizione.</param>
        List<AggiornamentoSpedizione> GetAggiornamenti(string codiceFiscalePartitaIVA, string numeroSpedizione);

        /// <summary>
        /// Recupera le spedizioni in consegna oggi.
        /// </summary>
        List<Spedizione> GetInConsegnaOggi();

        /// <summary>
        /// Recupera le spedizioni in attesa di consegna.
        /// </summary>
        List<Spedizione> GetInAttesaDiConsegna();

        /// <summary>
        /// Recupera le spedizioni raggruppate per città.
        /// </summary>
        Dictionary<string, int> GetRaggruppatePerCitta();
    }
}
