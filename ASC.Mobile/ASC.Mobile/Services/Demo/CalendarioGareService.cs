using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC.Mobile.Common.Models;

namespace ASC.Mobile.Services.Demo
{
    public class CalendarioGareService : ICalendarioGareService
    {
        public ObservableCollection<Gara> Gare { get; } = new ObservableCollection<Gara>();

        public bool IsLoaded => true;

        public Task LoadAsync() => Task.FromResult<object>(null);

        public CalendarioGareService()
        {
            Gare.Add(new Gara
            {
                IdGara = 1243,
                Codice = "10854",
                Descrizione = "BURRACO SOTTO LE STELLE",
                Disciplina = "BURRACO",
                DataInizio = DateTime.Now,
                Address = new Address
                {
                    At = "Lungomare",
                    Street = "Via Partenope",
                    ZipCode = "80010",
                    Province = "NA",
                    City = "Napoli"
                }
            });
        }
    }
}
