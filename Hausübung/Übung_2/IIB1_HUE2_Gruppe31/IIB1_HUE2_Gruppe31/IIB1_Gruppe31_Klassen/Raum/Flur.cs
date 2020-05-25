using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_Gruppe31_Klassen
{
    [Serializable]

    public class Flur : Raum
    {       
        public Flur(string kennzeichen, string name, double flaeche): base(kennzeichen, name, flaeche)
        {
        }

        public Flur()
        {
        }

        public Flur(string name, double flaeche) : base(name, flaeche)
        {
        }

        public Flur(Raum raum) : base(raum)
        {

        }
    }
}
