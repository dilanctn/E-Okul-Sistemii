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

namespace Proje__E_okul_Benzeri_Proje__SQL_İlişkili_Tablolar_ile_
{
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();

        private void BtnOgrBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtOgrid.Text)) ;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-7C53G4M\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");//kulüp formundan aldık

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERSLER", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDersAd.DisplayMember = "DERSAD";
            cmbDersAd.ValueMember = "DERSID";
            cmbDersAd.DataSource = dt;
            baglantı.Close();
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtS1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtS2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtS3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int s1, s2, s3, proje;
        double ort;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            
           // string durum;

            s1 = Convert.ToInt16(TxtS1.Text);
            s2 = Convert.ToInt16(TxtS2.Text);
            s3 = Convert.ToInt16(TxtS3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ort = (s1 + s2 + s3 + proje) / 4;
            TxtOrt.Text = ort.ToString();
            if (ort>=50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDersAd.SelectedValue.ToString()), int.Parse(TxtOgrid.Text), byte.Parse(TxtS1.Text), byte.Parse(TxtS2.Text), byte.Parse(TxtS3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrt.Text), bool.Parse(TxtDurum.Text),notid);
        }
    }
}
