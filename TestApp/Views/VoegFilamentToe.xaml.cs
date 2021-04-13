using Filamentenlijst.Data;
using Filamentenlijst.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Filamentenlijst.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoegFilamentToe : ContentPage
    {
        public VoegFilamentToe()
        {
            InitializeComponent();
        }

        public void Filament()
        {
            Filament filament1 = new Filament();
            filament1.Type = "PLA";
            filament1.AantalKg = 1;
            filament1.Kleur = "Geel";
            Task.Run(async () =>
            {
                try
                {
                    FilamentItemDatabase database = await FilamentItemDatabase.Instance;
                    await database.SaveItemAsync(filament1);
                    Dispatcher.BeginInvokeOnMainThread(OnAppearing);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            });
        }
    }
}