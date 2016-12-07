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
using ASC.Mobile.Services;
using ASC.Mobile.Common.Models;

namespace ASC.Mobile.ViewModels
{
    public partial class CalendarioCorsiViewModel : ViewModelBase
    {
        private readonly ICalendarioCorsiService calendarioCorsiService;

        public ObservableCollection<Corso> Corsi => calendarioCorsiService.Corsi;

        public AutoRelayCommand RefreshCommand { get; set; }

        public AutoRelayCommand<Corso> ItemTappedCommand { get; set; }

        public CalendarioCorsiViewModel(ICalendarioCorsiService calendarioCorsiService)
        {
            this.calendarioCorsiService = calendarioCorsiService;

            this.CreateCommands();
        }

        private void CreateCommands()
        {
            RefreshCommand = new AutoRelayCommand(async () => await RefreshAsync(),
                () => !IsBusy).DependsOn(() => IsBusy);

            ItemTappedCommand = new AutoRelayCommand<Corso>((corso) => NavigationService.NavigateTo(Constants.CorsoPage, corso.IdCorso));
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;

            try
            {
                await calendarioCorsiService.LoadAsync();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il caricamento dei corsi.");
            }
            finally
            {
                MessengerInstance.Send(new NotificationMessage(Constants.RefreshCompleted));
                IsBusy = false;
            }
        }

        public override async void Activate(object parameter)
        {
            if (!calendarioCorsiService.IsLoaded)
                await this.RefreshAsync();

            base.Activate(parameter);
        }
    }
}
