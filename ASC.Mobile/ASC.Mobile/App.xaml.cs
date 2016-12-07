using ASC.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ASC.Mobile
{
    public partial class App : Application
    {
        public static double ScreenWidth;
 		public static double ScreenHeight;

        public App()
        {
            InitializeComponent();

            MainPage = new MasterPage();
        }

        protected override async void OnStart()
        {
            // If the app is launched one hour after its last stop, its navigation history
            // will be restored.
            await this.MainPage.Navigation.RestoreAsync(TimeSpan.FromHours(1));
        }

        protected override void OnSleep()
        {
            this.MainPage.Navigation.Store();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
