using IIB1_Demonstrator_ClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassFloor = IIB1_Demonstrator_ClassLibrary.Classes.Floor;
using ClassRoom = IIB1_Demonstrator_ClassLibrary.Classes.Room;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace IIB1_Demonstrator_GUI.Forms
{
    public partial class FormBuildingdetails : System.Windows.Forms.Form
    {
        private Building _build;
        private Room _room;
        private ClassFloor _floor;

        #region New Attributes
        private ExternalEvent _updateEvent;
        private ExternalEvent _placeEvent;
        public ClassRoom _clr;
        #endregion

        public FormBuildingdetails(Building b, FormStart _parent)
        {
            InitializeComponent();
            this._build = b;
            this.Owner = _parent;
            filltreeview();
        }

        public FormBuildingdetails(ExternalEvent updateEvent,ExternalEvent placeEvent, Building b)
        {
            InitializeComponent();
            this._build = b;
            this._updateEvent = updateEvent;
            this._placeEvent = placeEvent;
            filltreeview();
        }

        private void filltreeview()
        {
            treeViewFloor.Nodes.Clear();
            treeViewFloor.BeginUpdate();
            loadNodes();
            treeViewFloor.EndUpdate();
        }

        private void loadNodes()
        {
            foreach (ClassFloor f in _build.Floors)
            {
                TreeNode tn = treeViewFloor.Nodes.Add(f.Name);
                tn.Tag = f;
                addChildNode(tn);
            }
        }

        private void addChildNode(TreeNode tn)
        {
            foreach (Room r in ((ClassFloor)tn.Tag).Rooms)
            {
                TreeNode tnChild = tn.Nodes.Add(r.Name);
                tnChild.Tag = r;
            }
        }

        private void treeViewFloor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Object ob = treeViewFloor.SelectedNode.Tag;

            if (ob is Livingroom)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _room = (Livingroom)ob;
                Livingroom lr = ob as Livingroom;
                comboBoxRoomtyp.Text = "Living Room";
                textBoxRoomname.Text = lr.Name;
                textBoxRoomarea.Text = lr.Area.ToString();
                _clr = _room;
            }
            else if (ob is Office)
            {
                ClassFloor fl = treeViewFloor.SelectedNode.Parent.Tag as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _room = (Office)ob;
                Office of = ob as Office;
                comboBoxRoomtyp.Text = "Office";
                textBoxRoomname.Text = of.Name;
                textBoxRoomarea.Text = of.Area.ToString();
                _clr = _room;
            }
            else
            {
                ClassFloor fl = ob as ClassFloor;
                _floor = fl;
                fillFloor(fl);
                _room = null;
            }
        }

        private void fillFloor(ClassFloor fl)
        {
            int roomcount = 0;
            double totalarea = 0;

            foreach (Room r in fl.Rooms)
            {
                roomcount++;
                totalarea += r.Area;
            }
            textBoxFloorname.Text = fl.Name.ToString();
            textBoxRoomcount.Text = roomcount.ToString();
            textBoxFloorArea.Text = totalarea.ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Edited from UE1
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_room == null)
            {
                MessageBox.Show("No changes have been saved. Be sure the Room belongs to the Floor!", "Attention!");
            }
            else
            {
                Room r = treeViewFloor.SelectedNode.Tag as Room;
                r.Name = textBoxRoomname.Text;
                r.Area = Double.Parse(textBoxRoomarea.Text);

                int i = _floor.Rooms.IndexOf(_room);
                if (comboBoxRoomtyp.SelectedIndex == 0)
                {
                    _room = new Livingroom(r);
                }
                else
                {
                    _room = new Office(r);
                }
                _floor.Rooms[i] = _room;
                treeViewFloor.SelectedNode.Tag = _room;
                treeViewFloor.SelectedNode.Text = _room.Name;
                treeViewFloor.Refresh();
                _updateEvent.Raise();
                MessageBox.Show("Saved successfully!");

                #region Outdated from HUE2
                // Allow a Dialog Form "Buildingdetails" to Retrieve Information from its Calling Form "Start"
                //((Start)this.Owner).saveToFile();
                #endregion
            }
           
        }

        // New Method HUE3
        private void buttonPlaceLamp_Click(object sender, EventArgs e)
        {
            _placeEvent.Raise();
        }

     
    }
    
}


