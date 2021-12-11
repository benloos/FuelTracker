using FuelTracker.Models;
using FuelTracker.Services;
using FuelTracker.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelTracker.ViewModels
{
    [QueryProperty(nameof(CarId), "SelectedId")]
    public class CarMenuViewModel : BaseViewModel
    {
        public string carId;
        public string CarId
        {
            get => carId; set
            {
                SetProperty(ref carId, value);
                Title = CarId;
                //CurrentCar = CarServices.GetCar(int.Parse(CarId)).Result;
                //Title = CurrentCar.Name;
            }
        }
        public Car currentCar;
        public Car CurrentCar { get => currentCar; set => SetProperty(ref currentCar, value); }

        public AsyncCommand GoBackCommand { get; }
        public AsyncCommand FuelCommand { get; }
        public AsyncCommand MileageCommand { get; }
        public AsyncCommand StatisticsCommand { get; }
        public CarMenuViewModel()
        {
            GoBackCommand = new AsyncCommand(GoBack);
            FuelCommand = new AsyncCommand(Fuel);
            MileageCommand = new AsyncCommand(Mileage);
            StatisticsCommand = new AsyncCommand(Statistics);
        }

        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        async Task Fuel()
        {
            await Shell.Current.GoToAsync($"{nameof(RefuelPage)}?SelectedId={CarId}");
        }

        async Task Mileage()
        {
            await Shell.Current.GoToAsync("..");
        }

        async Task Statistics()
        {
            await Shell.Current.GoToAsync($"{nameof(StatisticsPage)}?SelectedId={CarId}");
        }
    }
}