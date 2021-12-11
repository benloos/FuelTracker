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
    public class RefuelViewModel : BaseViewModel
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
        public RefuelViewModel()
        {
            GoBackCommand = new AsyncCommand(GoBack);
        }

        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}