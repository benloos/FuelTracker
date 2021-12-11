using FuelTracker.Views;
using Xamarin.Forms;

namespace FuelTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddCarPage), typeof(AddCarPage));

            Routing.RegisterRoute(nameof(CarMenuPage), typeof(CarMenuPage));

            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));

            Routing.RegisterRoute(nameof(RefuelPage), typeof(RefuelPage));

            Routing.RegisterRoute(nameof(StatisticsPage), typeof(StatisticsPage));
        }

    }
}
