using ASC.Mobile.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Services
{
    public interface ICalendarioCorsiService
    {
        bool IsLoaded { get; }

        ObservableCollection<Corso> Corsi { get; }

        Task LoadAsync();
    }
}
