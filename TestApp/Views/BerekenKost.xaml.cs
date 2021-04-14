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
        }

        public void BerekenKost_Clicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                decimal kostPerRolDecimal = decimal.Parse(KostPerRol.Text.ToString());
                decimal aantalMeterDecimal = decimal.Parse(AantalMeter.Text.ToString());
                decimal duurtijdInMinutenDecimal = decimal.Parse(Duurtijd.Text.ToString());
                Kost.Text = (kostPerRolDecimal / 330) * aantalMeterDecimal + (0.0534m * (duurtijdInMinutenDecimal / 60)).ToString();
            });
        }
    }
}

