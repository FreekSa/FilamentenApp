using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Filamentenlijst : ContentPage
    {
        public Filamentenlijst()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            FilamentItemDatabase database = await FilamentItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }
    }
}