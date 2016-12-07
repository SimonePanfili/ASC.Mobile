using ASC.Mobile.Common;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ASC.Mobile.Views
{
    public partial class CalendarioGarePage : ContentPageBase
    {
        public CalendarioGarePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Messenger.Default.Register<NotificationMessage>(this, msg =>
            {
                switch (msg.Notification)
                {
                    case Constants.RefreshCompleted:
                        gareListView.EndRefresh();
                        break;

                    default:
                        break;
                }
            });

            base.OnAppearing();
        }
    }
}
