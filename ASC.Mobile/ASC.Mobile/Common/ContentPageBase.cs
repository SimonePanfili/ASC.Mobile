using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ASC.Mobile.Extensions;
using GalaSoft.MvvmLight.Messaging;

namespace ASC.Mobile.Common
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            //if (Device.OS != TargetPlatform.iOS)
            //    NavigationPage.SetHasNavigationBar(this, false);

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
        }

        protected override void OnAppearing()
        {
            var dataContext = this.BindingContext as INavigable;
            if (dataContext != null)
                dataContext.Activate(this.GetNavigationArgs());

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            var dataContext = this.BindingContext as INavigable;
            if (dataContext != null)
                dataContext.Deactivate();

            Messenger.Default.Unregister(this);
            base.OnDisappearing();

        }
    }
}
