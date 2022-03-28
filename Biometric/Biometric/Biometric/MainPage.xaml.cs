using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;


namespace Biometric
{
    public partial class MainPage : ContentPage
    {
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
        
    }
}