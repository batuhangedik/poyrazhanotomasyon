using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemanalizisunumotomasyon
{
    public partial class kullanıcısec : Form
    {
        public kullanıcısec()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yoneticieklesil yoneticisec = new yoneticieklesil();
            yoneticisec.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            depoekle deposec = new depoekle();
            deposec.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kalitekontrolekle kalitesec = new kalitekontrolekle();
            kalitesec.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uretimekle uretimekle = new uretimekle();
            uretimekle.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            yonetici yoneticiac = new yonetici();
            yoneticiac.Show();
            this.Close();
        }
    }
}
