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
    public class Schrank : Mobiliar
    {
        public override string getName()
        {
            this.Name = "Schrank" + Kennzeichen.ToString();
            return this.Name;
        }

        public static List<Schrank> laden(string dateipfad)
        {
            List<Schrank> DeserRaum = new List<Schrank>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Schrank>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Schrank> s)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, s);
            fs.Close();
        }

    }
}

