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
using Floor = IIB1_Demonstrator_ClassLibrary.Classes.Floor;


namespace IIB1_Demonstrator_GUI.Forms
{
    public partial class FormBuildingdetails : System.Windows.Forms.Form
    {
        private Building _build;
        private Room _room;
        private Floor _floor;
 
        public FormBuildingdetails(Building b, FormStart _parent)
        {
            InitializeComponent();
            _build = b;
            this.Owner = _parent;
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
            foreach (Floor f in _build.Floors)
            {
                TreeNode tn = treeViewFloor.Nodes.Add(f.Name);
                tn.Tag = f;
                addChildNode(tn);
            }
        }

        private void addChildNode(TreeNode tn)
        {
            foreach (Room r in ((Floor)tn.Tag).Rooms)
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
                Floor fl = treeViewFloor.SelectedNode.Parent.Tag as Floor;
                _floor = fl;
                fillFloor(fl);
                _room = (Livingroom)ob;
                Livingroom lr = ob as Livingroom;
                comboBoxRoomTyp.Text = "Living Room";
                textBoxRoomname.Text = lr.Name;
                textBoxRoomarea.Text = lr.Area.ToString();
            }
            else if (ob is Office)
            {
                Floor fl = treeViewFloor.SelectedNode.Parent.Tag as Floor;
                _floor = fl;
                fillFloor(fl);
                _room = (Office)ob;
                Office of = ob as Office;
                comboBoxRoomTyp.Text = "Office";
                textBoxRoomname.Text = of.Name;
                textBoxRoomarea.Text = of.Area.ToString();
            }
            else
            {
                Floor fl = ob as Floor;
                _floor = fl;
                fillFloor(fl);
                _room = null;
            }
        }

        private void fillFloor(Floor fl)
        {
            
            int roomcount = 0;
            double totalarea = 0;

            foreach (Room r in fl.Rooms)
            {
                roomcount++;
                totalarea += r.Area;
            }
            textBoxFloorName.Text = fl.Name.ToString();
            textBoxRoomcount.Text = roomcount.ToString();
            textBoxFloorArea.Text = totalarea.ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_room == null)
            {
                MessageBox.Show("No changes have been saved. Be sure the Room belongs to the Floor!","Attention!");
            }
            else
            {
                //Room r = new Room();
                Room r = treeViewFloor.SelectedNode.Tag as Room;
                r.Name = textBoxRoomname.Text;
                r.Area = Double.Parse(textBoxRoomarea.Text);

                int i = _floor.Rooms.IndexOf(_room);
                if (comboBoxRoomTyp.SelectedIndex == 0)
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

                // Allow a Dialog Form "Buildingdetails" to Retrieve Information from its Calling Form "Start"
                ((FormStart)this.Owner).saveToFile();                
            }

        }

    }
    
}


