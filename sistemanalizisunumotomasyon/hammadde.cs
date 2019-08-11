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
    public partial class hammadde : Form
    {
         
        public hammadde()
        {
            InitializeComponent();
        }
        database db = new database();
        private void hammadde_Load(object sender, EventArgs e)
        {
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from hammadde", db.connection);
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
        int ıd = 2;
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand add = new MySqlCommand("insert into hammadde(hm_id,hm_ad,cinsi,renk,birim,birim_fiyat) VALUES('" + ıd + "','" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox3.Text + "')", db.connection);
            ıd = ıd + 1;
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
                label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
                label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select * from hammadde", db.connection);
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

                MySqlDataAdapter list = new MySqlDataAdapter("select * from hammadde", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            }
            else if (comboBox1.Text == "HM İD")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from hammadde where hm_id Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "HM Ad")
            {
                int deger2 = Convert.ToInt32(textBox6.Text);
                string sorgu = "Select * from hammadde where hm_ad Like '" + deger2 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Cinsi")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from hammadde where cinsi Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Renk")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from hammadde where renk Like '" + deger + "'";
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
            cikis = MessageBox.Show("Seçili Hammaddeyi Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM hammadde WHERE hm_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("hm_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from hammadde", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }
        }
    }
}
