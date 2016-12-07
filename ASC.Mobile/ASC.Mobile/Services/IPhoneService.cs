using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Services
{
    public interface IPhoneService
    {
        Task MakeCallAsync(string number);
    }
}
