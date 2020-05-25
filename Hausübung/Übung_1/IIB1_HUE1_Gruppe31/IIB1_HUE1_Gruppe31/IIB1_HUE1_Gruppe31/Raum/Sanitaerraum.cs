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
    public class Sanitaerraum : Raum
    {
        public override string getName()
        {
            this.Name = "Sanitärraum" + " " + Kennzeichen.ToString();
            return this.Name;
        }

        public static List<Sanitaerraum> laden(string dateipfad)
        {
            List<Sanitaerraum> DeserRaum = new List<Sanitaerraum>();
            FileStream fs = new FileStream(dateipfad, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            DeserRaum = ((List<Sanitaerraum>)bf.Deserialize(fs));
            fs.Close();
            return DeserRaum;
        }

        public void speichern(string dateipfad, List<Sanitaerraum> s)
        {
            FileStream fs = new FileStream(dateipfad, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, s);
            fs.Close();
        }
    }
}
