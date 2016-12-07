using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC.Mobile.Common.Models;

namespace ASC.Mobile.Services.Demo
{
    public class SocietaService : ISocietaService
    {
        public ObservableCollection<Societa> Strutture { get; } = new ObservableCollection<Societa>();

        public bool IsLoaded => true;

        public Task LoadAsync() => Task.FromResult<object>(null);

        public SocietaService()
        {
            Strutture.Add(new Societa
            {
                IdSocieta = 1243,
                Codice = "31802",
                Denominazione = "3m Training Associazione Sportiva Dilettantistica Ricreativa e Culturale",
                Acronimo = "3m Training Asdrc",
                ComitatoProvinciale = "C.P. ROMA",
                Address = new Address
                {
                    Street = "VIA DEI RUDERI, 8",
                    ZipCode = "00079",
                    Province = "RM",
                    City = "Rocca Priora",
                },
                Discipline = new List<string> { "FITNESS", "ATTIVITA' MOTORIA DI BASE", "ATTIVITA' LUDICO MOTORIA" },
                PhoneNumber = "3294426022",
                EMail = "info@fikm.it"
            });

            Strutture.Add(new Societa
            {
                IdSocieta = 4325,
                Codice = "27529",
                Denominazione = "Associazione Sportiva Dilettantistica a Lo Cubano",
                Acronimo = "a Lo Cubano Asd",
                ComitatoProvinciale = "C.P. ROMA",
                Address = new Address
                {
                    Street = "Via Aurelio Galleppini 22",
                    ZipCode = "00054",
                    Province = "RM",
                    City = "Roma Aeroporto"
                },
                Discipline = new List<string> { "DANZA", "BODY BUILDING - MUSCOLAZIONE", "DANZE CARAIBICHE" },
                PhoneNumber = "3382028504",
                EMail = "info@alocubano.it"
            });

            Strutture.Add(new Societa
            {
                IdSocieta = 1245,
                Codice = "31573",
                Denominazione = "Associazione Culturale Caspelart... Una Nuvola Rosa",
                Acronimo = "A.C. Caspelart... Una Nuvola Rosa",
                ComitatoProvinciale = "C.P. ROMA",
                Address = new Address
                {
                    Street = "Via delle Palme 6/C",
                    ZipCode = "00061",
                    Province = "RM",
                    City = "Anguillara Sabazia"
                },
                Discipline = new List<string> { "GIOCHI DI CARTE", "ATTIVITA' CULTURALI", "ATTIVITA' LUDICO MOTORIA", "ALTRO", "ATTIVITA' MOTORIA DI BASE", "BURRACO" },
                PhoneNumber = "3284562186",
                EMail = "caspelart@gmail.com"
            });

            Strutture.Add(new Societa
            {
                IdSocieta = 9076,
                Codice = "27808",
                Denominazione = "Associazione Polisportiva Dilettantistica Acilia Sport Red Foxes",
                Acronimo = "A.P.D. Acilia Sport Red Foxes",
                ComitatoProvinciale = "C.P. ROMA",
                Address = new Address
                {
                    Street = "VIA NICOLO' BALANZANO 41",
                    ZipCode = "00126",
                    Province = "RM",
                    City = "Roma"
                },
                Discipline = new List<string> { "PALLACANESTRO", "MINI BASKET" },
                PhoneNumber = "3395237098",
                EMail = "infobasket@aciliasport.it"
            });

            Strutture.Add(new Societa
            {
                IdSocieta = 8768,
                Codice = "29438",
                Denominazione = "Associazione Sportiva Dilettantistica Footvolley Association-Italia Sport Roma",
                Acronimo = "A.S.D.  Footvolley Association-Italia",
                Address = new Address
                {
                    Street = "VIA CRESCENZIO 25",
                    ZipCode = "00193",
                    Province = "RM",
                    City = "Roma"
                },
                Discipline = new List<string> { "ALTRO", "BEACH SPORT (VOLLEY-TENNIS-SOCCER)","BEACHVOLLEY" },
                PhoneNumber = "068390135",
                EMail = "info@footvolleyfederationitalia.it"
            });
        }
    }
}
