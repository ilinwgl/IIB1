using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_HUE1_AUF1
{
    public class Beleuchtung
    {
        private string name;
        private double lichtstrom;
        private double preis;
        private int raumkennzeichen;

        public string Name { get => name; set => name = value; }
        public double Lichtstrom { get => lichtstrom ; set => lichtstrom  = value; }
        public double Preis { get => preis; set => preis = value; }
        public int Raumkennzeichen { get => raumkennzeichen; set => raumkennzeichen = value; }
    }

}
