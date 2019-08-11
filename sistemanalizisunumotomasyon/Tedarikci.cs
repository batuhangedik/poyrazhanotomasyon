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
    public partial class Tedarikci : Form
    {
        public Tedarikci()
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
        private void Tedarikci_Load(object sender, EventArgs e)
        {
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from tedarikciler", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }
        int id = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int depıd=0;
            
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    id = Convert.ToInt32( dataGridView1.Rows[i].Cells[0].Value);
                    
                }
                id++;
            MySqlCommand add = new MySqlCommand("insert into tedarikciler(tedarikci_id,firma_ad,firma_tel,firma_fax,firma_mail,firma_adres) VALUES('" + id + "','" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox3.Text + "')", db.connection);
            
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
                label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
                label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select * from tedarikciler", db.connection);
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

                MySqlDataAdapter list = new MySqlDataAdapter("select * from tedarikciler", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
            }
            else if (comboBox1.Text == "ID")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from tedarikciler where tedarikci_id Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Ad")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from tedarikciler where firma_ad Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Tel")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from tedarikciler where firma_tel Like '" + deger + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
            }
            else if (comboBox1.Text == "Fax")
            {
                string deger = textBox6.Text;
                string sorgu = "Select * from tedarikciler where firma_fax Like '" + deger + "'";
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
            cikis = MessageBox.Show("Seçili Firmayı Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM tedarikciler WHERE tedarikci_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("tedarikci_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from tedarikciler", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }
        }
    }
}
