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

namespace ASC.Mobile.ViewModels
{
    public partial class GaraViewModel : ViewModelBase
    {
        private readonly ICalendarioGareService calendarioGareService;

        private Gara gara;
        public Gara Gara
        {
            get { return gara; }
            set { this.Set(ref gara, value); }
        }

        public GaraViewModel(ICalendarioGareService calendarioGareService)
        {
            this.calendarioGareService = calendarioGareService;

            this.CreateCommands();
        }

        private void CreateCommands()
        {

        }

        public override async void Activate(object parameter)
        {
            IsBusy = true;
            Gara = null;

            try
            {
                // Recupera la gara specificata.
                var idGara = Convert.ToInt32(parameter);

                if (!calendarioGareService.IsLoaded)
                    await calendarioGareService.LoadAsync();

                Gara = calendarioGareService.Gare.FirstOrDefault(c => c.IdGara == idGara);

                if (Gara == null)
                    NavigationService.GoBack();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il recupero della gara.");
                NavigationService.GoBack();
            }
            finally
            {
                IsBusy = false;
            }

            base.Activate(parameter);
        }
    }
}
