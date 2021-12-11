using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuelTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCarPage : ContentPage
    {
        public AddCarPage()
        {
            InitializeComponent();

            Shell.SetNavBarIsVisible(this, false);
        }
    }
}