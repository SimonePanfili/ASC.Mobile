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
    public class CalendarioGareViewModel : ViewModelBase
    {
        private readonly ICalendarioGareService calendarioGareService;

        public ObservableCollection<Gara> Gare => calendarioGareService.Gare;

        public AutoRelayCommand RefreshCommand { get; set; }

        public AutoRelayCommand<Gara> ItemTappedCommand { get; set; }

        public CalendarioGareViewModel(ICalendarioGareService calendarioGareService)
        {
            this.calendarioGareService = calendarioGareService;

            this.CreateCommands();
        }

        private void CreateCommands()
        {
            RefreshCommand = new AutoRelayCommand(async () => await RefreshAsync(),
                () => !IsBusy).DependsOn(() => IsBusy);

            ItemTappedCommand = new AutoRelayCommand<Gara>((gara) => NavigationService.NavigateTo(Constants.GaraPage, gara.IdGara));
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;

            try
            {
                await calendarioGareService.LoadAsync();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il caricamento delle gare.");
            }
            finally
            {
                MessengerInstance.Send(new NotificationMessage(Constants.RefreshCompleted));
                IsBusy = false;
            }
        }

        public override async void Activate(object parameter)
        {
            if (!calendarioGareService.IsLoaded)
                await this.RefreshAsync();

            base.Activate(parameter);
        }
    }
}
