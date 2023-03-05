using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Not_Sistemi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = LAPTOP-CVNIP36M\\MSSQL; Initial Catalog = Okul_Kulup_Projesi; Integrated Security = True");

        DataSet1TableAdapters.Tbl_OgrenciTableAdapter ds = new DataSet1TableAdapters.Tbl_OgrenciTableAdapter();

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulup", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KulupAd";
            comboBox1.ValueMember = "Kulupid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            ds.OgrenciEkle(txtOgrenciAdi.Text, txtOgrenciSoyadi.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Eklendi");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrenciId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrenciAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrenciSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
           ds.OgrenciGuncelle(txtOgrenciAdi.Text, txtOgrenciSoyadi.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(txtOgrenciId.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
