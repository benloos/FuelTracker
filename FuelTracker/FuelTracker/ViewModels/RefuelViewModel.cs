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
        public AsyncCommand GoBackCommand { get; }
        public RefuelViewModel()
        {
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

            CurrentCar = (await CarServices.GetCar(int.Parse(CarId)));

            Title = CurrentCar.Name;

            IsBusy = false;
        }
    }
}