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
    public partial class siparisgüncelle : Form
    {
        public siparisgüncelle()
        {
            InitializeComponent();
        }
        database db = new database();
        private void button1_Click(object sender, EventArgs e)
        {
            üretimeyibekleyensiparişler üretimbekleyenac = new üretimeyibekleyensiparişler();
            üretimbekleyenac.Show();
            Application.Exit();
        }
        public int a;
        private void siparisgüncelle_Load(object sender, EventArgs e)
        {
            üretimeyibekleyensiparişler üretimbekleyenac = new üretimeyibekleyensiparişler();
            textBox1.Text = a.ToString();
            
            MySqlDataAdapter list = new MySqlDataAdapter("select * from satis_siparisi", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            üretimeyibekleyensiparişler üretimbekleyenac = new üretimeyibekleyensiparişler();
            üretimbekleyenac.gelendurum =Convert.ToInt32( comboBox1.Text);
            üretimbekleyenac.a.Start();
            MySqlDataAdapter list1 = new MySqlDataAdapter("update satis_siparisi set siparis_durum_id='" + comboBox1.Text + "' where siparis_id ='" + a + "'", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView1.DataSource = read1;
            db.connection.Close();
            this.Close();
        }
    }
}
