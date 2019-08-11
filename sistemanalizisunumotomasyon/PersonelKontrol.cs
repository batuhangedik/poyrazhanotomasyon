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
    public partial class PersonelKontrol : Form
    {
        public PersonelKontrol()
        {
            InitializeComponent();
        }
        database db = new database();
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            yonetici yöneticiac = new yonetici();
            yöneticiac.Show();
            this.Close();
        }

        private void PersonelKontrol_Load(object sender, EventArgs e)
        {
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from departman", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView2.DataSource = read;
            db.connection.Close();

            
            MySqlDataAdapter list1 = new MySqlDataAdapter("select * from kullanici", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView1.DataSource = read1;
            db.connection.Close();
            for (int i = 0; i < 4; i++)
            {
                comboBox1.Items.Add(dataGridView2.Rows[i].Cells[1].Value).ToString();
            }
        }
        int id = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            int depıd=0;
            if (comboBox1.Text == "Yönetici")
            {
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    id = Convert.ToInt32( dataGridView1.Rows[i].Cells[0].Value);
                    
                }
                id++;
            }
            MySqlCommand add = new MySqlCommand("insert into kullanici(kullanici_id,isim_soyisim,tc_no,cep_no,sifre,baslangic,departman_id,maas,adres) VALUES('" + id + "','" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + 1 + "', '" + depıd + "', '" + comboBox1.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "')", db.connection);
           
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
                label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
                label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select * from kullanici", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Hepsi")
            {
                MySqlDataAdapter list = new MySqlDataAdapter("select * from kullanici", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            }
            else if (comboBox2.Text == "ID")
            {
                string deger = textBox7.Text;
                string sorgu = "Select * from kullanici where kullanici_id Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox2.Text == "Ad")
            {
                string deger = textBox7.Text;
                string sorgu = "Select * from kullanici where isim_soyisim Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox2.Text == "TC")
            {
                string deger = textBox7.Text;
                string sorgu = "Select * from kullanici where tc_no Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox2.Text == "Cep")
            {
                string deger = textBox7.Text;
                string sorgu = "Select * from kullanici where cep_no Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox2.Text == "Departman")
            {
                string deger = textBox7.Text;
                string sorgu = "Select * from kullanici where departman_id Like '" + deger + "'";
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
                    string sql = "DELETE FROM kullanici WHERE kullanici_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("kullanici_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from kullanici", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }
        }
    }
}
