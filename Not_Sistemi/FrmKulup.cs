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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = LAPTOP-CVNIP36M\\MSSQL; Initial Catalog = Okul_Kulup_Projesi; Integrated Security = True");

        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulup", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Kulup (KulupAd) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupAdı.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAdı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From Tbl_Kulup where Kulupid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silindi");
            liste();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Kulup Set KulupAd=@p1 Where Kulupid=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupAdı.Text);
            komut.Parameters.AddWithValue("@p2",  txtKulupId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncellendi");
            liste();
        }
    }
}
