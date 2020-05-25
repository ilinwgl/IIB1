using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_HUE1_Gruppe31
{
    public class Bereich
    {
        // Deklarierung der Attribute
        private int kennzeichen;
        private string name;
        private double groesse;
        private string[] anteil = new string[] { "Ruhezone", "Gemeinschaftsbereich", "Bürobereich", "Lagernbereich", };
        private List<Raum> ruhezone = new List<Raum>();
        private List<Raum> gemeinschaftsbereich = new List<Raum>();
        private List<Raum> buerobereich = new List<Raum>();
        private List<Raum> lagernbereich = new List<Raum>();

        //verteilen die Räume in unterschiedlichen Bereichen
        public double getGroesse(Raum ra)
        {
            switch (ra.Bereich)
            {
                case "Ruhezone":
                    {
                        ruhezone.Clear();
                        ruhezone.Add(ra);
                        foreach (Raum r in Ruhezone)
                        {
                            groesse += r.Flaechen;
                        }

                        for (int i = 0; i < ruhezone.Count; i++)
                        {
                            for (int j = ruhezone.Count - 1; j > i; j--)
                            {
                                if (ruhezone[i].Equals(ruhezone[j]))
                                {
                                    ruhezone.RemoveAt(i);
                                }
                            }
                        }
                    }
                    break;

                case "Gemeinschaftsbereich":
                    {
                        gemeinschaftsbereich.Clear();
                        gemeinschaftsbereich.Add(ra);
                        foreach (Raum r in gemeinschaftsbereich)
                        {
                            groesse += r.Flaechen;
                        }

                        for (int i = 0; i < gemeinschaftsbereich.Count; i++)
                        {
                            for (int j = gemeinschaftsbereich.Count - 1; j > i; j--)
                            {
                                if (gemeinschaftsbereich[i].Equals(gemeinschaftsbereich[j]))
                                {
                                    gemeinschaftsbereich.RemoveAt(i);
                                }
                            }
                        }
                    }
                    break;

                case "Bürobereich":
                    {
                        buerobereich.Clear();
                        buerobereich.Add(ra);
                        foreach (Raum r in buerobereich)
                        {
                            groesse += r.Flaechen;
                        }

                        for (int i = 0; i < buerobereich.Count; i++)
                        {
                            for (int j = buerobereich.Count - 1; j > i; j--)
                            {
                                if (buerobereich[i].Equals(buerobereich[j]))
                                {
                                    buerobereich.RemoveAt(i);
                                }
                            }
                        }
                    }
                    break;

                case "Lagernbereich":
                    {
                        lagernbereich.Clear();
                        lagernbereich.Add(ra);
                        foreach (Raum r in lagernbereich)
                        {
                            groesse += r.Flaechen;
                        }

                        for (int i = 0; i < lagernbereich.Count; i++)
                        {
                            for (int j = lagernbereich.Count - 1; j > i; j--)
                            {
                                if (lagernbereich[i].Equals(lagernbereich[j]))
                                {
                                    lagernbereich.RemoveAt(i);
                                }
                            }
                        }
                    }
                    break;
            }
 
            return groesse;
        }


        //Schutz der Daten
        public int Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public string Name { get => name; set => name = value; }
        public double Groesse { get => groesse; set => groesse = value; }
        public string[] Anteil { get => anteil; set => anteil = value; }
        public List<Raum> Ruhezone { get => ruhezone; set => ruhezone = value; }
        public List<Raum> Gemeinschaftsbereich { get => gemeinschaftsbereich; set => gemeinschaftsbereich = value; }
        public List<Raum> Buerobereich { get => buerobereich; set => buerobereich = value; }
        public List<Raum> Lagernbereich { get => lagernbereich; set => lagernbereich = value; }
    }
}
