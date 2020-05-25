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
        // Fields
        private string identity;
        private string name;
        private BindingList<Room> rooms;

        // Properties
        public string Name { get => name; set => name = value; }
        public BindingList<Room> Rooms { get => rooms; set => rooms = value; }
        public string Identity { get => identity; set => identity = value; }

        #region Constructor
        public Floor()
        {
        }

        public Floor(string name, BindingList<Room> rooms)
        {
            this.Name = name;
            this.Rooms = rooms;
            
        }
        #endregion

        #region Methods
        public double areaFloor ()
        {
            double floorArea = 0;
            if (rooms != null)
            {
                foreach (Room r in rooms)
                {
                    floorArea += r.Area;
                }
            }
            else
            {
                Console.WriteLine("Field rooms is not initialized! ");
            }

            return floorArea;
        }

        #endregion
    }
}
