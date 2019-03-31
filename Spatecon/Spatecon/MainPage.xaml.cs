using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Plugin.Media;
using Xamarin.Forms;

namespace Spatecon
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        public class Bank
        {
            public string number { get; set; }
            public string symbol { get; set; }
            public Color color { get; set; }
        }

        public string NEtext { set { NE.Text = value; } }
        List<Bank> banks = new List<Bank>() { new Bank(){number = "5211 78", color = Color.FromHex("#ec0f1c"), symbol = "Alfabank"},
            new Bank() { number = "5486 73", color = Color.FromHex("#ec0f1c"), symbol = "alfabank" },
            new Bank() { number = "5486 01", color = Color.FromHex("#ec0f1c"), symbol = "alfabank" },
            new Bank() { number = "4584 1", color = Color.FromHex("#ec0f1c"), symbol = "alfabank" },
            new Bank() { number = "4154 28", color = Color.FromHex("#ec0f1c"), symbol = "alfabank" },
            new Bank() { number = "6763 71", color = Color.FromHex("#ec0f1c"), symbol = "alfabank" },
            new Bank() { number = "4779 64", color = Color.FromHex("#ec0f1c"), symbol = "alfabank" },
            new Bank() { number = "5489 99", color = Color.FromHex("#35426e"), symbol = "gasprom" },
            new Bank() { number = "5264 83", color = Color.FromHex("#35426e"), symbol = "gasprom" },
            new Bank() { number = "5364 09", color = Color.FromHex("#4b734e"), symbol = "rosselhoz" },
            new Bank() { number = "4890 9", color = Color.FromHex("#212123"), symbol = "unicredit" },
            new Bank() { number = "5313 44", color = Color.FromHex("#212123"), symbol = "unicredit" },
            new Bank() { number = "4908 55", color = Color.FromHex("#212123"), symbol = "unicredit" },
            new Bank() { number = "5136 91", color = Color.FromHex("#554c3b"), symbol = "russtandart" },
            new Bank() { number = "5100 9", color = Color.FromHex("#554c3b"), symbol = "russtandart" },
            new Bank() { number = "5100 47", color = Color.FromHex("#554c3b"), symbol = "russtandart" },
            new Bank() { number = "4276 83", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "6390 0", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "6775 8", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "4279 01", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "5469 3", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "4276 44", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "4276 01", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "4276 40", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "4279 01", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "4276 31", color = Color.FromHex("#258f24"), symbol = "sberbank" },
            new Bank() { number = "4272 29", color = Color.FromHex("#0d1d62"), symbol = "vtb" },
            new Bank() { number = "4622 3", color = Color.FromHex("#0d1d62"), symbol = "vtb" },
            new Bank() { number = "5278 83", color = Color.FromHex("#0d1d62"), symbol = "vtb" },
            new Bank() { number = "4475 20", color = Color.FromHex("#0d1d62"), symbol = "vtb" },
            new Bank() { number = "5257 44", color = Color.FromHex("#9a3242"), symbol = "mdm" },
            new Bank() { number = "5543 73", color = Color.FromHex("#9a3242"), symbol = "mdm" },
            new Bank() { number = "4652 03", color = Color.FromHex("#9a3242"), symbol = "mdm" },
            new Bank() { number = "4167 92", color = Color.FromHex("#9a3242"), symbol = "mdm" },
            new Bank() { number = "4652 04", color = Color.FromHex("#9a3242"), symbol = "mdm" },
            new Bank() { number = "5482 65", color = Color.FromHex("#9a3242"), symbol = "mdm" },
            new Bank() { number = "4029 11", color = Color.FromHex("#43172"), symbol = "novikombank" },
            new Bank() { number = "4024 57", color = Color.FromHex("#43172"), symbol = "novikombank" },
            new Bank() { number = "4469 58", color = Color.FromHex("#83715"), symbol = "vneshprombank" },
            new Bank() { number = "4469 55", color = Color.FromHex("#83715"), symbol = "vneshprombank" },
            new Bank() { number = "5337 36", color = Color.FromHex("#d90910"), symbol = "mtsbank" },
            new Bank() { number = "5406 16", color = Color.FromHex("#d90910"), symbol = "mtsbank" },
            new Bank() { number = "5213 24", color = Color.FromHex("#231920"), symbol = "tinkoff" },
            new Bank() { number = "4377 73", color = Color.FromHex("#231920"), symbol = "tinkoff" },
            new Bank() { number = "4059 92", color = Color.FromHex("#a60040"), symbol = "letobank" },
            new Bank() { number = "5440 58", color = Color.FromHex("#93749"), symbol = "expobank" },
            new Bank() { number = "4850 78", color = Color.FromHex("#222222"), symbol = "rocketbank" },
            new Bank() { number = "4341 46", color = Color.FromHex("#532301"), symbol = "otkritie" },
            new Bank() { number = "4058 70", color = Color.FromHex("#532301"), symbol = "otkritie" },
            new Bank() { number = "5445 73", color = Color.FromHex("#532301"), symbol = "otkritie" },
            new Bank() { number = "5323 01", color = Color.FromHex("#532301"), symbol = "otkritie" }
            };
        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text == "")
            {
                return;
            }
            if (text.Length == 23)
            {

                    DateEntry1.Focus();

            }
            if ((text.Length >= 5) && (text.Length <= 9))
            {
                foreach (Bank bank in banks)
                {
                    if (bank.number == text)
                    {
                        CF.BackgroundColor = bank.color;
                        MI.Source = bank.symbol + ".png";
                    }
                }
            }
            else
            {
                CF.BackgroundColor = Color.FromHex("#f0f0f0");
                MI.Source = "";
            }
        }
        string DateEntry1Text;
        void Handle_TextChanged_1(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text == "")
            {
                return;
            }
            if (Convert.ToInt32(text) > 12)
            {
                DateEntry1.Text = DateEntry1Text;
            }
            if (text.Length == 2)
            {
                DateEntry2.Focus();
            }
            DateEntry1Text = text;
        }
        string DateEntry2Text;
        void Handle_TextChanged_2(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string text = ((Entry)sender).Text;
            if (text == "")
            {
                return;
            }
            if (Convert.ToInt32(text) > DateTime.Now.Year)
            {
                DateEntry2.Text = DateEntry2Text;
            }
            if (text.Length == 2)
            {
                PasEntry.Focus();
            }
            DateEntry2Text = text;
        }

        public void Except()
        {
            ExLabel.Text = "Номер карты введён неверно";
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            App.tap();
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            this.Content = new StackLayout();
        //    this.Content = new Label { Text = "Вход выполнен успешно", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center}
        }

        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            SG.IsVisible = true;
        }

        void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            SG.IsVisible = false;
        }



    }
}
