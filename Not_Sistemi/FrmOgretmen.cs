using System;
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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void btnDers_Click(object sender, EventArgs e)
        {
            FrmDersler frmders = new FrmDersler();
            frmders.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frogren = new FrmOgrenci();
            frogren.Show();
        }

        private void btnSinavNotlar_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frmsinav = new FrmSinavNotlar();
            frmsinav.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmOgretmenListesi frmogret = new FrmOgretmenListesi();
            frmogret.Show();
        }
    }
}

