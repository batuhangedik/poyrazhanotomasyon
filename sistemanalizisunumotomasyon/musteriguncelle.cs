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
    public partial class musteriguncelle : Form
    {
        public musteriguncelle()
        {
            InitializeComponent();
        }
        database db = new database();
        private void musteriguncelle_Load(object sender, EventArgs e)
        {

        }

        //ara
        private void button2_Click_1(object sender, EventArgs e)
        {
            db.connection.Open();
            string query_Ara = "Select * from musteriler where musteri_id=@musteri_id";//yonetici_id sine göre veri geliyor.
            MySqlCommand cmd = new MySqlCommand(query_Ara, db.connection);
            cmd.Parameters.AddWithValue("@musteri_id", textBox6.Text);
            //MID parametremize textbox'dan girilen değer geliyor.
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {//formdaki textboxlara, datareader ile gelen verileri aktardık.
                textBox6.Text = dr["musteri_id"].ToString();
                textBox1.Text = dr["firma_adi"].ToString();
                textBox2.Text = dr["firma_tel"].ToString();
                textBox3.Text = dr["firma_adres"].ToString();
                textBox4.Text = dr["firma_fax"].ToString();
                textBox5.Text = dr["firma_mail"].ToString();

            }
            else
                MessageBox.Show("Bu Numarada Bir kullanıcı Bulunamadı.");
            db.connection.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //guncelle
            db.connection.Open(); //Müşteri ID'si ile çektiğimiz veriyi güncelliyoruz.
            string query_Güncelle = "Update musteriler set firma_adi=@textBox1,firma_tel=@textBox2,firma_adres=@textBox3,firma_fax=@textBox4,firma_mail=@textBox5 where  musteri_id=@musteri_id";
            MySqlCommand cmd = new MySqlCommand(query_Güncelle, db.connection);
            cmd.Parameters.AddWithValue("@musteri_id", Convert.ToInt32(textBox6.Text.ToString()));
            cmd.Parameters.AddWithValue("@textBox1", textBox1.Text);
            cmd.Parameters.AddWithValue("@textBox2", textBox2.Text);
            cmd.Parameters.AddWithValue("@textBox3", textBox3.Text);
            cmd.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd.Parameters.AddWithValue("@textBox5", textBox5.Text);

            cmd.ExecuteNonQuery();
            db.connection.Close();
            MessageBox.Show("Bilgiler Güncellendi");
            this.Close();
        }

       
        
    }
}
