using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje__E_okul_Benzeri_Proje__SQL_İlişkili_Tablolar_ile_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar fr = new FrmOgrenciNotlar();
            fr.numara = textBox1.Text;
            fr.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen FR = new FrmOgretmen();
            FR.Show();
            this.Hide();
        }
    }
}
