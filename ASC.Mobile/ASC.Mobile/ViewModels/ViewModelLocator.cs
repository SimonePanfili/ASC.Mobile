using Acr.UserDialogs;
using ASC.Mobile.Common;
using ASC.Mobile.Services;
using ASC.Mobile.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System.Globalization;

namespace ASC.Mobile.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(Constants.HomePage, typeof(HomePage));
            navigationService.Configure(Constants.CalendarioCorsiPage, typeof(CalendarioCorsiPage));
            navigationService.Configure(Constants.CalendarioGarePage, typeof(CalendarioGarePage));
            navigationService.Configure(Constants.ElencoNegoziPage, typeof(ElencoNegoziPage));
            navigationService.Configure(Constants.ElencoSocietaPage, typeof(ElencoSocietaPage));
            navigationService.Configure(Constants.TesseraPage, typeof(TesseraPage));
            navigationService.Configure(Constants.CorsoPage, typeof(CorsoPage));
            navigationService.Configure(Constants.GaraPage, typeof(GaraPage));
            navigationService.Configure(Constants.NegozioPage, typeof(NegozioPage));
            navigationService.Configure(Constants.SocietaPage, typeof(SocietaPage));
            SimpleIoc.Default.Register<NavigationService>(() => navigationService);

            SimpleIoc.Default.Register<IUserDialogs>(() => UserDialogs.Instance);

            SimpleIoc.Default.Register<ICalendarioCorsiService, Services.Demo.CalendarioCorsiService>();
            SimpleIoc.Default.Register<ICalendarioGareService, Services.Demo.CalendarioGareService>();
            SimpleIoc.Default.Register<INegoziService, Services.Demo.NegoziService>();
            SimpleIoc.Default.Register<ISocietaService, Services.Demo.SocietaService>();

            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<CalendarioCorsiViewModel>();
            SimpleIoc.Default.Register<CalendarioGareViewModel>();
            SimpleIoc.Default.Register<MasterViewModel>();
            SimpleIoc.Default.Register<ElencoSocietaViewModel>();
            SimpleIoc.Default.Register<ElencoNegoziViewModel>();
            SimpleIoc.Default.Register<CorsoViewModel>();
            SimpleIoc.Default.Register<GaraViewModel>();
            SimpleIoc.Default.Register<NegozioViewModel>();
            SimpleIoc.Default.Register<SocietaViewModel>();
            SimpleIoc.Default.Register<TesseraViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
        }

        public MenuViewModel MenuViewModel => ServiceLocator.Current.GetInstance<MenuViewModel>();

        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();

        public CalendarioGareViewModel CalendarioGareViewModel
            => ServiceLocator.Current.GetInstance<CalendarioGareViewModel>();

        public CalendarioCorsiViewModel CalendarioCorsiViewModel
            => ServiceLocator.Current.GetInstance<CalendarioCorsiViewModel>();

        public MasterViewModel MasterViewModel => ServiceLocator.Current.GetInstance<MasterViewModel>();

        public ElencoSocietaViewModel ElencoSocietaViewModel => ServiceLocator.Current.GetInstance<ElencoSocietaViewModel>();

        public ElencoNegoziViewModel ElencoNegoziViewModel => ServiceLocator.Current.GetInstance<ElencoNegoziViewModel>();

        public CorsoViewModel CorsoViewModel => ServiceLocator.Current.GetInstance<CorsoViewModel>();

        public GaraViewModel GaraViewModel => ServiceLocator.Current.GetInstance<GaraViewModel>();

        public NegozioViewModel NegozioViewModel => ServiceLocator.Current.GetInstance<NegozioViewModel>();

        public SocietaViewModel SocietaViewModel => ServiceLocator.Current.GetInstance<SocietaViewModel>();

        public TesseraViewModel TesseraViewModel => ServiceLocator.Current.GetInstance<TesseraViewModel>();
    }
}
