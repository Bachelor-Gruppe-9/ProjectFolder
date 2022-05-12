using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.BluetoothClassic.Abstractions;

namespace Biometric
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class SelectDevicePage : ContentPage
    {
        private object lvBondedDevices;

        public SelectDevicePage()
        {
            InitializeComponent();
            FillBondedDevices();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void FillBondedDevices()
        {
            var adapter = DependencyService.Resolve<IBluetoothAdapter>();
            lvBondedDevices.ItemsSource = adapter.BondedDevices;

        }
        private async void lvBondedDevices_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var device = (BluetoothDeviceModel)e.SelectedItem;
            if (device != null)
            {
                await Navigation.PushAsync(new TransiverPage { BindingContext = device });
            }
        }

        lvBondedDevices.SelectedItem=null;


    }
}
