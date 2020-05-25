using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;

namespace IIB1_Gruppe31_Klassen
{
    [Serializable]

    public class Raum
    {
        // Deklarierung der Attribute
        private string identity;
        private string bereich;
        private double umfang;
        private double flaechen;
        private double miete;
        private bool vermieten;
        private string besitzer;
        private string mieter;
        private string name;
        private int anzahlArbeitsplaetze;
        private int anzahlSitzplaetze;
        private int anzahlAutomaten;
        private BindingList<Mobiliar> mobiliars = new BindingList<Mobiliar>();

        public Raum(string identity, string name, double flaeche)
        {
            this.Identity = identity;
            this.Name = name;
            this.Flaechen = flaeche;
        }
        public Raum()
        {
        }

        public Raum(string name, double flaechen)
        {
            this.Name = name;
            this.Flaechen = flaechen;
        }
    
        public Raum(Raum raum)
        {
            this.identity = raum.identity;
            this.bereich = raum.bereich;
            this.umfang = raum.umfang;
            this.flaechen = raum.flaechen;
            this.miete = raum.miete;
            this.vermieten = raum.vermieten;
            this.besitzer = raum.besitzer;
            this.mieter = raum.mieter;
            this.name = raum.name;
            this.anzahlArbeitsplaetze = raum.anzahlArbeitsplaetze;
            this.anzahlSitzplaetze = raum.anzahlSitzplaetze;
            this.anzahlAutomaten = raum.anzahlAutomaten;
            this.mobiliars = raum.mobiliars;
        }
        
        //Schutz der Daten
        public string Identity { get => identity; set => identity = value; }
        public double Umfang { get => umfang; set => umfang = value; }
        public double Flaechen { get => flaechen; set => flaechen = value; }
        public string Bereich { get => bereich; set => bereich = value; }
        public double Miete { get => miete; set => miete = value; }
        public bool Vermieten { get => vermieten; set => vermieten = value; }
        public BindingList<Mobiliar> Mobiliars { get => mobiliars; set => mobiliars = value; }
        public string Besitzer { get => besitzer; set => besitzer = value; }
        public string Mieter { get => mieter; set => mieter = value; }
        public string Name { get => name; set => name = value; }
        public int AnzahlArbeitsplaetze { get => anzahlArbeitsplaetze; set => anzahlArbeitsplaetze = value; }
        public int AnzahlSitzplaetze { get => anzahlSitzplaetze; set => anzahlSitzplaetze = value; }
        public int AnzahlAutomaten { get => anzahlAutomaten; set => anzahlAutomaten = value; }
    }

    
}
