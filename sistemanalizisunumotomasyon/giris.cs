using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.OleDb;
namespace sistemanalizisunumotomasyon
{
    public partial class giris : Form
    {

        public giris()
        {
            InitializeComponent();
        }
        database db = new database();

         
        private void giris_Load(object sender, EventArgs e)
        {

            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Yönetici")
            {
                MySqlDataAdapter list = new MySqlDataAdapter("select * from yonetici", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (textBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString() && textBox2.Text == dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {
                        yonetici yoneticiac = new yonetici();
                        yoneticiac.yöneticiyetki = yetki;
                        yoneticiac.Show();
                        this.Visible = false;

                    }

                }
            }
                if (comboBox1.Text == "Üretim Departmanı")
                {

                    MySqlDataAdapter list2 = new MySqlDataAdapter("select * from uretimdepartmani", db.connection);
                    DataTable read2 = new DataTable();
                    list2.Fill(read2);
                    dataGridView1.DataSource = read2;
                    db.connection.Close();
                    MessageBox.Show("sad");
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (textBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString() && textBox2.Text == dataGridView1.Rows[i].Cells[2].Value.ToString())
                        {
                            üretimeyibekleyensiparişler üretimac = new üretimeyibekleyensiparişler();
                            üretimac.Show();
                            this.Visible=false;
                            
                        }
                    }
                }
                if (comboBox1.Text == "Depo Yönetimi")
                {

                    MySqlDataAdapter list2 = new MySqlDataAdapter("select * from depoyonetimi", db.connection);
                    DataTable read2 = new DataTable();
                    list2.Fill(read2);
                    dataGridView1.DataSource = read2;
                    db.connection.Close();
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (textBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString() && textBox2.Text == dataGridView1.Rows[i].Cells[2].Value.ToString())
                        {
                            Stok_Kontrolu stokkontrolac = new Stok_Kontrolu();
                            stokkontrolac.Show();
                            stokkontrolac.stokkontrolyetki = yetki;
                            this.Visible = false;

                        }
                    }
                }
                if (comboBox1.Text == "Kalite Kontrol")
                {
                    MySqlDataAdapter list2 = new MySqlDataAdapter("select * from kalite_kontrol", db.connection);
                    DataTable read2 = new DataTable();
                    list2.Fill(read2);
                    dataGridView1.DataSource = read2;
                    db.connection.Close();
                    MessageBox.Show("sad");
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (textBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString() && textBox2.Text == dataGridView1.Rows[i].Cells[1].Value.ToString())
                        {
                            sipariskontrol siparsikontrolac = new sipariskontrol();
                            siparsikontrolac.Show();
                            this.Visible = false;

                        }
                    }
                }
                giris girisac = new giris();
                girisac.Hide();

            
        }   
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
        private void textBox2_MouseClick_1(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }
        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.ForeColor = Color.Black;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("POYRAZHAN TEKSTİL A.Ş \n\nwww.cmf.nkü.edu.tr \n \nİletişim = 0534 *** ** ** \n \nMail: cmf.edu.tr@gmail.com", 
                    "DESTEK",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
        public int yetki;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Yönetici")
            {
                yetki = 1;
            }
            if (comboBox1.Text == "Üretim Departmanı")
            {
                yetki = 2;
            }
            if (comboBox1.Text == "Depo Yönetimi")
            {
                yetki = 3;

            }
            if (comboBox1.Text == "Kalite Kontrol")
            {
                yetki = 4;
            }
            giris girisac = new giris();
            girisac.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Şifreniz Adınızın İlk Harfi + TC No ilk 4 sayısının birleşiminden oluşmuştur \n\n Örnek \n İsim : Hüseyin \n TC No : 41630068940 \n Şifre : H4163","BİLGİ",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}
