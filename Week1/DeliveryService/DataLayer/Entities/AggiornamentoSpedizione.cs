using System;

namespace DeliveryService.DataLayer.Entities
{
    public class AggiornamentoSpedizione
    {
        public int Id { get; set; }
        public int SpedizioneId { get; set; }
        public Spedizione? Spedizione { get; set; }
        public StatoSpedizione Stato { get; set; }
        public string? Luogo { get; set; }
        public string? Descrizione { get; set; }
        public DateTime DataOraAggiornamento { get; set; }
    }

    public enum StatoSpedizione
    {
        InTransito,
        InConsegna,
        Consegnato,
        NonConsegnato
    }
}
