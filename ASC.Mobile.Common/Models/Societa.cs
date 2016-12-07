using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Common.Models
{
    public class Societa : IGeographyLocation
    {
        public int IdSocieta { get; set; }

        public string Codice { get; set; }

        public string Denominazione { get; set; }

        public string Acronimo { get; set; }

        public string ComitatoProvinciale { get; set; }

        public string CodiceDenominazione => $"{Codice} - {Denominazione}";

        public string CodiceAcronimo => $"{Codice} - {Acronimo}";

        public Position Position { get; set; }

        public Address Address { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSite { get; set; }

        public string EMail { get; set; }

        public IEnumerable<string> Discipline { get; set; } = new List<string>();
    }
}
