using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biometric
{
    public partial class QR : ContentPage
    {
        public QR()
        {
            InitializeComponent();
           QRViewModel obj = new QRViewModel();       
            this.BindingContext = obj;

        }
    }
}
