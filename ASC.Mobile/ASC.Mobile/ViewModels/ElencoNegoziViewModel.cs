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
    public class ElencoNegoziViewModel : ViewModelBase
    {
        private readonly INegoziService negoziService;

        public ObservableCollection<Negozio> Negozi => negoziService.Negozi;

        public AutoRelayCommand RefreshCommand { get; set; }

        public AutoRelayCommand<Negozio> ItemTappedCommand { get; set; }

        public ElencoNegoziViewModel(INegoziService negoziService)
        {
            this.negoziService = negoziService;

            this.CreateCommands();
        }

        private void CreateCommands()
        {
            RefreshCommand = new AutoRelayCommand(async () => await RefreshAsync(),
                () => !IsBusy).DependsOn(() => IsBusy);

            ItemTappedCommand = new AutoRelayCommand<Negozio>((negozio) => NavigationService.NavigateTo(Constants.NegozioPage, negozio.IdNegozio));
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;

            try
            {
                await negoziService.LoadAsync();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il caricamento dei negozi.");
            }
            finally
            {
                MessengerInstance.Send(new NotificationMessage(Constants.RefreshCompleted));
                IsBusy = false;
            }
        }

        public override async void Activate(object parameter)
        {
            if (!negoziService.IsLoaded)
                await this.RefreshAsync();

            base.Activate(parameter);
        }
    }
}
