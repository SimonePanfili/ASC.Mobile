using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Common.Models
{
    public class Negozio : IGeographyLocation
    {
        public int IdNegozio { get; set; }

        public string Codice { get; set; }

        public string Denominazione { get; set; }

        public Position Position { get; set; }

        public Address Address { get; set; }

        public string PhoneNumber { get; set; }

        public string WebSite { get; set; }

        public string ImageSource { get; set; }
    }
}
