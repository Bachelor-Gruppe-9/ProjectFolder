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
using Plugin.BLE.Abstractions.Exceptions;
using Plugin.BLE.Abstractions.Extensions;

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

        private async void Bluetooth_Connect(object sender, EventArgs e)
        {
            var state = ble.State;

            if (state == BluetoothState.Off)
            {
                await DisplayAlert("Bluetooth status ", "Bluetooth is off", "OK");
            }
            if (state == BluetoothState.On)
            {
                await DisplayAlert("Bluetooth status ", "Bluetooth is on", "OK");
                adapter.DeviceDiscovered += (s, a) => deviceList.Add(a.Device);
                adapter.DeviceConnected += (s, a) => DisplayAlert("Bluetooth status", "Device connected", "ok");
                //send signal if bluetooth gets on or of
                ble.StateChanged += (s, a) =>
                {
                    DisplayAlert("Bluetooth status", $"The bluetooth state changed to {a.NewState}", "ok");
                    // DisplayAlert("state changed to{ e.NewState}");


                };

                
                await adapter.StartScanningForDevicesAsync();


                StringBuilder sb = new StringBuilder();

                foreach (IDevice device in deviceList)
                {
                    sb.AppendLine(device.Name + ", " + device.Id);
                }

                String deviceListString = sb.ToString();

                await DisplayAlert("bluetooth list", deviceListString, "OK");
                



                IDevice connectedDevice;

                //connect to a known  device
                try
                {
                    //await adapter.ConnectToDeviceAsync(Guid.Parse("64-0B-D7-01-39-69"));

                    await adapter.ConnectToKnownDeviceAsync(Guid.Parse("00000000-0000-0000-0000-b827eb7e01fc"));
                }
                
                catch (DeviceConnectionException exception)
                {
                    await DisplayAlert("Bluetooth error", "Failed to connect to device: " + exception.Message, "ok");
                    // ... could not connect to device
                    return;
                }
                catch (Exception exception)
                {
                    await DisplayAlert("Error", exception.Message, "ok");
                    return;
                }
                //int bytes = 0;
                //var services = await connectedDevice.GetServicesAsync();
                //var characteristics = await service.GetCharacteristicsAsync();
                //await characteristic.WriteAsync(bytes);
                
            }
        }

        
    }
}