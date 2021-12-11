using FuelTracker.Helpers;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FuelTracker
{
    public partial class App : Application
    {
        public static string GlobalUnitDistance { get; set; }
        public static string GlobalUnitCurrency { get; set; }
        public static int GlobalUnitWidth { get; set; }
        public App()
        {
            InitializeComponent();

            TheTheme.SetTheme();

            GlobalUnitWidth = 333;
            GlobalUnitDistance = "km";
            GlobalUnitCurrency = "€";

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
