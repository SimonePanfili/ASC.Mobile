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
    public class ElencoSocietaViewModel : ViewModelBase
    {
        private readonly ISocietaService societaService;

        public ObservableCollection<Societa> Strutture => societaService.Strutture;

        public AutoRelayCommand RefreshCommand { get; set; }

        public AutoRelayCommand<Societa> ItemTappedCommand { get; set; }

        public ElencoSocietaViewModel(ISocietaService societaService)
        {
            this.societaService = societaService;

            this.CreateCommands();
        }

        private void CreateCommands()
        {
            RefreshCommand = new AutoRelayCommand(async () => await RefreshAsync(),
                () => !IsBusy).DependsOn(() => IsBusy);

            ItemTappedCommand = new AutoRelayCommand<Societa>((Societa) => NavigationService.NavigateTo(Constants.SocietaPage, Societa.IdSocieta));
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;

            try
            {
                await societaService.LoadAsync();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il caricamento delle società.");
            }
            finally
            {
                MessengerInstance.Send(new NotificationMessage(Constants.RefreshCompleted));
                IsBusy = false;
            }
        }

        public override async void Activate(object parameter)
        {
            if (!societaService.IsLoaded)
                await this.RefreshAsync();

            base.Activate(parameter);
        }
    }
}