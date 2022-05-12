using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.Fingerprint;
using Android.Content;
using Android.Widget;
using Xamarin.Forms;

namespace Biometric.Droid
{
    [Activity(Label = "Biometric", Icon = "@mipmap/icon", Theme = "@style/MainTheme", Exported = true, Name = "com.companyname.biometric.MainActivity", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            CrossFingerprint.SetCurrentActivityResolver(() =>
                Xamarin.Essentials.Platform.CurrentActivity);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            {
                var devInfo = DependencyService.Get<IDev>();
                var nie = devInfo.GetIdentifier();
                string deviceIdentifier = nie;

                Intent result = new Intent();
                result.PutExtra("key", deviceIdentifier);

                SetResult(Result.Ok, result);

                //Toast.MakeText(this, deviceIdentifier, ToastLength.Short).Show();

               Finish();
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}