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
    public partial class ürünstokekle : Form
    {
        public ürünstokekle()
        {
            InitializeComponent();
        }
        database db = new database();
        private void ürünstokekle_Load(object sender, EventArgs e)
        {
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from satis_siparisi", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            dataGridView2.DataSource = read;
            db.connection.Close();

            string sorgu = "Select * from satis_siparisi where siparis_durum_id Like '" + 9 + "'";
            MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
            DataSet ds = new DataSet();
            adap.Fill(ds, "uyekaydi");
            this.dataGridView1.DataSource = ds.Tables[0];
            db.connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db.connection.Open();
            MySqlDataAdapter list3 = new MySqlDataAdapter("update satis_siparisi set siparis_durum_id='" + 10 + "' where siparis_id ='" + textBox7.Text + "'", db.connection);
            DataTable read3 = new DataTable();
            list3.Fill(read3);
            dataGridView2.DataSource = read3;
            db.connection.Close();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            textBox9.Enabled = false;
            textBox8.Enabled = false;
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
    }
}
