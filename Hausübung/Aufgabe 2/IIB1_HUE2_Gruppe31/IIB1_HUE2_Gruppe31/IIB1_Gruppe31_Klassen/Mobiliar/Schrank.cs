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

    public class Schrank : Mobiliar
    {
        public Schrank() { }
        public Schrank(Mobiliar mobiliar) : base(mobiliar)
        { }
    }
}

