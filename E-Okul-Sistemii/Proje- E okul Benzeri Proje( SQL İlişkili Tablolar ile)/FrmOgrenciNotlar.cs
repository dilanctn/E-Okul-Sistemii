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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-7C53G4M\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3, PROJE,ORTALAMA,DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID = @p1",baglantı);
            //yukarıdaki query dizininde dersad a tblnotlar tablosundan ulaşamadığımız için ınner joın ile ilşki kurmamız gerekti. dersad verisine tbldersler tablosundaki anahtar kelime olan dersıd ile ilişkilendirip kullanılabilir hale getirdik.
            komut.Parameters.AddWithValue("@p1", numara);
            this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
