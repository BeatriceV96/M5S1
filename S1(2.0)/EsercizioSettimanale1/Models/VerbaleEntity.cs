namespace EsercitazioneSettimanale1.Models
{
    public class VerbaleEntity
    {
        public int IdVerbale { get; set; }
        public int IdAnagrafica { get; set; }
        public int IdViolazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get;  set; }
        public int TotaleVerbali { get; set; }


    }
}
