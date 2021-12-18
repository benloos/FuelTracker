using FuelTracker.Services;
using FuelTracker.Resources;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelTracker.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {

        string name, mileageLabel, capacityLabel, levelLabel, nameLabel;
        int fuelLevel, tankCapacity, mileage;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public int FuelLevel { get => fuelLevel; set => SetProperty(ref fuelLevel, value); }
        public int TankCapacity { get => tankCapacity; set => SetProperty(ref tankCapacity, value); }
        public int Mileage { get => mileage; set => SetProperty(ref mileage, value); }
        public string NameLabel { get => nameLabel; }
        public string MileageLabel { get => mileageLabel; }
        public string CapacityLabel { get => capacityLabel; }
        public string LevelLabel { get => levelLabel; }
        public AsyncCommand SaveCommand { get; }
        public AsyncCommand GoBackCommand { get; }

        public AddCarViewModel()
        {
            nameLabel = AppResources.Name + ":";
            mileageLabel = AppResources.Mileage + " (" + App.GlobalUnitDistance + "):";
            capacityLabel = AppResources.TankCapacity + " (" + App.GlobalUnitVolume + "):";
            levelLabel = AppResources.FuelLevel + " (%):";

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