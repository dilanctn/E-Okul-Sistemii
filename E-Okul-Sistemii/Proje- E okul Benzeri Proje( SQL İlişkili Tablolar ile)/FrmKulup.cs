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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-7C53G4M\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");

        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLKULUPLER", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLKULUPLER (KULUPAD) VALUES (@P1)",baglantı);
            komut.Parameters.AddWithValue("@P1",TxtKulüpAd.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulüpid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulüpAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM TBLKULUPLER WHERE KULUPID=@P1",baglantı);
            komut.Parameters.AddWithValue("@P1", TxtKulüpid.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulüp Kaydı Başarıyla Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Update TBLKULUPLER SET KULUPAD=@P1 WHERE KULUPID=@P2", baglantı);
            komut.Parameters.AddWithValue("@P1", TxtKulüpAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKulüpid.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kulüp Kaydı Başarıyla Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }
    }
}
