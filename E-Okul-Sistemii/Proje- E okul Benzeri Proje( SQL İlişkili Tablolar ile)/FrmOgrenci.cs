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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-7C53G4M\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");//kulüp formundan aldık
        

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulupAd.DisplayMember = "KULUPAD";
            cmbKulupAd.ValueMember = "KULUPID";
            cmbKulupAd.DataSource = dt;
            baglantı.Close();

        }
        string cınsıyet = "";

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked==true)
            {
                cınsıyet = "KIZ";
            }
            if (radioButton2.Checked==true)
            {
                cınsıyet = "ERKEK";
            }
            ds.OgrenciEkle(TxtOgrAd.Text, TxtOgrSoyad.Text, byte.Parse(cmbKulupAd.SelectedValue.ToString()), cınsıyet);
            MessageBox.Show("Öğrenci Ekleme İşlemi Tamamlandı");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void cmbKulupAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtOgrid.Text = cmbKulupAd.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrid.Text));
            MessageBox.Show("Kayıt başarı ile silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()=="KIZ" || dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kız")
            {
                radioButton1.Checked = true;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "ERKEK" || dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Erkek")
            {
                radioButton2.Checked = true;
            }
            cmbKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
           
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrAd.Text, TxtOgrSoyad.Text, byte.Parse(cmbKulupAd.SelectedValue.ToString()), cınsıyet, int.Parse(TxtOgrid.Text));
            MessageBox.Show("Bilgiler Başarıyla Güncellendi");
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                cınsıyet = "KIZ";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                cınsıyet = "ERKEK";
            }
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciGetir(TxtAdaGoreBul.Text);
            

        }
    }
}
