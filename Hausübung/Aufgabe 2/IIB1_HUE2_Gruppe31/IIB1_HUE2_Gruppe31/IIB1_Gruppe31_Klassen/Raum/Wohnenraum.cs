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

    public class Wohnenraum : Raum
    {
        public Wohnenraum(string kennzeichen, string name, double flaeche) : base(kennzeichen, name, flaeche)
        {
        }

        public Wohnenraum()
        {
        }

        public Wohnenraum(string name, double flaeche) : base(name, flaeche)
        {
        }

        public Wohnenraum(Raum raum) : base(raum)
        {

        }
    }
}
