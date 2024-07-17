namespace DeliveryService.DataLayer.Entities
{
    public class ClienteSpedizioneModel
    {
        public string NomeCliente { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIVA { get; set; }
        public string NumeroIdentificativo { get; set; }
        public DateTime DataSpedizione { get; set; }
        public decimal Peso { get; set; }
        public string CittaDestinataria { get; set; }
        public string IndirizzoDestinatario { get; set; }
        public string NominativoDestinatario { get; set; }
        public decimal Costo { get; set; }
        public DateTime DataConsegnaPrevista { get; set; }
    }
}
