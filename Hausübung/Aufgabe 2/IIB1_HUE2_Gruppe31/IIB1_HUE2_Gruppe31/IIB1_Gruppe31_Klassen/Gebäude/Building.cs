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
    public class Building
    {
        // Fields
        private String name;
        private String adress;
        private BindingList<Floor> floors;

        // Properties
        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
        public BindingList<Floor> Floors { get => floors; set => floors = value; }

        public Building()
        {
        }

        public Building(string name, string adress, BindingList<Floor> floors)
        {
            this.Name = name;
            this.Adress = adress;
            this.Floors = floors;
        }

        public double areaBuilding()
        {
            double buildingArea = 0;
            // Ckeck if Field "floors" is already initialized
            if (floors != null)
            {
                //Interate all Rooms on one Floor 
                foreach (Floor f in floors)
                {
                    // Add up floor area; Short for a = a + b
                    buildingArea += f.areaFloor();
                }
            }
            else
            {
                Console.WriteLine("Field floors is not initialized! ");
            }
            return buildingArea;
        }
    }
}

