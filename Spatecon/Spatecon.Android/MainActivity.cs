using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using IO.Card.Payment;

namespace Spatecon.Droid
{
    [Activity(Label = "Spatecon", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        App app;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            app = new App(onScanPress);
            LoadApplication(app);
        }

        public void onScanPress()
        {
            CardIOActivity i = new CardIOActivity();
            Intent scanIntent = new Intent(this, i.GetType());
            scanIntent.PutExtra(CardIOActivity.ExtraRequireExpiry, false);
            scanIntent.PutExtra(CardIOActivity.ExtraRequireCvv, false);
            scanIntent.PutExtra(CardIOActivity.ExtraRequirePostalCode, false);
            this.StartActivityForResult(scanIntent, 12345);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 12345)
            {
                String resultDisplayStr;
                if (data != null && data.HasExtra(CardIOActivity.ExtraScanResult))
                {
                    CreditCard scanResult = (IO.Card.Payment.CreditCard)data.GetParcelableExtra(CardIOActivity.ExtraScanResult);

                    // Never log a raw card number. Avoid displaying it, but if necessary use getFormattedCardNumber()
                    resultDisplayStr = "Card Number: " + scanResult.CardNumber + "\n";

                    // Do something with the raw number, e.g.:
                    // myService.setCardNumber( scanResult.cardNumber );

                    if (scanResult.IsExpiryValid)
                    {
                        resultDisplayStr += "Expiration Date: " + scanResult.ExpiryMonth + "/" + scanResult.ExpiryYear + "\n";
                    }

                    if (scanResult.Cvv != null)
                    {
                        // Never log or display a CVV
                        resultDisplayStr += "CVV has " + scanResult.Cvv.Length + " digits.\n";
                    }

                    if (scanResult.PostalCode != null)
                    {
                        resultDisplayStr += "Postal Code: " + scanResult.PostalCode + "\n";
                    }
                    app.CardNumber = scanResult.CardNumber;
                }
                else
                {
                    resultDisplayStr = "Scan was canceled.";
                }
                // do something with resultDisplayStr, maybe display it in a textView
                // resultTextView.setText(resultDisplayStr);
            }
        }
    }
}