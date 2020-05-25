using IIB1_Demonstrator_ClassLibrary.Classes;
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


namespace IIB1_Demonstrator_GUI.Forms
{
    public partial class FormStart : Form
    {
        private BindingList<Building> _buildings;
        private Building _build;
     
        public FormStart(BindingList<Building> buildings)
        {
            InitializeComponent();
            this._buildings = buildings;
            filllist();
        } 

        private void filllist()
        {
            foreach (Building b in _buildings)
            {
                listBoxBuilding.DataSource = _buildings;
                listBoxBuilding.DisplayMember = "Name";
            }           
        }

        private void listBoxBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            _build = (Building)listBoxBuilding.SelectedItem;
            textBoxName.Text = _build.Name;
            textBoxAdress.Text = _build.Adress;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMoredetails_Click(object sender, EventArgs e)
        {
            (new FormBuildingdetails(_build, this)).ShowDialog();

          
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToFile();
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
