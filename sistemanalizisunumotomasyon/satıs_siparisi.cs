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
using System.Data.Sql;
namespace sistemanalizisunumotomasyon
{
    public partial class Sipariş_Takibi : Form
    {
        public Sipariş_Takibi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        database db = new database();
        private void Sipariş_Takibi_Load(object sender, EventArgs e)
        {
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from satislar", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView2.DataSource = read;
            db.connection.Close();

            string sorgu = "Select * from satis_siparisi where siparis_durum_id != '" + 8 + "' && siparis_durum_id != '" + 9 + "' && siparis_durum_id != '" + 10 + "' && siparis_durum_id != '" + 11 + "'  ";
            MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
            DataSet ds = new DataSet();
            adap.Fill(ds, "uyekaydi");
            this.dataGridView1.DataSource = ds.Tables[0];
            db.connection.Close();
            
           
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            yonetici yöneticiac = new yonetici();
            yöneticiac.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int sid = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            int depıd = 0;
            
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    sid = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);

                }
                sid++;
            
            MySqlCommand add = new MySqlCommand("insert into satıs_siparisi(siparis_id,musteri_id,urun_adi,cins,renk,boy_en,urun_birimi,urun_miktari,urun_birim_fiyat,siparis_tarihi,siparis_durum_id) VALUES('" + sid + "', '" + 1 + "','" + textBox7.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox1.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + 1 + "')", db.connection);
                db.connection.Open();
                if (add.ExecuteNonQuery() == 1)
                    label2.Text = "Kullanici Başarıyla Eklenmiştir";
                else
                    label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
                MySqlDataAdapter list = new MySqlDataAdapter("select * from satıs_siparisi", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Hepsi")
            {
                MySqlDataAdapter list = new MySqlDataAdapter("select * from satıs_siparisi", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            }
            else if (comboBox1.Text == "ID")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from satıs_siparisi where siparis_id Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Musteri ID")
            {
                int deger2 = Convert.ToInt32(textBox6.Text);
                string sorgu = "Select * from satıs_siparisi where musteri_id Like '" + deger2 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Ürün Adı")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from satıs_siparisi where urun_adı Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Ürün Cinsi")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from satıs_siparisi where cinsi Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Ürünü Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM satis_siparisi WHERE siparis_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("siparis_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from satis_siparisi", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
