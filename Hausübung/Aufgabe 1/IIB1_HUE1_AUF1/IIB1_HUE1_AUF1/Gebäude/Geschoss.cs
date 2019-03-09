using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_HUE1_AUF1
{
    public class Geschoss
    {
        private int kennzeichen;
        private string name;
        private double flaeche;
        private List<Raum> raeume = new List<Raum>();

        public int Kennzeichen { get => kennzeichen; set => kennzeichen = value; }
        public string Name { get => name; set => name = value; }
        public double Flaeche { get => flaeche; set => flaeche = value; }
        public List<Raum> Raeume { get => raeume; set => raeume = value; }

    }
}
