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
    public class Office : Room
    {
        public Office(string name, double area) : base(name, area)
        {
        }
        public Office (Room room):base(room)
        {

        }

    }
}
