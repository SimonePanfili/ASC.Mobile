using ASC.Mobile.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ASC.Mobile.Models;
using ASC.Mobile.Services;
using Microsoft.Practices.ServiceLocation;

namespace ASC.Mobile.Views
{
    public partial class MasterPage : MasterDetailPageBase
    {
        private readonly NavigationService navigationService;

        public MasterPage()
        {
            InitializeComponent();

            navigationService = ServiceLocator.Current.GetInstance<NavigationService>();
            menuPage.ListView.ItemTapped += OnItemTapped;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MasterPageItem;
            if (item != null)
            {
                IsPresented = false;

                var pageType = navigationService.GetPageType(item.PageKey);
                var displayPage = (Page)Activator.CreateInstance(pageType);
                Detail = new NavigationPage(displayPage);
                //Detail.Navigation.PushAsync(displayPage);

                menuPage.ListView.SelectedItem = null;
            }
        }
    }
}
