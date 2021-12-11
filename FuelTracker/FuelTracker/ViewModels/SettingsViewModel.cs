using FuelTracker.Helpers;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FuelTracker.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public AsyncCommand GoBackCommand { get; }
        public AsyncCommand<string> ThemeCommand { get; }
        public SettingsViewModel()
        {
            Title = "Settings";

            GoBackCommand = new AsyncCommand(GoBack);
            ThemeCommand = new AsyncCommand<string>(Theme);
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

    }
}