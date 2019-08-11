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
    public partial class yoneticieklesil : Form
    {
        public yoneticieklesil()
        {
            InitializeComponent();
        }
        database db = new database();
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string tcdort =txt_tx_no.Text;
            string kullanıcısifre = ad[0] + "" + tcdort[0] + "" + tcdort[1] + "" + tcdort[2] + "" + tcdort[3];

              MySqlCommand add = new MySqlCommand("insert into yonetici(isim_soyisim,sifre,cep_no,maas,tc_no) VALUES('" + textBox1.Text + "', '" + kullanıcısifre + "', '" + textBox3.Text + "','"+ txt_maas.Text + "','"+txt_tx_no.Text+"')", db.connection);
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
            { }//label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
            { } //label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select yonetici_id,isim_soyisim,sifre,cep_no,maas,tc_no from yonetici", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yonetici_guncelle gncsec = new yonetici_guncelle();
            gncsec.Show();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter list = new MySqlDataAdapter("select yonetici_id,isim_soyisim,sifre,cep_no,maas,tc_no from yonetici", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }

        private void yoneticieklesil_Load(object sender, EventArgs e)
        {
            


            //okuma
            
            //db.connection.Open();
            MySqlDataAdapter list = new MySqlDataAdapter("select yonetici_id,isim_soyisim,sifre,cep_no,maas,tc_no from yonetici", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Ürünü Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM yonetici WHERE yonetici_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("yonetici_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from yonetici", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                    //tekrar çekme

                }
            }
        }
    }
}
