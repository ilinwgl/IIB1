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
    public class Besitzer
    {
        // Deklarierung der Attribute
        private int kennzeichen;
        private string raumkennzeichen;
        private string name;
        private string vorname;
        private string nachname;
        private string email;
        private string mobilphone;
        private string addresse;
        private List<Raum> besitzerRaum = new List<Raum>();

        public string getName()
        {
            this.name = kennzeichen.ToString() + "." + vorname + " " + nachname;
            return this.name;
        }

        public override string ToString()
        {
            return getName();
        }

        public static List<Besitzer> laden(string dateipfad)
        {
            List<Besitzer> DeserBesitzer = new List<Besitzer>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserBesitzer = ((List<Besitzer>)bf.Deserialize(fs));
            fs.Close();
            return DeserBesitzer;
        }

        public void speichern(string dateipfad, List<Besitzer> b)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, b);
            fs.Close();
        }

        //Schutz der Daten
        public int Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public string Raumkennzeichen { get => raumkennzeichen; set => raumkennzeichen = value; }
        public string Name { get => name; set => name = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public string Email { get => email; set => email = value; }
        public string Mobilphone { get => mobilphone; set => mobilphone = value; }
        public string Addresse { get => addresse; set => addresse = value; }
        public List<Raum> BesitzerRaum { get => besitzerRaum; set => besitzerRaum = value; }
    }
}
