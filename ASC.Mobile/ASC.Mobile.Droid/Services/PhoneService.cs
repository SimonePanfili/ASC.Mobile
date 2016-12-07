using Android.Content;
using ASC.Mobile.Droid.Services;
using ASC.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneService))]
namespace ASC.Mobile.Droid.Services
{
    public class PhoneService : IPhoneService
    {
        public Task MakeCallAsync(string number)
        {
            var uri = Android.Net.Uri.Parse($"tel:{number}");
            var intent = new Intent(Intent.ActionCall, uri);
            Forms.Context.StartActivity(intent);

            return Task.CompletedTask;
        }
    }
}
