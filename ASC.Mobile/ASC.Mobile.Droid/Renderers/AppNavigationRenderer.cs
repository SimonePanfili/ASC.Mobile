using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using ASC.Mobile.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(AppNavigationRenderer))]
namespace ASC.Mobile.Droid.Renderers
{
    public class AppNavigationRenderer : NavigationPageRenderer
    {
        private Toolbar toolbar;

        //protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        //{
        //    base.OnElementChanged(e);

        //    var toolbar = this.FindViewById<Toolbar>(Resource.Id.toolbar);

        //    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
        //    {
        //        var activity = ((FormsAppCompatActivity)Context);
        //        toolbar.Logo = activity.GetDrawable(Resource.Drawable.appbar_icon);
        //    }
        //    else
        //    {
        //        toolbar.Logo = Resources.GetDrawable(Resource.Drawable.appbar_icon);
        //    }
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            this.SetAppIcon();
        }

        private void SetAppIcon()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var activity = ((FormsAppCompatActivity)Context);
                toolbar.Logo = activity.GetDrawable(Resource.Drawable.appbar_icon);
            }
            else
            {
                toolbar.Logo = Resources.GetDrawable(Resource.Drawable.appbar_icon);
            }

            toolbar.RefreshDrawableState();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("Width"))
                this.SetAppIcon();
        }

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Toolbar))
                toolbar = (Toolbar)child;
        }
    }
}