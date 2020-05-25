using IIB1_HUE1_Gruppe31;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2(Raum raum, List<string> Li)
        {
            InitializeComponent();

            string x = raum.getName();
            label2.Text = x;
            foreach (string a in Li)
            {
                listBox1.Items.Add(a);
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {                        
        }
    }
}
