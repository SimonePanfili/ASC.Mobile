using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Common.Models
{
    public class Gara : IGeographyLocation
    {
        public int IdGara { get; set; }

        public string Codice { get; set; }

        public string Descrizione { get; set; }

        public string Disciplina { get; set; }

        public DateTime DataInizio { get; set; }

        public DateTime? DataFine { get; set; }

        public string CodiceDescrizione => $"{Codice} - {Descrizione}";

        public string Svolgimento
        {
            get
            {
                var svolgimento = DataInizio.ToString("dd/MM/yyyy");

                if (DataFine != null && DataFine != DateTime.MinValue)
                    svolgimento = $"{svolgimento} - {DataFine.Value.ToString("dd/MM/yyyy")}";

                return svolgimento;
            }
        }

        public Position Position { get; set; }

        public Address Address { get; set; }
    }
}
