using FuelTracker.Models;
using FuelTracker.Services;
using FuelTracker.Views;
using FuelTracker.Resources;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelTracker.ViewModels
{
    [QueryProperty(nameof(CarId), "SelectedId")]
    public class RefuelViewModel : BaseViewModel
    {
        public string carId;
        public string CarId
        {
            get => carId; set
            {
                SetProperty(ref carId, value);
                _ = Refresh();
            }
        }
        public Car currentCar;
        public Car CurrentCar { get => currentCar; set => SetProperty(ref currentCar, value); }
        string levelLabel;
        int fuelLevel;
        public int FuelLevel { get => fuelLevel; set => SetProperty(ref fuelLevel, value); }
        public string LevelLabel { get => levelLabel; }
        public AsyncCommand SaveCommand { get; }
        public AsyncCommand GoBackCommand { get; }
        public RefuelViewModel()
        {
            levelLabel = AppResources.FuelLevel + " (%):";

            SaveCommand = new AsyncCommand(Save);
            GoBackCommand = new AsyncCommand(GoBack);
        }

        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        async Task Refresh()
        {
            IsBusy = true;

            //await Task.Delay(500);

            CurrentCar = await CarServices.GetCar(int.Parse(CarId));

            Title = CurrentCar.Name;

            IsBusy = false;
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(fuelLevel.ToString())
                || fuelLevel < 0
                || fuelLevel > 100)
            {
                return;
            }

            CurrentCar.FuelLevel = FuelLevel;

            await CarServices.UpdateCar(CurrentCar);

            await Shell.Current.GoToAsync("..");
        }

    }
}