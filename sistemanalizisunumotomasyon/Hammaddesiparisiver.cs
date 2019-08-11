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
    public partial class Hammaddesiparisiver : Form
    {
        public Hammaddesiparisiver()
        {
            InitializeComponent();
        }
        database db = new database();
        private void Hammaddesiparisiver_Load(object sender, EventArgs e)
        {
           
            MySqlDataAdapter list = new MySqlDataAdapter("select * from tedarikciler", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView2.DataSource = read;
            db.connection.Close();
            comboBox2.Items.Add(dataGridView2.Rows[0].Cells[1].Value);
           
            MySqlDataAdapter list1 = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView1.DataSource = read1;
            db.connection.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            yonetici yöneticiac = new yonetici();
            yöneticiac.Show();
            this.Close();
        }
        int id = 1;
        private void button6_Click(object sender, EventArgs e)
        {
            
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    id = Convert.ToInt32( dataGridView1.Rows[i].Cells[0].Value);
                    
                }
                id++;
            MySqlCommand add = new MySqlCommand("insert into hm_siparisleri(hm_siparis_id,tedarikci_id,hm_adi,cins,renk,birim,birim_fiyat,miktar,siparis_tarihi) VALUES('" + id + "', '" + 1 + "','" + textBox7.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox1.Text + "', '" + textBox9.Text + "', '" + textBox5.Text + "', '" + textBox3.Text + "')", db.connection);
            db.connection.Open();
                if (add.ExecuteNonQuery() == 1)
                label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
                label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Hepsi")
            {
                MySqlDataAdapter list = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            }
            else if (comboBox1.Text == "Siparis ID")
            {
                string deger = textBox8.Text;
                string sorgu = "Select * from hm_siparisleri where hm_siparis_id Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Tedarikci ID")
            {
                int deger2 = Convert.ToInt32(textBox8.Text);
                string sorgu = "Select * from hm_siparisleri where tedarikci_id Like '" + deger2 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "HM Ad")
            {
                string deger = textBox8.Text;
                string sorgu = "Select * from hm_siparisleri where hm_adi Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Cins")
            {
                string deger = textBox8.Text;
                string sorgu = "Select * from hm_siparisleri where cins Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Ürünü Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM hm_siparisleri WHERE hm_siparis_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("hm_siparis_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }
            
        }
    }
}
