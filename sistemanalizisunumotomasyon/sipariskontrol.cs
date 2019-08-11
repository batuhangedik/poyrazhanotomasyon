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
    public partial class sipariskontrol : Form
    {
        public sipariskontrol()
        {
            InitializeComponent();
        }
        database db = new database();
        private void button3_Click(object sender, EventArgs e)
        {

        }
        int a=0;
        private void sipariskontrol_Load(object sender, EventArgs e)
        {
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from satis_siparisi", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
            
            string sorgu = "Select * from satis_siparisi where siparis_durum_id Like '" + 8 + "'";
            MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
            DataSet ds = new DataSet();
            adap.Fill(ds, "uyekaydi");
            this.dataGridView1.DataSource = ds.Tables[0];
            db.connection.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)

            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
               


            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text == "%1" || comboBox2.Text == "%2" || comboBox2.Text == "%3" || comboBox2.Text == "%4" || comboBox2.Text == "%5" || comboBox2.Text == "%6" || comboBox2.Text == "%7")
            {

                db.connection.Open();
                MySqlDataAdapter list1 = new MySqlDataAdapter("update satis_siparisi set siparis_durum_id='" + 9 + "' where siparis_id ='" + textBox1.Text + "'", db.connection);
                DataTable read1 = new DataTable();
                list1.Fill(read1);
                dataGridView1.DataSource = read1;
                db.connection.Close();
                MessageBox.Show(db.control());
                string sorgu = "Select * from satis_siparisi where siparis_durum_id Like '" + 8 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView1.DataSource = ds.Tables[0];
                db.connection.Close();
                
            }
            else
            {
 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris girisac = new giris();
            girisac.Show();
            this.Close();
        }
    }
}
