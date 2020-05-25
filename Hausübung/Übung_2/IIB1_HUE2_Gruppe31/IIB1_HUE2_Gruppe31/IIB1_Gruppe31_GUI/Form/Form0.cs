using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using IIB1_Gruppe31_Klassen;


namespace IIB1_Gruppe31_GUI
{
    public partial class Form0 : System.Windows.Forms.Form
    {
        private BindingList<Building> _buildings;
        private Building _build;

        #region New Attributes & Properties
        Form1 f1;
        private ExternalEvent _updateEventR;
        private ExternalEvent _updateEventM;
        private ExternalEvent _placeEvent;
        #endregion

        public Form1 F1 { get { return f1; } }

        public Form0(BindingList<Building> buildings)
        {
            InitializeComponent();
            this._buildings = buildings;
            filllist();
        }

        // New Constructor
        public Form0(ExternalEvent updateEventR, ExternalEvent updateEventM, ExternalEvent placeEvent, BindingList<Building> buildings)
        {
            InitializeComponent();
            this._buildings = buildings;
            this._updateEventR = updateEventR;
            this._updateEventM = updateEventM;
            this._placeEvent = placeEvent;
            filllist();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
        }

        private void filllist()
        {
            foreach (Building b in _buildings)
            {
                listBoxBuilding.DataSource = _buildings;
                listBoxBuilding.DisplayMember = "Name";
            }
        }

        public void saveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, _buildings);
                fs.Close();
            }
        }

        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveToFile();
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                _buildings = (BindingList<Building>)bf.Deserialize(fs);
                fs.Close();
                filllist();
            }
        }

        private void listBoxBuilding_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _build = (Building)listBoxBuilding.SelectedItem;
            textBox1.Text = _build.Name;
            textBox2.Text = _build.Adress;
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            f1 = new Form1(_updateEventR, _updateEventM, _placeEvent, _build);
            f1.Show();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

