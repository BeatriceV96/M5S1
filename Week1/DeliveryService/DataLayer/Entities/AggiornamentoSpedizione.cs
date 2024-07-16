using System;

namespace DeliveryService.DataLayer.Entities
{
    public class AggiornamentoSpedizione
    {
        public int Id { get; set; }
        public int SpedizioneId { get; set; }
        public Spedizione? Spedizione { get; set; } // Corretto per assicurare che Spedizione sia definita correttamente
        public StatoSpedizione Stato { get; set; }
        public string? Luogo { get; set; } // Rendere nullable
        public string? Descrizione { get; set; } // Rendere nullable
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
