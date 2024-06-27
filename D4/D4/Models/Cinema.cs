using D4.Models;
using System.Collections.Generic;
using System.Linq;

public static class Cinema
{
    public static List<Ticket> Biglietti = new List<Ticket>();

    public static int CapienzaMassima = 120;

    public static Dictionary<string, int> SaleCapienza = new Dictionary<string, int>
    {
        {"SALA NORD", CapienzaMassima},
        {"SALA EST", CapienzaMassima},
        {"SALA SUD", CapienzaMassima}
    };

    public static Dictionary<string, int> SaleBigliettiVenduti = new Dictionary<string, int>
    {
        {"SALA NORD", 0},
        {"SALA EST", 0},
        {"SALA SUD", 0}
    };

    public static Dictionary<string, int> SaleBigliettiRidotti = new Dictionary<string, int>
    {
        {"SALA NORD", 0},
        {"SALA EST", 0},
        {"SALA SUD", 0}
    };

    public static void AggiungiBiglietto(Ticket ticket)
    {
        Biglietti.Add(ticket);
        SaleBigliettiVenduti[ticket.Sala]++;
        if (ticket.Tipo == "Ridotto")
        {
            SaleBigliettiRidotti[ticket.Sala]++;
        }
    }
}
