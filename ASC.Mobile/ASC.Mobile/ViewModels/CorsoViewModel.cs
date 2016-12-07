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
    public partial class CorsoViewModel : ViewModelBase
    {
        private readonly ICalendarioCorsiService calendarioCorsiService;

        private Corso corso;
        public Corso Corso
        {
            get { return corso; }
            set { this.Set(ref corso, value); }
        }

        public CorsoViewModel(ICalendarioCorsiService calendarioCorsiService)
        {
            this.calendarioCorsiService = calendarioCorsiService;

            this.CreateCommands();
        }

        private void CreateCommands()
        {

        }

        public override async void Activate(object parameter)
        {
            IsBusy = true;
            Corso = null;

            try
            {
                // Recupera il corso specificato.
                var idCorso = Convert.ToInt32(parameter);

                if (!calendarioCorsiService.IsLoaded)
                    await calendarioCorsiService.LoadAsync();

                Corso = calendarioCorsiService.Corsi.FirstOrDefault(c => c.IdCorso == idCorso);

                if (Corso == null)
                    NavigationService.GoBack();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il recupero del corso.");
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
