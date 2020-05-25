using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IIB1_Gruppe31_GUI;
using IIB1_Gruppe31_Klassen;

namespace IIB1_Gruppe31_GUI
{
    static class Program
    {
        private static BindingList<Building> buildings = new BindingList<Building>();
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            expGenerate();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form0(buildings));
        }

        private static void expGenerate()
        {
            Random rd = new Random();

            for (int i = 0; i < 3; i++)
            {
                string name = "Building " + rd.Next(1, 4).ToString() + "a";
                string adress = rd.Next(1, 75).ToString() + "Street";
                int levelnumber = rd.Next(1, 5);
                BindingList<Floor> floors = new BindingList<Floor>();
                for (int j = 0; j < levelnumber; j++)
                {
                    string vname = j.ToString();
                    string levelname = "Floor" + vname;
                    int bueronumber = rd.Next(1, 4);
                    int flurnumber = rd.Next(1, 4);
                    int lagernnumber = rd.Next(1, 4);
                    int wohnenraumnumber = rd.Next(1, 4);
                    int ruheraumnumber = rd.Next(1, 4);
                    int sanitaerraumnumber = rd.Next(1, 4);
                    int technischraumnumber = rd.Next(1, 4);

                    BindingList<Raum> raums = new BindingList<Raum>();

                    for (int k = 0; k < bueronumber; k++)
                    {
                        string bueroname = "Büro " + vname + k.ToString();
                        double flaeche = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        raums.Add(new Buero(bueroname, flaeche));
                    }

                    for (int k = 0; k < flurnumber; k++)
                    {
                        string flurname = "Flur " + vname + k.ToString();
                        double flaeche = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        raums.Add(new Flur(flurname, flaeche));
                    }

                    for (int k = 0; k < lagernnumber; k++)
                    {
                        string lagernname = "Lagern " + vname + k.ToString();
                        double flaeche = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        raums.Add(new Flur(lagernname, flaeche));
                    }

                    for (int k = 0; k < wohnenraumnumber; k++)
                    {
                        string wohnenraumname = "Wohnenraum " + vname + k.ToString();
                        double flaeche = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        raums.Add(new Flur(wohnenraumname, flaeche));
                    }

                    for (int k = 0; k < ruheraumnumber; k++)
                    {
                        string ruheraumname = "Ruheraum " + vname + k.ToString();
                        double flaeche = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        raums.Add(new Flur(ruheraumname, flaeche));
                    }

                    for (int k = 0; k < sanitaerraumnumber; k++)
                    {
                        string sanitaerraumname = "Sanitärraum " + vname + k.ToString();
                        double flaeche = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        raums.Add(new Flur(sanitaerraumname, flaeche));
                    }

                    for (int k = 0; k < technischraumnumber; k++)
                    {
                        string technischraumname = "Technischraum " + vname + k.ToString();
                        double flaeche = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        raums.Add(new Flur(technischraumname, flaeche));
                    }

                    floors.Add(new Floor(levelname, raums));
                }
                buildings.Add(new Building(name, adress, floors));
            }
        }
    }
}
