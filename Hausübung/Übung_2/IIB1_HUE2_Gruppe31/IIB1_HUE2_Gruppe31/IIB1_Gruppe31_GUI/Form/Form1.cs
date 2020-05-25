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
using ClassFloor = IIB1_Gruppe31_Klassen.Floor;
using ClassRaum = IIB1_Gruppe31_Klassen.Raum;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace IIB1_Gruppe31_GUI
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private Building _build;
        private Raum _raum;
        private ClassFloor _floor;

        Form2 f2;
        public Form2 F2 { get => f2; set => f2 = value; }

        #region New Attributes
        private ExternalEvent _updateEventR;
        private ExternalEvent _updateEventM;
        private ExternalEvent _placeEvent;
        public ClassRaum _clr;
        #endregion

        public Form1(ExternalEvent updateEventR, ExternalEvent updateEventM, ExternalEvent placeEvent, Building b)
        {
            InitializeComponent();
            this._build = b;
            this._updateEventR = updateEventR;
            this._updateEventM = updateEventM;
            this._placeEvent = placeEvent;
            filltreeview();
        }

        public class PlaceData
        {
            #region Place für Platzieren eines Möbels
            public Raum room;
            public Mobiliar mobiliar;
            #endregion
        }

        public PlaceData _cpr; 

        #region instanziieren für comboBox
        string[] bereichs = new string[] { "Ruhezone", "Gemeinschaftsbereich", "Bürobereich", "Lagernbereich", };
        string[] ver = new string[] { "Ja", "Nein" };
        string[] nut = new string[] { "1-Wohnen und Aufenthalt", "2-Büroarbeit", "3-Produktion/Hand-Maschinenarbeit/Experiment", "4-Lagern/Verteilen/Verkaufen", "7-Sonstige Nutzflächen", "8-Technische Anlagen", "9-Verkehrserschl./sicherung" };
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Load
            comboBoxBereich.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNutzung.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVermieten.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int i = 0; i < bereichs.Length; i++)
            {
                comboBoxBereich.Items.Add(bereichs[i]);
            }

            for (int i = 0; i < nut.Length; i++)
            {
                comboBoxNutzung.Items.Add(nut[i]);
            }

            for (int i = 0; i < ver.Length; i++)
            {
                comboBoxVermieten.Items.Add(ver[i]);
            }
            #endregion
        }

        public void filltreeview()
        {
            #region fill Treeview für Geschoss und Raum
            treeViewFloor.Nodes.Clear();
            treeViewFloor.BeginUpdate();
            loadNodes();
            treeViewFloor.EndUpdate();
            #endregion
        }

        public void loadNodes()
        {
            #region loadNodes für Treeview
            foreach (ClassFloor f in _build.Floors)
            {
                TreeNode tn = treeViewFloor.Nodes.Add(f.Name);
                tn.Tag = f;
                addChildNode(tn);
            }
            #endregion
        }

        private void addChildNode(TreeNode tn)
        {
            #region Add Child Node
            foreach (Raum r in ((ClassFloor)tn.Tag).Raums)
            {
                TreeNode tnChild = tn.Nodes.Add(r.Name);
                tnChild.Tag = r;
            }
            #endregion
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            #region Change Selected in Treeview
            Object ob = treeViewFloor.SelectedNode.Tag;
            listBoxMobiliar.Items.Clear();

            if (ob is Raum)
            {
                Raum obr = (Raum)ob;

                foreach (Mobiliar mo in obr.Mobiliars)
                {
                    listBoxMobiliar.Items.Add(mo);
                }
            }

            if (ob is Buero)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = (Buero)ob;
                Buero bu = ob as Buero;
                string nutzung = nut[1];

                auslesenRaum(bu, nutzung);

                _clr = _raum;
            }
            else if (ob is Lagern)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = (Lagern)ob;
                Lagern la = ob as Lagern;
                string nutzung = nut[3];

                auslesenRaum(la, nutzung);

                _clr = _raum;
            }
            else if (ob is Wohnenraum)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = (Wohnenraum)ob;
                Wohnenraum wo = ob as Wohnenraum;
                string nutzung = nut[0];

                auslesenRaum(wo, nutzung);

                _clr = _raum;
            }
            else if (ob is Sanitaerraum)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = (Sanitaerraum)ob;
                Sanitaerraum sa = ob as Sanitaerraum;
                string nutzung = nut[4];

                auslesenRaum(sa, nutzung);

                _clr = _raum;
            }
            else if (ob is Flur)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = (Flur)ob;
                Flur flu = ob as Flur;
                string nutzung = nut[6];

                auslesenRaum(flu, nutzung);

                _clr = _raum;
            }
            else if (ob is Ruheraum)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = (Ruheraum)ob;
                Ruheraum ru = ob as Ruheraum;
                string nutzung = nut[2];

                auslesenRaum(ru, nutzung);

                _clr = _raum;
            }
            else if (ob is Technischraum)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = (Technischraum)ob;
                Technischraum te = ob as Technischraum;
                string nutzung = nut[5];

                auslesenRaum(te, nutzung);

                _clr = _raum;
            }
            else
            {
                ClassFloor fl = ob as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _raum = null;
            }
            #endregion
        }

        private void fillFloor(ClassFloor fl)
        {
            #region bekommen die Anzahl der Räume und die Fläche eines Geschosses
            int roomcount = 0;
            double totalarea = 0;

            foreach (Raum r in fl.Raums)
            {
                roomcount++;
                totalarea += r.Flaechen;
            }
            label34.Text = roomcount.ToString();
            label19.Text = totalarea.ToString();
            #endregion
        }

        public void auslesenRaum(Raum r, string nutzung)
        {
            #region Schreiben Parameters in GUI
            textBoxRaumName.Text = r.Name;
            comboBoxNutzung.Text = nutzung;
            comboBoxBereich.Text = r.Bereich;
            textBoxRaumUmfang.Text = r.Umfang.ToString("f3");
            textBoxRaumFlaeche.Text = r.Flaechen.ToString();
            textBoxRaumMiete.Text = r.Miete.ToString();
            textBoxRaumArbeitsplätze.Text = r.AnzahlArbeitsplaetze.ToString();
            textBoxRaumSitzplätze.Text = r.AnzahlSitzplaetze.ToString();
            textBoxRaumAutomaten.Text = r.AnzahlAutomaten.ToString();
            if (r.Vermieten == true)
            {
                comboBoxVermieten.SelectedIndex = 0;
                textBoxRaumMieter.Text = r.Mieter;
            }
            else
            {
                comboBoxVermieten.SelectedIndex = 1;
                textBoxRaumMieter.Clear();
            }
            textBoxRaumBesitzer.Text = r.Besitzer;
#endregion
        }

        public void getallRaum(Raum r)
        {
            #region Auslesen Parameters in GUI
            string m = textBoxRaumName.Text;
            string[] a = new string[2];
            a = m.Split(' ');
            r.Name = a[0];
            r.Bereich = comboBoxBereich.SelectedItem.ToString();
            r.Umfang = Convert.ToDouble(textBoxRaumUmfang.Text);
            r.Flaechen = Convert.ToDouble(textBoxRaumFlaeche.Text);
            r.Miete = Convert.ToDouble(textBoxRaumMiete.Text);
            r.AnzahlArbeitsplaetze = int.Parse(textBoxRaumArbeitsplätze.Text);
            r.AnzahlSitzplaetze = int.Parse(textBoxRaumSitzplätze.Text);
            r.AnzahlAutomaten = int.Parse(textBoxRaumAutomaten.Text);
            r.Besitzer = textBoxRaumBesitzer.Text;


            if (comboBoxVermieten.SelectedIndex == 0)
            {
                r.Vermieten = true;
                r.Mieter = textBoxRaumMieter.Text;
            }
            else
            {
                r.Vermieten = false;
                r.Mieter = null;
            }
            #endregion
        }

        private void buttonRaumspeichern_Click(object sender, EventArgs e)
        {
            #region Raum Speichern
            if (_raum == null)
            {
                MessageBox.Show("No changes have been saved. Be sure the Room belongs to the Floor!", "Attention!");
            }
            else
            {
                Raum r = treeViewFloor.SelectedNode.Tag as Raum;
                getallRaum(r);

                int i = _floor.Raums.IndexOf(_raum);
                if (comboBoxNutzung.SelectedIndex == 0)
                {
                    _raum = new Wohnenraum(r);
                }
                else if (comboBoxNutzung.SelectedIndex == 1)
                {
                    _raum = new Buero(r);
                }
                else if (comboBoxNutzung.SelectedIndex == 2)
                {
                    _raum = new Ruheraum(r);
                }
                else if (comboBoxNutzung.SelectedIndex == 3)
                {
                    _raum = new Lagern(r);
                }
                else if (comboBoxNutzung.SelectedIndex == 4)
                {
                    _raum = new Sanitaerraum(r);
                }
                else
                {
                    _raum = new Flur(r);
                }

                _floor.Raums[i] = _raum;
                treeViewFloor.SelectedNode.Tag = _raum;
                treeViewFloor.SelectedNode.Text = _raum.Name;
                treeViewFloor.Refresh();
                _updateEventR.Raise();
                MessageBox.Show("Saved successfully!");
            }
            #endregion
        }

        private void ComboBoxVermieten_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region festlegen Vermieten
            if (comboBoxVermieten.SelectedIndex == 0)
            {
                textBoxRaumMieter.ReadOnly = false;
            }
            else
            {
                textBoxRaumMieter.ReadOnly = true;
                textBoxRaumMieter.Clear();
            }
            #endregion
        }

        private void ButtonVeraendern_Click(object sender, EventArgs e)
        {
            #region Verarbeiten ein Möbel
            try
            {
                if (treeViewFloor.SelectedNode.Level == 1)
                {
                    Raum raum = (Raum)treeViewFloor.SelectedNode.Tag;
                    Mobiliar mobiliar = (Mobiliar)listBoxMobiliar.SelectedItem;
                    if (mobiliar != null)
                    {
                        Form2 f2 = new Form2(_updateEventM, mobiliar, raum, _build);
                        F2 = f2;
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bitte ein Möbel auswählen");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void ButtonErstellen_Click(object sender, EventArgs e)
        {
            #region erstellen ein neues Möbel
            if(treeViewFloor.SelectedNode.Level == 1)
            {
                Raum r = (Raum)treeViewFloor.SelectedNode.Tag;

                Form2 mob = new Form2(_updateEventM, null, r, _build);

                if(mob.ShowDialog() == DialogResult.OK)
                {
                    _cpr = new PlaceData();
                    _cpr.room = r;
                    _cpr.mobiliar = mob.NeuesMobiliar;
                    _placeEvent.Raise();
                }
            }
            #endregion
        }

        private void ListBoxMobiliar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


