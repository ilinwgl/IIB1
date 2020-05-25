using IIB1_HUE1_Gruppe31;
using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        public Form3(Mobiliar mob, Mieter mi, double b, List<string> hs)
        {
            InitializeComponent();

            string a = mi.getName();
            label2.Text = a;
            label4.Text = b.ToString();
            listBox1.Items.Clear();
            foreach (string de in hs)
            {
                listBox1.Items.Add(de);
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
    }
}
