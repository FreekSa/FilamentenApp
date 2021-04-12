using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filamentenlijst.Models
{
    public class Filament
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Kleur { get; set; }
        public decimal KostPerRol { get; set; }
        private decimal aantalKg;
        public decimal AantalKg { get => aantalKg; set { aantalKg = value; AantalMeter = aantalKg * 330m; } }

        public decimal AantalMeter { get; private set; }
    }
}
