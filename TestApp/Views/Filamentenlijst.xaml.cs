using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filamentenlijst.Data;
using Filamentenlijst.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Filamentenlijst.Views
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

        private async void ButtonToevoegen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VoegFilamentToe());
        }

        private void ButtonVerwijderen_Clicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                try
                {
                    FilamentItemDatabase database = await FilamentItemDatabase.Instance;
                    Button b = sender as Button;
                    var filament = await database.GetItemAsync(Convert.ToInt32(b.CommandParameter.ToString()));
                    await database.DeleteItemAsync(filament);
                    Dispatcher.BeginInvokeOnMainThread(OnAppearing);
                }

                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
