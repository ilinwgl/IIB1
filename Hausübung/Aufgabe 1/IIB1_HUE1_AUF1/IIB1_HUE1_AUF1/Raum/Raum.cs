using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_HUE1_AUF1
{
    public class Raum
    {
        private int kennzeichen;
        private string name;
        private double beleutungsanforderung;
        private double flaeche;
        private double hoeche;
        private List<Beleuchtung> beleuchtungen = new List<Beleuchtung>();

        public int Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public string Name { get => name; set => name = value; }
        public double Beleuchtungsanforderung { get => beleutungsanforderung; set => beleutungsanforderung  = value; }
        public double Hoehe { get => hoeche; set => hoeche = value; }
        public List<Beleuchtung > Beleuchtungen { get => beleuchtungen; set => beleuchtungen = value; }
    }
}
