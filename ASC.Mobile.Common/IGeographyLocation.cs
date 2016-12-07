using ASC.Mobile.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Common
{
    public interface IGeographyLocation
    {
        Position Position { get; set; }

        Address Address { get; set; }
    }
}
