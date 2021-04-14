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
    public partial class WijzigFilament : ContentPage
    {
        private Filament filament;
        public WijzigFilament(Filament filament)
        {
            InitializeComponent();
            this.filament = filament;
            VulGegevensIn();
        }

        private void VulGegevensIn()
        {
            Type.Text = filament.Type;
            Kleur.Text = filament.Kleur;
            AantalKg.Text = filament.AantalKg.ToString();
            KostPerRol.Text = filament.KostPerRol.ToString();
        }
        private void ButtonWijzigFilament_Clicked(object sender, EventArgs e)
        {
            filament.Type = Type.Text.ToUpper();
            filament.Kleur = Kleur.Text;
            var aantalKgDecimal = decimal.Parse(AantalKg.Text);
            filament.AantalKg = aantalKgDecimal;
            var kostPerRolDecimal = decimal.Parse(KostPerRol.Text);
            filament.KostPerRol = kostPerRolDecimal;
            Task.Run(async () =>
            {
                try
                {
                    FilamentItemDatabase database = await FilamentItemDatabase.Instance;
                    await database.SaveItemAsync(filament);
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            });
        }
    }
}