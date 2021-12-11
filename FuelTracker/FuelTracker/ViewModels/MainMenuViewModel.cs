using FuelTracker.Models;
using FuelTracker.Services;
using FuelTracker.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelTracker.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Car> Cars { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Car> DeleteCommand { get; }
        public AsyncCommand<object> SelectCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand SettingsCommand { get; }

        public MainMenuViewModel()
        {
            Title = "Fuel Tracker";

            Cars = new ObservableRangeCollection<Car> { };

            _ = Refresh();

            RefreshCommand = new AsyncCommand(Refresh);
            DeleteCommand = new AsyncCommand<Car>(Delete);
            AddCommand = new AsyncCommand(Add);
            SettingsCommand = new AsyncCommand(Settings);
            SelectCommand = new AsyncCommand<object>(Select);
        }

        Car selectedCar;
        public Car SelectedCar
        {
            get => selectedCar;
            set => SetProperty(ref selectedCar, value);
        }
        async Task Select(object args)
        {
            var car = SelectedCar;
            if (car == null)
                return;

            SelectedCar = null;

            await Shell.Current.GoToAsync($"{nameof(CarMenuPage)}?SelectedId={car.Id}");
        }

        async Task Add()
        {
            await Shell.Current.GoToAsync($"{nameof(AddCarPage)}");
        }

        async Task Settings()
        {
            await Shell.Current.GoToAsync($"{nameof(SettingsPage)}");
        }

        async Task Delete(Car car)
        {
            await CarServices.RemoveCar(car.Id);

            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;

            //await Task.Delay(500);

            var cars = await CarServices.GetCar();

            Cars.Clear();

            Cars.AddRange(cars);

            IsBusy = false;
        }

    }
}
