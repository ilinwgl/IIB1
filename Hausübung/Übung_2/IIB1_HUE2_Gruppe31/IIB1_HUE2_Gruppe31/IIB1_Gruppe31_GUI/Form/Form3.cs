using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IIB1_Gruppe31_Klassen;

namespace IIB1_Gruppe31_GUI
{
    public partial class Form3 : Form
    {
        string _mieter;
        List<Mobiliar> _allMobiliar = new List<Mobiliar>();
        public Form3(string mieter, List<Mobiliar> allMobiliar)
        {
            InitializeComponent();
            this._mieter = mieter;
            this._allMobiliar = allMobiliar;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = _mieter;

            foreach(Mobiliar mob in _allMobiliar)
            {
                string m = mob.Name + "           " + mob.Wert;
                listBox1.Items.Add(m);
            }

            double Gesamtkosten = 0;
            foreach(Mobiliar mob in _allMobiliar)
            {
                Gesamtkosten += mob.Wert;
            }
            label3.Text = Gesamtkosten.ToString();
        }
    }
}
