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

namespace ASC.Mobile.ViewModels
{
    public partial class MasterViewModel : ViewModelBase
    {
        public MasterViewModel()
        {
            this.CreateCommands();
        }

        private void CreateCommands()
        {

        }
    }
}
