using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC.Mobile.Common.Models;

namespace ASC.Mobile.Services.Demo
{
    public class NegoziService : INegoziService
    {
        public ObservableCollection<Negozio> Negozi { get; } = new ObservableCollection<Negozio>();

        public bool IsLoaded => true;

        public Task LoadAsync() => Task.FromResult<object>(null);

        public NegoziService()
        {
            Negozi.Add(new Negozio
            {
                IdNegozio = 1243,
                Codice = "10854",
                Denominazione = "Cisalfa Sport Roma",
                Address = new Address
                {
                    Street = "Via del Foro Italico 501",
                    ZipCode = "00194",
                    Province = "RM",
                    City = "Roma",
                },
                PhoneNumber = "068088026",
                WebSite = "http://www.cisalfasport.it/cisalfa/negozi/",
                ImageSource = "shop_red.png"
            });

            Negozi.Add(new Negozio
            {
                IdNegozio = 4325,
                Codice = "10185",
                Denominazione = "TuttoSport Articoli Sportivi",
                Address = new Address
                {
                    Street = "Giovanni Battista Morgagni, 8/10",
                    ZipCode = "00161",
                    Province = "RM",
                    City = "Roma"
                },
                PhoneNumber = "0644230421",
                WebSite = "http://www.tuttosport.it/",
                ImageSource = "shop_yellow.png"
            });

            Negozi.Add(new Negozio
            {
                IdNegozio = 1245,
                Codice = "10306",
                Denominazione = "Banchetti Sport",
                Address = new Address
                {
                    Street = "V. Campo Marzio, 38",
                    ZipCode = "00186",
                    Province = "RM",
                    City = "Roma"
                },
                PhoneNumber = "066871420",
                WebSite = "http://www.banchettisport.net/",
                ImageSource = "shop_yellow.png"
            });

            Negozi.Add(new Negozio
            {
                IdNegozio = 9076,
                Codice = "10406",
                Denominazione = "Decathlon Porta di Roma",
                Address = new Address
                {
                    At = "Galleria Commerciale Porta di Roma",
                    Street = "Via Alberto Lionello, 201",
                    ZipCode = "00139",
                    Province = "RM",
                    City = "Roma"
                },
                PhoneNumber = "0687074316",
                WebSite = "http://www.decathlon.it/it/store?store_id=PS_IT_43&rememberMe=off",
                ImageSource = "shop_red.png"
            });

            Negozi.Add(new Negozio
            {
                IdNegozio = 8768,
                Codice = "10423",
                Denominazione = "Universo Sport Roma",
                Address = new Address
                {
                    At = "Centro Commerciale Roma Est, C.C. 'RomaEst'",
                    Street = "Via Collatina 858",
                    ZipCode = "00155",
                    Province = "RM",
                    City = "Roma"
                },
                PhoneNumber = "0622878901",
                WebSite = "http://www.universosport.it/",
                ImageSource = "shop_yellow.png"
            });
        }
    }
}
