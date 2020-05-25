using Autodesk.Revit.UI;
using IIB1_Gruppe31_Klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIB1_Gruppe31_GUI
{
    public partial class Form2 : Form
    {
        public Mobiliar NeuesMobiliar { get; set; }

        private ExternalEvent _updateEventM;
        public Mobiliar _mob;

        private Building _building; 
        private Raum raum;

        string[] Zust = new string[] { "defekt", "beschädigt", "intakt" };
        List<Mobiliar> allMobiliar = new List<Mobiliar>();

        public Form2(ExternalEvent updateEvent, Mobiliar mobiliar, Raum raum, Building building)
        {
            InitializeComponent();

            this._updateEventM = updateEvent;
            this._mob = mobiliar;
            this.raum = raum;
            this._building = building;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            #region load Form2
            comboBoxMobiliarZustand.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxMobiliarRaum.ReadOnly = true;

            //Zustand der Mobiliar in comboBoxMobiliarZustand hinzufügen
            for (int i = 0; i < Zust.Length; i++)
            {
                comboBoxMobiliarZustand.Items.Add(Zust[i]);
            }

            if (_mob != null)
            {

                textBoxMobiName.Text = _mob.Name;
                textBoxMobiliarMaterial.Text = _mob.Material;
                textBoxMobiliarBreite.Text = _mob.Breit.ToString();
                textBoxMobiliarHöhe.Text = _mob.Hoehe.ToString();
                textBoxMobiliarLength.Text = _mob.Length.ToString();
                textBoxMobiliarMieter.Text = _mob.MitName;
                textBoxMobiliarWert.Text = _mob.Wert.ToString();
                textBoxMobiliarRaum.Text = _mob.Raumkennzeichen;
                comboBoxMobiliarZustand.Text = _mob.Zustand;
            }
            else
            {
                textBoxMobiName.Text = "1600 x 800 x 700";
                textBoxMobiliarBreite.Text = "700";
                textBoxMobiliarHöhe.Text = "800";
                textBoxMobiliarLength.Text = "1600";
                textBoxMobiliarMieter.Text = raum.Mieter;
                textBoxMobiliarRaum.Text = raum.Name;
            }
            #endregion
        }

        public void getallMobiliar(Mobiliar m)
        {
            #region Auslesen die Parameter von GUI
            m.Name = textBoxMobiName.Text;
            m.Material = textBoxMobiliarMaterial.Text;
            m.Breit = Convert.ToDouble(textBoxMobiliarBreite.Text);
            m.Hoehe = Convert.ToDouble(textBoxMobiliarHöhe.Text);
            m.Length = Convert.ToDouble(textBoxMobiliarLength.Text);
            m.Wert = Convert.ToDouble(textBoxMobiliarWert.Text);
            m.MitName = textBoxMobiliarMieter.Text;
            m.Raumkennzeichen = textBoxMobiliarRaum.Text;
            m.Zustand = comboBoxMobiliarZustand.SelectedItem.ToString();
            #endregion
        }

        private void ButtonMobiliarspeichern_Click(object sender, EventArgs e)
        {
            #region Button für Mobiliar Speichern
            if (_mob == null)
            {
                try
                {
                    NeuesMobiliar = (Mobiliar)Activator.CreateInstance(typeof(Tisch));

                    getallMobiliar(NeuesMobiliar);
                }
                catch (Exception ex)
                {
                    TaskDialog.Show("ERROR", ex.Message);
                    return;
                }
            }
            else
            {
                getallMobiliar(_mob);
                _updateEventM.Raise();
                MessageBox.Show("Saved successfully!");
            }

            DialogResult = DialogResult.OK;
            Close();
            #endregion
        }

        public List<Mobiliar> getAllmobiliar(Building _build, string mieter)
        {
            #region bekommen die Mobiliar von einem Mieter
            List<Mobiliar> allMobiliar = new List<Mobiliar>();
            foreach(Floor floor in _build.Floors)
            {
                foreach(Raum raum in floor.Raums)
                {
                    foreach (Mobiliar mob in raum.Mobiliars)
                    {
                        if(mob.MitName == mieter)
                        {
                            allMobiliar.Add(mob);
                        }
                    }
                }
            }
            return allMobiliar;
            #endregion
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            #region Aufstellung der Möbelkosten
            string mieter = textBoxMobiliarMieter.Text;
            List<Mobiliar> allMobiliar = getAllmobiliar(_building, mieter);

            Form3 f3 = new Form3(mieter, allMobiliar);
            f3.Show();
            #endregion
        }
    }
}
