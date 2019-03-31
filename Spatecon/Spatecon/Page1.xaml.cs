using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spatecon
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            App.Current.MainPage = App.main;
        }
    }
}
