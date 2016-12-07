using ASC.Mobile.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Services
{
    public interface ISocietaService
    {
        bool IsLoaded { get; }

        ObservableCollection<Societa> Strutture { get; }

        Task LoadAsync();
    }
}
