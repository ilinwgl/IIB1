using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace IIB1_Demonstrator_ClassLibrary.Classes
{
    [Serializable]
    public class Floor
    {
        private string identity;
        private string name;
        private BindingList<Room> rooms;

   

        public string Name { get => name; set => name = value; }
        public BindingList<Room> Rooms { get => rooms; set => rooms = value; }
        public string Identity { get => identity; set => identity = value; }

        public Floor()
        {
        }

        public Floor(string name, BindingList<Room> rooms)
        {
            this.Name = name;
            this.Rooms = rooms;
            
        }
    }
}
