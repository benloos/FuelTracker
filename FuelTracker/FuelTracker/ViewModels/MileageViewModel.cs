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
    public class MileageViewModel : BaseViewModel
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

        int distance;
        public int Distance { get => distance; set => SetProperty(ref distance, value); }

        int radioSelected;
        public int RadioSelected { get => radioSelected; set => SetProperty(ref radioSelected, value); }

        public AsyncCommand SaveCommand { get; }
        public AsyncCommand GoBackCommand { get; }
        public AsyncCommand<string> RadioChangedCommand { get; }
        public MileageViewModel()
        {
            SaveCommand = new AsyncCommand(Save);
            GoBackCommand = new AsyncCommand(GoBack);
            RadioChangedCommand = new AsyncCommand<string>(RadioChanged);
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
            if (string.IsNullOrWhiteSpace(distance.ToString())
                || distance < 0)
            {
                return;
            }

            if (RadioSelected == 0)
            {
                currentCar.Mileage = distance;
            } 
            else if (RadioSelected == 1)
            {
                if (CurrentCar.Mileage + distance < 9999999)
                {
                    CurrentCar.Mileage += distance;
                }
            }

            await CarServices.UpdateCar(CurrentCar);

            await Shell.Current.GoToAsync("..");
        }

        async Task RadioChanged(string selected)
        {
            RadioSelected = int.Parse(selected);
        }

    }
}