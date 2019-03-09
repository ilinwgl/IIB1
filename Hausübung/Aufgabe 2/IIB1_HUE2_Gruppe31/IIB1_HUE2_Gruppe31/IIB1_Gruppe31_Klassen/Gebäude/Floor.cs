using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IIB1_Gruppe31_Klassen
{
    [Serializable]
    public class Floor
    {
        // Fields
        private string kennzeichen;
        private string name;
        private BindingList<Raum> raums;

        // Properties
        public string Name { get => name; set => name = value; }
        public BindingList<Raum> Raums { get => raums; set => raums = value; }
        public string Kennzeichen { get => kennzeichen; set => kennzeichen = value; }

        #region Constructor
        public Floor()
        {
        }

        public Floor(string name, BindingList<Raum> rooms)
        {
            this.Name = name;
            this.Raums = raums;

        }
        #endregion

        #region Methods
        public double areaFloor()
        {
            double floorArea = 0;
            if (raums != null)
            {
                foreach (Raum r in raums)
                {
                    floorArea += r.Flaechen;
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
