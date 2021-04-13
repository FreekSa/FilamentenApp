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
            MaakInputLeeg();
        }

        public void MaakInputLeeg()
        {
            Type.Text = "";
            Kleur.Text = "";
            AantalKg.Text = "";
            KostPerRol.Text = "";
        }

        private void ButtonVoegFilamentToe_Clicked(object sender, EventArgs e)
        {
            Filament filament = new Filament();
            filament.Type = Type.Text;
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