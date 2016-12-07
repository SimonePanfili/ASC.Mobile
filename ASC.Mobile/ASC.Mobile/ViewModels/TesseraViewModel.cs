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
    public class FotoTessera
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string SezioneTessera { get; set; }
    }

    public class TesseraViewModel : ViewModelBase
    {
        public ObservableCollection<FotoTessera> Tessera { get; set; }

        private FotoTessera current;
        public FotoTessera Current
        {
            get { return current; }
            set { this.Set(ref current, value); }
        }

        public AutoRelayCommand<string> ChangePhotoCommand { get; set; }

        public TesseraViewModel()
        {
            Tessera = new ObservableCollection<FotoTessera>
            {
                new FotoTessera
                {
                    ImageUrl = "tessera_fronte.png",
                    Name = "Tessera (fronte)",
                    SezioneTessera = "fronte"
                },
                new FotoTessera
                {
                    ImageUrl = "tessera_retro.png",
                    Name = "Tessera (retro)",
                    SezioneTessera = "retro"
                }
            };

            this.CreateCommands();
        }

        private void CreateCommands()
        {
            ChangePhotoCommand = new AutoRelayCommand<string>((photo) =>
            {
                Current = Tessera.FirstOrDefault(t => t.SezioneTessera.ToLower() == photo.ToLower());
            });
        }

        public override void Activate(object parameter)
        {
            Current = Tessera.FirstOrDefault();
            base.Activate(parameter);
        }
    }
}
