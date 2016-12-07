using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Common.Models
{
    public class Address
    {
        public string At { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Province { get; set; }

        public string FullAddress => this.ToString();

        public override string ToString()
        {
            var address = $"{Street}, {ZipCode}, {City}";

            if (!string.IsNullOrWhiteSpace(Province) && !City.ToUpper().StartsWith("ROMA"))
            {
                var province = Province == "RM" ? "ROMA" : Province;
                address = $"{address} ({province})";
            }

            if (!string.IsNullOrWhiteSpace(At))
                address = $"{At}, {address}";

            return address;
        }
    }
}
