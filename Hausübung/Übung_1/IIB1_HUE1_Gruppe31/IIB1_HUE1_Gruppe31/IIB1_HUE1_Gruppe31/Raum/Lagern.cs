using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_HUE1_Gruppe31
{
    [Serializable]
    public class Lagern : Raum
    {
        // Deklarierung der Attribute
        private int anzahlAutomaten;

        public override string getName()
        {
            this.Name = "Lagern" + " " + Kennzeichen.ToString();
            return this.Name;
        }

        public static List<Lagern> laden(string dateipfad)
        {
            List<Lagern> DeserRaum = new List<Lagern>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Lagern>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Lagern> l)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, l);
            fs.Close();
        }

        //Schutz der Daten
        public int AnzahlAutomaten { get => anzahlAutomaten; set => anzahlAutomaten = value; }
    }
}
