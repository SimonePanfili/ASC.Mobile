using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using ASC.Mobile.Common;
using ASC.Mobile.Common.Models;
using ASC.Mobile.Services;
using ASC.Mobile.Models;

namespace ASC.Mobile.ViewModels
{
    public partial class MenuViewModel : ViewModelBase
    {
        public ObservableCollection<MasterPageItem> Menu { get; } = new ObservableCollection<MasterPageItem>();

        public MenuViewModel()
        {
            Menu.Add(new MasterPageItem
            {
                Title = "Home Page",
                IconSource = "icon2.png",
                PageKey = Constants.HomePage
            });

            Menu.Add(new MasterPageItem
            {
                Title = "Calendario Corsi",
                IconSource = "course.png",
                PageKey = Constants.CalendarioCorsiPage
            });

            Menu.Add(new MasterPageItem
            {
                Title = "Calendario Gare",
                IconSource = "activity.png",
                PageKey = Constants.CalendarioGarePage
            });

            Menu.Add(new MasterPageItem
            {
                Title = "Negozi",
                IconSource = "shop.png",
                PageKey = Constants.ElencoNegoziPage
            });

            Menu.Add(new MasterPageItem
            {
                Title = "Società",
                IconSource = "society.png",
                PageKey = Constants.ElencoSocietaPage
            });

            Menu.Add(new MasterPageItem
            {
                Title = "La mia tessera",
                IconSource = "card2.png",
                PageKey = Constants.TesseraPage
            });

            this.CreateCommands();
        }

        private void CreateCommands()
        {

        }
    }
}
