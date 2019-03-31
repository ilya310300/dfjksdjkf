using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Spatecon
{
    public partial class App : Application
    {
        public delegate void Message();
        public static MainPage main = new MainPage();
        public static Message tap;
        public string CardNumber { set { main.NEtext = value; } }
        public App()
        {
            InitializeComponent();

            MainPage = new Page1();
        }
        public App(Message Tap)
        {
            InitializeComponent();
            tap = Tap;
            MainPage = new Page1();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
