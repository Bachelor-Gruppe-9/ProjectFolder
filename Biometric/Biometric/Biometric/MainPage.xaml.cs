using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Essentials;
using Plugin.BLE;
using Xamarin.Forms;
using Plugin.BLE.Abstractions.Contracts;
using Android;
using Android.Bluetooth;

namespace Biometric
{
    public partial class MainPage : ContentPage
    {
        IBluetoothLE ble = CrossBluetoothLE.Current;
        IAdapter adapter = CrossBluetoothLE.Current.Adapter;
        List<IDevice> deviceList = new List<IDevice>();

        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var availability = await
                CrossFingerprint.Current.IsAvailableAsync();

            if (!availability)
            {
                await DisplayAlert("Advarsel!", " Biometri ikke registrert", "OK");

                return;

            }

            var authResult = await
                CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Lås opp med biometri", "Les av med fingeravtrykk" ));

            if (authResult.Authenticated)
            {
                await DisplayAlert("Fingeravtrykk godkjent", "Døren er låst opp",  "Lukk");
               
            }

            if (!authResult.Authenticated)
            {
                await DisplayAlert("Fingeravtrykk er ikke godkjent", "Døren er låst ", "Lukk");
            }


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var state = ble.State;

            if (state == BluetoothState.Off)
            {
                await DisplayAlert("Bluetooth status ", "Bluetooth is off", "OK!");
            }
            if (state == BluetoothState.On)
            {
                await DisplayAlert("Bluetooth status ", "Bluetooth is on", "OK!");
                adapter.ScanTimeout = 8000;
                adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
                await adapter.StartScanningForDevicesAsync();


                StringBuilder sb = new StringBuilder();

                foreach (IDevice device in deviceList)
                {
                    sb.Append(device.Name);
                    sb.Append(" - ");
                }

                String deviceListString = sb.ToString();

                await DisplayAlert("bluetooth list", deviceListString, "OK");

            }

        }

        const string RequestToEnableBluetooth = 1;
        if ( !bluetooth.IsEnabled){
            var intent = new Intent(
                BluetoothAdapter.ActionStateChanged
            )
        
    }
}