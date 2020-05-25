namespace IIB1_Demonstrator_GUI.Forms
{
    partial class FormBuildingdetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewFloor = new System.Windows.Forms.TreeView();
            this.label_qm = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRoomarea = new System.Windows.Forms.TextBox();
            this.textBoxRoomname = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFloorname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFloorArea = new System.Windows.Forms.TextBox();
            this.textBoxRoomcount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPlaceTel = new System.Windows.Forms.Button();
            this.comboBoxRoomtyp = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewFloor
            // 
            this.treeViewFloor.Location = new System.Drawing.Point(9, 36);
            this.treeViewFloor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeViewFloor.Name = "treeViewFloor";
            this.treeViewFloor.Size = new System.Drawing.Size(212, 310);
            this.treeViewFloor.TabIndex = 0;
            this.treeViewFloor.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFloor_AfterSelect);
            // 
            // label_qm
            // 
            this.label_qm.AutoSize = true;
            this.label_qm.Location = new System.Drawing.Point(229, 97);
            this.label_qm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_qm.Name = "label_qm";
            this.label_qm.Size = new System.Drawing.Size(18, 13);
            this.label_qm.TabIndex = 10;
            this.label_qm.Text = "m²";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Typ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Area";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Name";
            // 
            // textBoxRoomarea
            // 
            this.textBoxRoomarea.Location = new System.Drawing.Point(100, 94);
            this.textBoxRoomarea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRoomarea.Name = "textBoxRoomarea";
            this.textBoxRoomarea.ReadOnly = true;
            this.textBoxRoomarea.Size = new System.Drawing.Size(125, 20);
            this.textBoxRoomarea.TabIndex = 5;
            // 
            // textBoxRoomname
            // 
            this.textBoxRoomname.Location = new System.Drawing.Point(100, 60);
            this.textBoxRoomname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRoomname.Name = "textBoxRoomname";
            this.textBoxRoomname.Size = new System.Drawing.Size(125, 20);
            this.textBoxRoomname.TabIndex = 4;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(344, 358);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(56, 19);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(461, 358);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(56, 19);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "m²";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // textBoxFloorname
            // 
            this.textBoxFloorname.Location = new System.Drawing.Point(100, 24);
            this.textBoxFloorname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFloorname.Name = "textBoxFloorname";
            this.textBoxFloorname.ReadOnly = true;
            this.textBoxFloorname.Size = new System.Drawing.Size(125, 20);
            this.textBoxFloorname.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total area ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Rooms";
            // 
            // textBoxFloorArea
            // 
            this.textBoxFloorArea.Location = new System.Drawing.Point(100, 93);
            this.textBoxFloorArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFloorArea.Name = "textBoxFloorArea";
            this.textBoxFloorArea.ReadOnly = true;
            this.textBoxFloorArea.Size = new System.Drawing.Size(125, 20);
            this.textBoxFloorArea.TabIndex = 5;
            // 
            // textBoxRoomcount
            // 
            this.textBoxRoomcount.Location = new System.Drawing.Point(100, 59);
            this.textBoxRoomcount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRoomcount.Name = "textBoxRoomcount";
            this.textBoxRoomcount.Size = new System.Drawing.Size(125, 20);
            this.textBoxRoomcount.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxFloorname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxRoomcount);
            this.groupBox1.Controls.Add(this.textBoxFloorArea);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(236, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(281, 125);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Floor Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPlaceTel);
            this.groupBox2.Controls.Add(this.comboBoxRoomtyp);
            this.groupBox2.Controls.Add(this.label_qm);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxRoomname);
            this.groupBox2.Controls.Add(this.textBoxRoomarea);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(236, 176);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(281, 169);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Room Details";
            // 
            // buttonPlaceTel
            // 
            this.buttonPlaceTel.Location = new System.Drawing.Point(124, 124);
            this.buttonPlaceTel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPlaceTel.Name = "buttonPlaceTel";
            this.buttonPlaceTel.Size = new System.Drawing.Size(56, 40);
            this.buttonPlaceTel.TabIndex = 12;
            this.buttonPlaceTel.Text = "Place Telefon";
            this.buttonPlaceTel.UseVisualStyleBackColor = true;
            this.buttonPlaceTel.Click += new System.EventHandler(this.buttonPlaceLamp_Click);
            // 
            // comboBoxRoomtyp
            // 
            this.comboBoxRoomtyp.FormattingEnabled = true;
            this.comboBoxRoomtyp.Items.AddRange(new object[] {
            "Living Room",
            "Office"});
            this.comboBoxRoomtyp.Location = new System.Drawing.Point(100, 22);
            this.comboBoxRoomtyp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxRoomtyp.Name = "comboBoxRoomtyp";
            this.comboBoxRoomtyp.Size = new System.Drawing.Size(125, 21);
            this.comboBoxRoomtyp.TabIndex = 11;
            // 
            // FormBuildingdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 396);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.treeViewFloor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBuildingdetails";
            this.Text = "Floor and Room Details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFloor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRoomarea;
        private System.Windows.Forms.TextBox textBoxRoomname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label_qm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFloorname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFloorArea;
        private System.Windows.Forms.TextBox textBoxRoomcount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxRoomtyp;
        private System.Windows.Forms.Button buttonPlaceTel;
    }
}