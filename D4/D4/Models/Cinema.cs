using D4.Models;
using System.Collections.Generic;
using System.Linq;

public static class Cinema
{
    // Lista statica per memorizzare i biglietti venduti
    public static List<Ticket> Biglietti = new List<Ticket>();

    // Capienza massima di ogni sala
    public static int CapienzaMassima = 120;

    // Dizionario per memorizzare la capienza delle sale
    public static Dictionary<string, int> SaleCapienza = new Dictionary<string, int>
    {
        {"SALA NORD", CapienzaMassima},
        {"SALA EST", CapienzaMassima},
        {"SALA SUD", CapienzaMassima}
    };

    // Dizionario per memorizzare il numero di biglietti venduti per ogni sala
    public static Dictionary<string, int> SaleBigliettiVenduti = new Dictionary<string, int>
    {
        {"SALA NORD", 0},
        {"SALA EST", 0},
        {"SALA SUD", 0}
    };

    // Dizionario per memorizzare il numero di biglietti ridotti venduti per ogni sala
    public static Dictionary<string, int> SaleBigliettiRidotti = new Dictionary<string, int>
    {
        {"SALA NORD", 0},
        {"SALA EST", 0},
        {"SALA SUD", 0}
    };

    // Metodo per aggiungere un nuovo biglietto
    public static void AggiungiBiglietto(Ticket ticket)
    {
        // Aggiunge il biglietto alla lista dei biglietti venduti
        Biglietti.Add(ticket);

        // Incrementa il numero di biglietti venduti per la sala specificata
        SaleBigliettiVenduti[ticket.Sala]++;

        // Se il biglietto è di tipo "Ridotto", incrementa anche il contatore dei biglietti ridotti
        if (ticket.Tipo == "Ridotto")
        {
            SaleBigliettiRidotti[ticket.Sala]++;
        }
    }
}
