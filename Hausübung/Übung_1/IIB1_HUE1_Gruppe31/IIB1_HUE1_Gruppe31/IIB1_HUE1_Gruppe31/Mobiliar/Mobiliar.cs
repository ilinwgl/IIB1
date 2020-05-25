using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IIB1_HUE1_Gruppe31
{
    [Serializable]
    public class Mobiliar
    {
        // Deklarierung der Attribute
        private int kennzeichen;
        private string raumkennzeichen;
        private int mitkennzeichen;
        private string zustand;
        private string name;
        private double length;
        private double breit;
        private double hoehe;
        private double flaechen;
        private string material;
        private double wert;
        private double gesamtPreis;

        //bekommen der Flächen
        public double getFlaechen(double a, double b)
        {
            flaechen = a * b;
            return flaechen;
        }

        //bekommen den Name
        public virtual string getName()
        {
            return this.name;
        }

        public override string ToString()
        {
            return getName();
        }

        //Schutz der Daten
        public int Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public string Raumkennzeichen { get => raumkennzeichen; set => raumkennzeichen = value; }
        public int Mitkennzeichen { get => mitkennzeichen; set => mitkennzeichen = value; }
        public string Zustand { get => zustand; set => zustand = value; }
        public string Name { get => name; set => name = value; }
        public double Length { get => length; set => length = value; }
        public double Breit { get => breit; set => breit = value; }
        public double Hoehe { get => hoehe; set => hoehe = value; }
        public double Flaechen { get => flaechen; set => flaechen = value; }
        public string Material { get => material; set => material = value; }
        public double Wert { get => wert; set => wert = value; }
        public double GesamtPreis { get => gesamtPreis; set => gesamtPreis = value; }
    }
}
