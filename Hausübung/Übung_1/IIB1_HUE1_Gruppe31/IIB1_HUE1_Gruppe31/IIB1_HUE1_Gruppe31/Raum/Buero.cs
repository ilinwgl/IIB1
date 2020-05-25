using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IIB1_HUE1_Gruppe31
{
    [Serializable]
    public class Buero : Raum
    {
        //Deklarierung der Attribute
        private int anzahlArbeitsplaetze;
        private int anzahlSitzplaetze;
        private int anzahlAutomaten;

        public override string getName()
        {
            this.Name = "Büro" + " " + Kennzeichen.ToString();
            return this.Name;
        }

        public static List<Buero> laden(string dateipfad)
        {
            List<Buero> DeserRaum = new List<Buero>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Buero>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Buero> b)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, b);
            fs.Close();
        }

        //Schutz der Daten
        public int AnzahlArbeitsplaetze { get => anzahlArbeitsplaetze; set => anzahlArbeitsplaetze = value; }
        public int AnzahlSitzplaetze { get => anzahlSitzplaetze; set => anzahlSitzplaetze = value; }
        public int AnzahlAutomaten { get => anzahlAutomaten; set => anzahlAutomaten = value; }
    }
}
