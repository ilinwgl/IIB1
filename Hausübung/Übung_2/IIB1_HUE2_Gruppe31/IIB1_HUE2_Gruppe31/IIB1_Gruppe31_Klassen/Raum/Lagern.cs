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

    public class Lagern : Raum
    {

        public Lagern(string kennzeichen, string name, double flaeche) : base(kennzeichen, name, flaeche)
        {
        }

        public Lagern()
        {
        }

        public Lagern(string name, double flaeche) : base(name, flaeche)
        {
        }

        public Lagern(Raum raum) : base(raum)
        {

        }
    }
}
