using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Common.Models
{
    public class Corso : IGeographyLocation
    {
        public int IdCorso { get; set; }

        public string Codice { get; set; }

        public string Descrizione { get; set; }

        public string Disciplina { get; set; }

        public string Qualifica { get; set; }

        public string Organizzatore { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime DataFine { get; set; }

        public string CodiceDescrizione => $"{Codice} - {Descrizione}";

        public string Svolgimento => $"{DataInizio.ToString("dd/MM/yyyy")} - {DataFine.ToString("dd/MM/yyyy")}";

        public Position Position { get; set; }

        public Address Address { get; set; }
    }
}
