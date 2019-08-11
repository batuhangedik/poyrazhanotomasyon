using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
    
namespace sistemanalizisunumotomasyon
{
    public partial class yonetici : Form
    {
        public yonetici()
        {
            InitializeComponent();
        }
        public int yöneticiyetki;
        private void yonetici_Load(object sender, EventArgs e)
        {
            yöneticiyetki = 1;
        }
        private void yuvarlakButon1_Click(object sender, EventArgs e)
        {
            Sipariş_Takibi satıssiparisi = new Sipariş_Takibi();
            satıssiparisi.Show();
            this.Visible = false;
        }
        private void yuvarlakButon1_MouseMove(object sender, MouseEventArgs e)
        {
            yuvarlakButon1.ForeColor = Color.Black;
            yuvarlakButon1.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }
        private void yuvarlakButon1_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon1.ForeColor = Color.White;
            yuvarlakButon1.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }
        private void yuvarlakButon2_Click(object sender, EventArgs e)
        {
            Musteri musterıac = new Musteri();
            musterıac.Show();
            this.Visible = false;
        }
        private void yuvarlakButon2_MouseMove(object sender, MouseEventArgs e)
        {
            yuvarlakButon2.ForeColor = Color.Black;
            yuvarlakButon2.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }

        private void yuvarlakButon2_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon2.ForeColor = Color.White;
            yuvarlakButon2.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }
        private void yuvarlakButon3_Click(object sender, EventArgs e)
        {
            ürünler ürünlerac = new ürünler();
            ürünlerac.Show();
            this.Visible = false;
        }
        private void yuvarlakButon3_MouseMove(object sender, MouseEventArgs e)
        {
            yuvarlakButon3.ForeColor = Color.Black;
            yuvarlakButon3.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }

        private void yuvarlakButon3_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon3.ForeColor = Color.White;
            yuvarlakButon3.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }

        private void yuvarlakButon4_Click(object sender, EventArgs e)
        {
            Hammaddesiparisiver hammaddesiparisac = new Hammaddesiparisiver();
            hammaddesiparisac.Show();
            this.Visible = false;
        }
        private void yuvarlakButon4_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon4.ForeColor = Color.White;
            yuvarlakButon4.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }

        private void yuvarlakButon4_MouseMove(object sender, MouseEventArgs e)
        {
            yuvarlakButon4.ForeColor = Color.Black;
            yuvarlakButon4.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }

        private void yuvarlakButon5_Click(object sender, EventArgs e)
        {
            Tedarikci tedarikciac = new Tedarikci();
            tedarikciac.Show();
            this.Visible = false;
        }
        private void yuvarlakButon5_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon5.ForeColor = Color.White;
            yuvarlakButon5.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }

        private void yuvarlakButon5_MouseMove(object sender, MouseEventArgs e)
        {
            yuvarlakButon5.ForeColor = Color.Black;
            yuvarlakButon5.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }
        private void yuvarlakButon6_Click(object sender, EventArgs e)
        {
            hammadde hammaddeac = new hammadde();
            hammaddeac.Show();
            this.Visible = false;
        }
        private void yuvarlakButon6_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon6.ForeColor = Color.White;
            yuvarlakButon6.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }
        private void yuvarlakButon6_MouseMove_1(object sender, MouseEventArgs e)
        {
            yuvarlakButon6.ForeColor = Color.Black;
            yuvarlakButon6.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }
        private void yuvarlakButon7_Click(object sender, EventArgs e)
        {
            kullanıcısec kultipsec = new kullanıcısec();
            kultipsec.Show();
            this.Visible = false;
        }
        private void yuvarlakButon7_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon7.ForeColor = Color.White;
            yuvarlakButon7.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }

        private void yuvarlakButon7_MouseMove(object sender, MouseEventArgs e)
        {
            yuvarlakButon7.ForeColor = Color.Black;
            yuvarlakButon7.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }

        private void yuvarlakButon8_Click(object sender, EventArgs e)
        {
            Stok_Kontrolu stokkontrolac = new Stok_Kontrolu();
            stokkontrolac.stokkontrolyetki = yöneticiyetki;
            stokkontrolac.Show();
            this.Visible = false;
        }
        private void yuvarlakButon8_MouseMove(object sender, MouseEventArgs e)
        {

            yuvarlakButon8.ForeColor = Color.Black;
            yuvarlakButon8.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }

        private void yuvarlakButon8_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon8.ForeColor = Color.White;
            yuvarlakButon8.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }

        private void yuvarlakButon9_Click(object sender, EventArgs e)
        {
            GelirGiderRapor gelirgiderac = new GelirGiderRapor();
            gelirgiderac.Show();
            this.Close();
        }

        private void yuvarlakButon9_MouseLeave(object sender, EventArgs e)
        {
            yuvarlakButon9.ForeColor = Color.White;
            yuvarlakButon9.Font = new Font(yuvarlakButon1.Font.FontFamily, 11);
        }

        private void yuvarlakButon9_MouseMove(object sender, MouseEventArgs e)
        {
            yuvarlakButon9.ForeColor = Color.Black;
            yuvarlakButon9.Font = new Font(yuvarlakButon1.Font.FontFamily, 15);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            giris girisac = new giris();
            girisac.Visible = true;
        }

        
        

        

        

        
        
    }
}
