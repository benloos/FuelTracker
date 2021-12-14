using FuelTracker.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelTracker.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {

        string name, mileageLabel, capacityLabel;
        int fuelLevel, tankCapacity, mileage;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public int FuelLevel { get => fuelLevel; set => SetProperty(ref fuelLevel, value); }
        public int TankCapacity { get => tankCapacity; set => SetProperty(ref tankCapacity, value); }
        public int Mileage { get => mileage; set => SetProperty(ref mileage, value); }
        public string MileageLabel { get => mileageLabel; set => SetProperty(ref mileageLabel, "Mileage (" + value + "):"); }
        public string CapacityLabel { get => capacityLabel; set => SetProperty(ref capacityLabel, "Tank Capacity (" + value + "):"); }
        public AsyncCommand SaveCommand { get; }
        public AsyncCommand GoBackCommand { get; }

        public AddCarViewModel()
        {
            Title = "Add Car";

            MileageLabel = App.GlobalUnitDistance;
            CapacityLabel = App.GlobalUnitVolume;

            SaveCommand = new AsyncCommand(Save);
            GoBackCommand = new AsyncCommand(GoBack);
        }

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(fuelLevel.ToString())
                || string.IsNullOrWhiteSpace(mileage.ToString())
                || fuelLevel < 0
                || fuelLevel > 100)
            {
                return;
            }

            await CarServices.AddCar(name, fuelLevel, tankCapacity, mileage);

            await Shell.Current.GoToAsync("..");
        }

        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}