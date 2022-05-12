/*using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biometric.Droid
{
    [Activity(Label = "ShareActivity", MainLauncher = true, Name = "com.companyname.Biometric.Droid.ShareActivity")]
    public class ShareActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            IntentFilter filter = new IntentFilter();
            filter.AddAction(Intent.ActionGetContent);
            filter.AddCategory(Intent.CategoryDefault);

            // AndroidID device = new AndroidID();
            // string deviceIdentifier = device.GetIdentifier();

            string deviceIdentifier = "32346253";

            Intent result = new Intent();
            result.PutExtra("key", deviceIdentifier);

            SetResult(Result.Ok, result);

            //Toast.MakeText(this, deviceIdentifier, ToastLength.Short).Show();

            //Finish();

            // Create your application here
        }
    }
}
*/

using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
//using LockTapReceiver;
using System;
using Xamarin.Forms;
using AndroidX.Core;

namespace Biometric.Droid

{
    [Activity(Label = "Biometric",Theme = "@style/MainTheme", /*Theme = "@style/Theme.Biometric",/* Theme = "@style/MainTheme",*/ MainLauncher = true, Name = "com.companyname.biometric.ShareActivity")]
    public class ShareActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
           // SetContentView(Resource.Layout.activity_main);

            IntentFilter filter = new IntentFilter();
            filter.AddAction(Intent.ActionGetContent);
            filter.AddCategory(Intent.CategoryDefault);

            // AndroidID device = new AndroidID();
            string deviceIdentifier = "5214";


            Intent result = new Intent();
            result.PutExtra("key", deviceIdentifier);

            SetResult(Result.Ok, result);

            // Toast.MakeText(this, deviceIdentifier, ToastLength.Short).Show();

           // Finish();

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}