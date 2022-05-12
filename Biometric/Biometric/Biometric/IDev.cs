using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Biometric
{
    public interface IDev
    {
        public string GetIdentifier();
    }
}
