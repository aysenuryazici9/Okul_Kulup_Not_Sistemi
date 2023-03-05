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
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = LAPTOP-CVNIP36M\\MSSQL; Initial Catalog = Okul_Kulup_Projesi; Integrated Security = True");

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Ders", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DersAd";
            comboBox1.ValueMember = "Dersid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));
        }

        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtS1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtS2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtS3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            //  string durum;
            sinav1 = Convert.ToInt16(txtS1.Text);
            sinav2 = Convert.ToInt16(txtS2.Text);
            sinav3 = Convert.ToInt16(txtS3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3+ proje) / 4;
            txtOrt.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtDurum.Text = "True";
            }
            else
            {
                txtDurum.Text = "False";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtid.Text),byte.Parse(txtS1.Text), byte.Parse(txtS2.Text), byte.Parse(txtS3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrt.Text), bool.Parse(txtDurum.Text), notid);
            MessageBox.Show("Öğrenci Bilgileri Güncellendi");
        }
    }
}
