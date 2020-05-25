using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace IIB1_Demonstrator_ClassLibrary.Classes
{
    [Serializable]
    public class Livingroom : Room
    {
        public Livingroom(string name, double area) : base(name, area)
        {
        }

        public Livingroom (Room room):base(room)
        {

        }
    }
}
