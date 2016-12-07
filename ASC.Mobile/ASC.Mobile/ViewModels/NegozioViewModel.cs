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
    public partial class NegozioViewModel : ViewModelBase
    {
        private readonly INegoziService negozioService;
        private readonly IPhoneService phoneService;

        private Negozio negozio;
        public Negozio Negozio
        {
            get { return negozio; }
            set { this.Set(ref negozio, value); }
        }

        public AutoRelayCommand<string> GotoWebSiteCommand { get; set; }

        public AutoRelayCommand<string> MakeCallCommand { get; set; }

        public NegozioViewModel(INegoziService negozioService)
        {
            this.negozioService = negozioService;
            this.phoneService = DependencyService.Get<IPhoneService>();

            this.CreateCommands();
        }

        private void CreateCommands()
        {
            GotoWebSiteCommand = new AutoRelayCommand<string>((url) =>
            {
                Device.OpenUri(new Uri(url));
            }, (url) => !string.IsNullOrWhiteSpace(url));

            MakeCallCommand = new AutoRelayCommand<string>(async (phoneNumber) =>
            {
                await phoneService.MakeCallAsync(phoneNumber);
            }, (phoneNumber) => phoneService != null && !string.IsNullOrWhiteSpace(phoneNumber));
        }

        public override async void Activate(object parameter)
        {
            IsBusy = true;
            Negozio = null;

            try
            {
                // Recupera il negozio specificato.
                var idNegozio = Convert.ToInt32(parameter);

                if (!negozioService.IsLoaded)
                    await negozioService.LoadAsync();

                Negozio = negozioService.Negozi.FirstOrDefault(c => c.IdNegozio == idNegozio);

                if (Negozio == null)
                    NavigationService.GoBack();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il recupero del negozio.");
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
