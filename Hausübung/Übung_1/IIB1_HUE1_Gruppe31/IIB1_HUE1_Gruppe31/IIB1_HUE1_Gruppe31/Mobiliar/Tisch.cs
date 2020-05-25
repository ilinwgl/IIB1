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
    public class Tisch : Mobiliar
    {
        public override string getName()
        {
            this.Name = "Tisch" + Kennzeichen.ToString();
            return this.Name;
        }

        public static List<Tisch> laden(string dateipfad)
        {
            List<Tisch> DeserRaum = new List<Tisch>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Tisch>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Tisch> t)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, t);
            fs.Close();
        }

    }
}
