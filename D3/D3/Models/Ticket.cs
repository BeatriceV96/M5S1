namespace D3.Models
{

    public class Ticket
    {
        public string Sala { get; set; }
        public TipoBiglietto Tipo { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
    }

    public enum TipoBiglietto
    {
        Intero,
        Ridotto
    }
}