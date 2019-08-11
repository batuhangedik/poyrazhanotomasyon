using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sistemanalizisunumotomasyon
{
    public partial class depogiris : Form
    {
        public depogiris()
        {
            InitializeComponent();
        }

        private void yuvarlakButon1_Click(object sender, EventArgs e)
        {
            Stok_Kontrolu stokkontrolac = new Stok_Kontrolu();
            stokkontrolac.stokkontrolyetki = depoyetkiyetki;
            stokkontrolac.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            giris girisac = new giris();
            girisac.Visible = true;
        }
        private void yuvarlakButon2_Click(object sender, EventArgs e)
        {

        }
        public int depoyetkiyetki;
        private void depogiris_Load(object sender, EventArgs e)
        {
            
        }
    }
}
