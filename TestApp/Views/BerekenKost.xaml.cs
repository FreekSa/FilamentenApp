using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Filamentenlijst.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BerekenKost : ContentPage
    {
        public BerekenKost()
        {
            InitializeComponent();
            MaakVeldenLeeg();
        }

        public void MaakVeldenLeeg()
        {
            KostPerRol.Text = "";
            AantalMeter.Text = "";
            Duurtijd.Text = "";
        }

        public void BerekenKost_Clicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                decimal kostPerRolDecimal = decimal.Parse(KostPerRol.Text.ToString());
                decimal aantalMeterDecimal = decimal.Parse(AantalMeter.Text.ToString());
                decimal duurtijdInMinutenDecimal = decimal.Parse(Duurtijd.Text.ToString());
                decimal kost = (kostPerRolDecimal / 330) * aantalMeterDecimal + (0.0534m * (duurtijdInMinutenDecimal / 60));
                Kost.Text = $"Kost: € " + Decimal.Round(kost, 2);
                MaakVeldenLeeg();
            });
        }
    }
}

