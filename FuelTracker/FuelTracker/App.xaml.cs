using FuelTracker.Helpers;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FuelTracker
{
    public partial class App : Application
    {
        public static string[] unitsDistance = { "km", "mi", "bananas" };
        public static int selectedDistance = 0;
        public static string GlobalUnitDistance { get => unitsDistance[selectedDistance]; }

        public static string[] unitsCurrency = { "€", "$", "£" };
        public static int selectedCurrency = 0;
        public static string GlobalUnitCurrency { get => unitsCurrency[selectedCurrency]; }

        public static string[] unitsVolume = { "L", "gal" };
        public static int selectedVolume = 0;
        public static string GlobalUnitVolume { get => unitsVolume[selectedVolume]; }

        public static int GlobalUnitWidth;
        public App()
        {
            InitializeComponent();

            TheTheme.SetTheme();

            GlobalUnitWidth = 333;

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }
    }
}
