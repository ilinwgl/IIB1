using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IIB1_Gruppe31_Klassen
{
    [Serializable]

    public class Mobiliar
    {

        // Deklarierung der Attribute
        private string identity;
        private string raumkennzeichen;
        private string mitName;
        private string zustand;
        private string name;
        private double length;
        private double breit;
        private double hoehe;
        private string material;
        private double wert;

        public override string ToString()
        {
            return name;
        }

        public Mobiliar()
        { }

        public Mobiliar(Mobiliar mobiliar)
        {
            this.raumkennzeichen = mobiliar.raumkennzeichen;
            this.mitName = mobiliar.mitName;
            this.zustand = mobiliar.zustand;
            this.name = mobiliar.name;
            this.length = mobiliar.length;
            this.breit = mobiliar.breit;
            this.hoehe = mobiliar.hoehe;
            this.material = mobiliar.material;
            this.wert = mobiliar.wert;
        }
        //Schutz der Daten
        public string Identity { get => identity; set => identity = value; } 
        public string Raumkennzeichen { get => raumkennzeichen; set => raumkennzeichen = value; }
        public string MitName { get => mitName; set => mitName = value; }
        public string Zustand { get => zustand; set => zustand = value; }
        public string Name { get => name; set => name = value; }
        public double Length { get => length; set => length = value; }
        public double Breit { get => breit; set => breit = value; }
        public double Hoehe { get => hoehe; set => hoehe = value; }
        public string Material { get => material; set => material = value; }
        public double Wert { get => wert; set => wert = value; }
    }
}
