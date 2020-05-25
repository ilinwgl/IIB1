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
    public class Flur : Raum
    {
        // Deklarierung der Attribute
        private int anzahlAutomaten;

        public override string getName()
        {
            this.Name = "Flur" + " " + Kennzeichen.ToString();
            return this.Name;
        }

        public static List<Flur> laden(string dateipfad)
        {
            List<Flur> DeserRaum = new List<Flur>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Flur>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Flur> f)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, f);
            fs.Close();
        }

        //Schutz der Daten
        public int AnzahlAutomaten { get => anzahlAutomaten; set => anzahlAutomaten = value; }
    }
}
