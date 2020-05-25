using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IIB1_HUE1_Gruppe31
{
    public class Ruheraum : Raum
    {
        //Deklarierung der Attribute
        private int anzahlSitzplaetze;
        private int anzahlAutomaten;
        private string name;

        public override string getName()
        {
            this.name = "Ruheraum" + " " + Kennzeichen.ToString();
            return this.name;
        }

        public static List<Ruheraum> laden(string dateipfad)
        {
            List<Ruheraum> DeserRaum = new List<Ruheraum>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Ruheraum>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Ruheraum> r)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, r);
            fs.Close();
        }

        //Schutz der Daten
        public int AnzahlSitzplaetze { get => anzahlSitzplaetze; set => anzahlSitzplaetze = value; }
        public int AnzahlAutomaten { get => anzahlAutomaten; set => anzahlAutomaten = value; }
    }
}

