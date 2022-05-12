using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BluetoothClassic.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;





namespace Biometric
{
    public partial class TransiverPage : ContentPage
    {
        public TransiverPage()
        {
            InitializeComponent();
        }

        private async void btnTrnsmit_clicked(object sender, EventArgs e)
        {
            const int BufferSize = 1;
            const int offsetDefault = 0;
            var device = (BluetoothDeviceModel)BindingContext;
            if (device != null)
            {
                var adapter = DependencyService.Resolve<IBluetoothAdapter>();
                using (var connection = adapter.CreateConnection(device))
                {
                    if(await connection.RetryConnectAsync(retriesCount:2))
                    {
                        byte[] buffer = new byte[BufferSize] { (byte)stepperDigit.Value };
                        if(!await connection.RetryTransmitAsync(buffer, offsetDefault,buffer.Length))

                        {
                            await DisplayAlert("error", "can not send data", "close");

                        }

                      
                    }
                    else
                    {
                        await DisplayAlert("error", "can not connect", "close");
                    }
                }
            }
        }

        private async void btnRecieve_clicked(object sender,EventArgs e)
        {
            const int BufferSize = 1;
            const int offsetDefault = 0;
            var device = (BluetoothDeviceModel)BindingContext;
            if (device != null)
            {
                var adapter = DependencyService.Resolve<IBluetoothAdapter>();
                using (var connection = adapter.CreateConnection(device))
                {
                    if (await connection.RetryConnectAsync(retriesCount: 2))
                    {
                        byte[] buffer = new byte[BufferSize];
                        if (!(await connection.RetryReciveAsync(buffer, offsetDefault, buffer.Length)).Succeeded)

                        {
                            await DisplayAlert("error", "can not recieve data", "close");

                        }

                        else
                        {
                            stepperDigit.Value = buffer.FirstOrDefault();
                        }
                    }
                    else
                    {
                        await DisplayAlert("error", "can not connect", "close");
                    }
                }
            }
        }


    }
}
