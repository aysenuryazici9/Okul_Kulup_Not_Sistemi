﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenicNotlar frmogr=new FrmOgrenicNotlar(); 
            frmogr.numara = textBox1.Text;
            frmogr.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr=new FrmOgretmen();
            fr.Show();  
            this.Hide();
        }
    }
}
