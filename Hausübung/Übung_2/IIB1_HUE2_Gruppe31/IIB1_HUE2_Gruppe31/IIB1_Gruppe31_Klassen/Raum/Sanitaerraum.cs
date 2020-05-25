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

    public class Sanitaerraum : Raum
    {
        public Sanitaerraum(string kennzeichen, string name, double flaeche) : base(kennzeichen, name, flaeche)
        {
        }

        public Sanitaerraum()
        {
        }

        public Sanitaerraum(string name, double flaeche) : base(name, flaeche)
        {
        }

        public Sanitaerraum(Raum raum) : base(raum)
        {

        }
    }
}
