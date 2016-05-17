using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Lisa.Quartets.Mobile;
using System.Threading.Tasks;

namespace Lisa.Quartets.Droid
{
    [Activity(Label = "Lisa.Quartets", Icon = "@drawable/ic_launcher", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }       

		public async override void OnBackPressed() 
		{
            if (_toasting)
            {
                _toast.Cancel();
                this.Finish();
            }
            else
            {
                _toasting = true;
                _toast = Toast.MakeText(this, "klik nogeens op de terugknop om de app af te sluiten", ToastLength.Long);
                _toast.Show();
                
                await Task.Delay(4000);
                
                _toasting = false;
            }
		}

        private bool _toasting = false;
        private Toast _toast;
    }
}

