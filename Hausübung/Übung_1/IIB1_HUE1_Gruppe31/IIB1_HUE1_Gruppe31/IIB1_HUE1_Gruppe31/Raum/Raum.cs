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
    public class Raum
    {
        // Deklarierung der Attribute
        private int kennzeichen;
        private string bereich;
        private double length;
        private double breit;
        private double flaechen;
        private int floor;
        private double miete;
        private bool vermieten;
        private string besitzer;
        private string mieter;
        private string name;
        private List<String> raumMobiliar = new List<String>();
        

        //bekommen den Name
        public virtual string getName()
        {
            return this.name;
        }


        public override string ToString()
        {
            return getName();
        }

        //Bekommen die Fläche des Raums
        public double getFlaeche(double a, double b)
        {
            flaechen = a * b;
            return flaechen;
        }

        //Schutz der Daten
        public int Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public double Length { get => length; set => length = value; }
        public double Breit { get => breit; set => breit = value; }
        public double Flaechen { get => flaechen; set => flaechen = value; }
        public int Floor { get => floor; set => floor = value; }
        public string Bereich { get => bereich; set => bereich = value; }
        public double Miete { get => miete; set => miete = value; }
        public bool Vermieten { get => vermieten; set => vermieten = value; }
        public List<String> RaumMobiliar { get => raumMobiliar; set => raumMobiliar = value; }
        public string Besitzer { get => besitzer; set => besitzer = value; }
        public string Mieter { get => mieter; set => mieter = value; }
        public string Name { get => name; set => name = value; }

        
    }

    
}
