using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace Biometric
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
            {
                //AskForRelevantPermissionsAsync();
                //AskForRelevantPermissionsAsync().GetAwaiter().GetResult();
                //Mainthread virker ikke bra på IOS det kan kræsje
            }
            else if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await AskForRelevantPermissionsAsync();
                });
            }
        }

        private async Task AskForRelevantPermissionsAsync()
        {

            await AskforPermissionAsync<Permissions.LocationWhenInUse>();
            await AskforPermissionAsync<Permissions.LocationAlways>();


        }

        private async Task AskforPermissionAsync<TPermission>()
            where TPermission : BasePermission, new()
        {
            var result = await CheckStatusAsync<TPermission>();
            if (result != PermissionStatus.Granted)
                await RequestAsync<TPermission>();
        }

        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission)
            where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status;
        }


        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
