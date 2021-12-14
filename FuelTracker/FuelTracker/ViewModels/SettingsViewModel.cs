using FuelTracker.Helpers;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelTracker.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public string[] UnitsDistance { get => App.unitsDistance; }
        public int SelectedDistance { get => App.selectedDistance; set => SetProperty(ref App.selectedDistance, value); }
        public AsyncCommand<int> DistanceCommand { get; }

        public string[] UnitsCurrency { get => App.unitsCurrency; }
        public int SelectedCurrency { get => App.selectedCurrency; set => SetProperty(ref App.selectedCurrency, value); }
        public AsyncCommand<int> CurrencyCommand { get; }

        public string[] UnitsVolume { get => App.unitsVolume; }
        public int SelectedVolume { get => App.selectedVolume; set => SetProperty(ref App.selectedVolume, value); }
        public AsyncCommand<int> VolumeCommand { get; }

        public int Width { get => App.GlobalUnitWidth; set => SetProperty(ref App.GlobalUnitWidth, value); }

        public AsyncCommand GoBackCommand { get; }
        public AsyncCommand<string> ThemeCommand { get; }
        
        public SettingsViewModel()
        {
            Title = "Settings";

            GoBackCommand = new AsyncCommand(GoBack);
            ThemeCommand = new AsyncCommand<string>(Theme);
            DistanceCommand = new AsyncCommand<int>(Distance);
            CurrencyCommand = new AsyncCommand<int>(Currency);
            VolumeCommand = new AsyncCommand<int>(Volume);
        }
        
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        async Task Theme(string value)
        {
            int theme = int.Parse(value);
            Settings.Theme = theme;
            TheTheme.SetTheme();
        }

        async Task Distance(int value)
        {
            App.selectedDistance = value;
        }

        async Task Currency(int value)
        {
            App.selectedCurrency = value;
        }

        async Task Volume(int value)
        {
            App.selectedVolume = value;
        }
    }
}