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
    public partial class SocietaViewModel : ViewModelBase
    {
        private readonly ISocietaService societaService;
        private readonly IPhoneService phoneService;

        private Societa societa;
        public Societa Societa
        {
            get { return societa; }
            set { this.Set(ref societa, value); }
        }

        public AutoRelayCommand<string> SendEMailCommand { get; set; }

        public AutoRelayCommand<string> MakeCallCommand { get; set; }

        public SocietaViewModel(ISocietaService societaService)
        {
            this.societaService = societaService;
            this.phoneService = DependencyService.Get<IPhoneService>();

            this.CreateCommands();
        }

        private void CreateCommands()
        {
            SendEMailCommand = new AutoRelayCommand<string>((mailAddress) =>
            {
                Device.OpenUri(new Uri($"mailto:{mailAddress}"));
            }, (mailAddress) => !string.IsNullOrWhiteSpace(mailAddress));

            MakeCallCommand = new AutoRelayCommand<string>(async (phoneNumber) =>
            {
                await phoneService.MakeCallAsync(phoneNumber);
            }, (phoneNumber) => phoneService != null && !string.IsNullOrWhiteSpace(phoneNumber));
        }

        public override async void Activate(object parameter)
        {
            IsBusy = true;
            Societa = null;

            try
            {
                // Recupera la società specificato.
                var idSocieta = Convert.ToInt32(parameter);

                if (!societaService.IsLoaded)
                    await societaService.LoadAsync();

                Societa = societaService.Strutture.FirstOrDefault(s => s.IdSocieta == idSocieta);

                if (Societa == null)
                    NavigationService.GoBack();
            }
            catch
            {
                await DialogService.AlertAsync("Errore durante il recupero della società.");
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
