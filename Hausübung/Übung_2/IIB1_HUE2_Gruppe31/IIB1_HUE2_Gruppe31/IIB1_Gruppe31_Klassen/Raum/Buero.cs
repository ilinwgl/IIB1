using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IIB1_Gruppe31_Klassen
{
    [Serializable]

    public class Buero : Raum
    {

        public Buero(string kennzeichen, string name, double flaeche) : base(kennzeichen, name, flaeche)
        {
        }

        public Buero()
        {
        }

        public Buero(string name, double flaeche) : base(name, flaeche)
        {
        }

        public Buero(Raum raum) : base(raum)
        {

        }
        
    }
}
