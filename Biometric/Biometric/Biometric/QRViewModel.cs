
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Biometric
{
    public class QRViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _myPropy;
        public string myPropy
        {
            get { return _myPropy; }
            set { _myPropy = value; OnPropertyChanged(nameof(myPropy)); }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public QRViewModel()
        { 
           var devInfo = DependencyService.Get<IDev>();
           var nie = devInfo.GetIdentifier();
           myPropy = nie;
        }
    }
}
