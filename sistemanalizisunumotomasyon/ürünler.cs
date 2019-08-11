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
    public partial class ürünler : Form
    {
        public ürünler()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            yonetici yöneticiac = new yonetici();
            yöneticiac.Show();
            this.Close();
        }

        database db = new database();
        private void ürünler_Load(object sender, EventArgs e)
        {
            
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from urunler", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }
        int ıd = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            int depıd=0;
            
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    ıd = Convert.ToInt32( dataGridView1.Rows[i].Cells[0].Value);
                    
                }
                ıd++;
            MySqlCommand add = new MySqlCommand("insert into urunler(urun_ıd,urun_adı,urun_cinsi,renk,birim,birim_fiyat) VALUES('" + ıd + "','" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox3.Text + "')", db.connection);
            ıd = ıd + 1;
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
                label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
                label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select * from urunler", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Hepsi")
            {
                MySqlDataAdapter list = new MySqlDataAdapter("select * from urunler", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            }
            else if (comboBox1.Text == "Ürün Adı") 
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from urunler where urun_adı Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Ürün ID")
            {
                int deger2 = Convert.ToInt32(textBox6.Text);
                string sorgu = "Select * from urunler where urun_id Like '" + deger2 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Ürün Adı")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from urunler where urun_ad Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Ürün Cinsi")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from urunler where urun_cinsi Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Hepsi")
            {
                textBox6.Text = "";
                textBox6.Enabled = false;
            }
            else
                textBox6.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {//silme
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Ürünü Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM urunler WHERE urun_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("urun_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from urunler", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
