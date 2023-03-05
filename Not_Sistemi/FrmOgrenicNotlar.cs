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
    public partial class FrmOgrenicNotlar : Form
    {
        public FrmOgrenicNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = LAPTOP-CVNIP36M\\MSSQL; Initial Catalog = Okul_Kulup_Projesi; Integrated Security = True");
        public string numara;
        private void FrmOgrenicNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select DersAd,Sinav1,Sinav2,Sinav3,Proje,Ortalama,Durum FROM Tbl_Notlar INNER JOIN Tbl_Ders ON Tbl_Notlar.Dersid = Tbl_Ders.Dersid Where Ogrid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
