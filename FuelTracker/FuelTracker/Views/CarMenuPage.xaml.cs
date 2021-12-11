using FuelTracker.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarMenuPage : ContentPage
    {
        public CarMenuPage()
        {
            InitializeComponent();

            Shell.SetNavBarIsVisible(this, false);
        }
    }
}