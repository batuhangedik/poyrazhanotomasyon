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
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }
        database db = new database();
        private void Musteri_Load(object sender, EventArgs e)
        {
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from musteriler", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            yonetici yöneticiac = new yonetici();
            yöneticiac.Show();
            this.Close();
        }
        int ıd = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand add = new MySqlCommand("insert into musteriler(musteri_id,firma_ad,firma_tel,firma_fax,firma_mail,firma_adres) VALUES('" + ıd + "','" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox3.Text + "')", db.connection);
            ıd = ıd + 1;
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
                label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
                label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select * from musteriler", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Hepsi")
            {

                MySqlDataAdapter list = new MySqlDataAdapter("select * from musteriler", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            }
            else if (comboBox1.Text == "Firma Adı")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from musteriler where firma_ad Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Fax")
            {
                int deger2 = Convert.ToInt32(textBox6.Text);
                string sorgu = "Select * from musteriler where firma_fax Like '" + deger2 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Tel")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from musteriler where firma_tel Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Firma ID")
            {
                int deger2 = Convert.ToInt32(textBox6.Text);
                string sorgu = "Select * from musteriler where musteri_id Like '" + deger2 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Bilgileri Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM musteriler WHERE musteri_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("musteri_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from musteriler", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            musteriguncelle musteriguncelleac = new musteriguncelle();
            musteriguncelleac.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter list = new MySqlDataAdapter("select * from musteriler", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }
    }
}
