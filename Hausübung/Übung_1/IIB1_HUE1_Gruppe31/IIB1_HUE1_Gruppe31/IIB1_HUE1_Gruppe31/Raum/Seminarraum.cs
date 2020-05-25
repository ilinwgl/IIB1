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
    public class Seminarraum : Raum
    {
        // Deklarierung der Attribute
        private int anzahlArbeitsplaetze;
        private int anzahlSitzplaetze;
        private int anzahlAutomaten;

        public override string getName()
        {
            this.Name = "Seminarraum" + " " + Kennzeichen.ToString();
            return this.Name;
        }

        public static List<Seminarraum> laden(string dateipfad)
        {
            List<Seminarraum> DeserRaum = new List<Seminarraum>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Seminarraum>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Seminarraum> s)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, s);
            fs.Close();
        }

        //Schutz der Daten
        public int AnzahlArbeitsplaetze { get => anzahlArbeitsplaetze; set => anzahlArbeitsplaetze = value; }
        public int AnzahlSitzplaetze { get => anzahlSitzplaetze; set => anzahlSitzplaetze = value; }
        public int AnzahlAutomaten { get => anzahlAutomaten; set => anzahlAutomaten = value; }
    }
}
