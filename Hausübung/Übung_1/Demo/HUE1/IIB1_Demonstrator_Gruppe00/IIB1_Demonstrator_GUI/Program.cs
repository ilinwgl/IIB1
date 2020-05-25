using IIB1_Demonstrator_ClassLibrary.Classes;
using IIB1_Demonstrator_GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIB1_Demonstrator_GUI
{
    static class Program
    {
        private static BindingList<Building> buildings = new BindingList<Building>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // in start class
        static void Main()
        {
            expGenerate();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormStart(buildings));
        }

        private static void expGenerate()
        {
            Random rd = new Random();
          
            for (int i = 0; i<3; i++)
            {
                string name = "Building " + rd.Next(1, 4).ToString() + "a";
                string adress = rd.Next(1, 75).ToString() + "Street";
                int levelnumber = rd.Next(1, 5);
                BindingList<Floor> floors = new BindingList<Floor>();
                for (int j = 0; j < levelnumber; j++)
                {
                    string vname = j.ToString();
                    string levelname = "Floor" + vname;
                    int officenumber = rd.Next(1, 4);
                    int livenumber = rd.Next(1, 4);

                    BindingList<Room> rooms = new BindingList<Room>();
                    
                    for (int k= 0; k < officenumber; k++)
                    {
                        string offname = "Office " + vname + k.ToString();
                        double area = Math.Round(rd.NextDouble() * rd.Next(50, 100),1);
                        rooms.Add(new Office(offname,area));
                    }

                    for (int k = 0; k < livenumber; k++)
                    {
                        string livename = "Livingroom " + vname + k.ToString();
                        double area = Math.Round(rd.NextDouble() * rd.Next(50, 100),1);
                        rooms.Add(new Livingroom(livename, area));
                    }

                    floors.Add(new Floor(levelname, rooms));


                }
                buildings.Add(new Building(name,adress,floors));
            }

            
            
        }
    }
}
