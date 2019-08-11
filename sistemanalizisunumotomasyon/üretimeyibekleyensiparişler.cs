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
    public partial class üretimeyibekleyensiparişler : Form
    {
        public üretimeyibekleyensiparişler()
        {
            InitializeComponent();
        }
        siparisgüncelle siparisgüncelleac = new siparisgüncelle();
        private void button2_Click(object sender, EventArgs e)
        {

        }
        database db = new database();
        
        private void üretimeyibekleyensiparişler_Load(object sender, EventArgs e)
        {
            
            string sorgu = "Select * from satis_siparisi where siparis_durum_id != '" + 8 + "' && siparis_durum_id != '" + 9 + "' && siparis_durum_id != '" + 10 + "' && siparis_durum_id != '" + 11 + "'  ";
            MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
            DataSet ds = new DataSet();
            adap.Fill(ds, "uyekaydi");
            this.dataGridView1.DataSource = ds.Tables[0];
            db.connection.Close();
            db.connection.Close();
            MySqlDataAdapter list1 = new MySqlDataAdapter("select * from hm_talep", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView2.DataSource = read1;
            db.connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            giris girisac=new giris();
            girisac.Show();
            this.Close();
        }
      public  int gelendurum = 0;
        private void button2_Click_1(object sender, EventArgs e)
      {

      }
        private void button2_Click_2(object sender, EventArgs e)
        {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                a.Interval = 500;
                a.Start();
                siparisgüncelle siparisgüncelleac = new siparisgüncelle();
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                   siparisgüncelleac.a = numara;
                siparisgüncelleac.Show();
                
            }
        }
        int tid ;
        private void button4_Click(object sender, EventArgs e)
        {
                
            if (dataGridView2.RowCount != 0)
            {
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    tid = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value);

                }
                tid++;
                
            }
            else
                tid = 0;

            MySqlCommand add = new MySqlCommand("insert into hm_talep(talep_id,hm_ad,cins,renk,miktar,tarih) VALUES('" + tid + "', '" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox3.Text + "')", db.connection);
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
                MessageBox.Show("Talep Başarılı");
            else
                MessageBox.Show("Talep Başarısız") ;
            db.connection.Close();
        }

        sipariskontrol sipariskontrolac = new sipariskontrol();
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        public Timer a = new Timer();
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sorgu = "Select * from satis_siparisi where siparis_durum_id != '" + 8 + "' && siparis_durum_id != '" + 9 + "' && siparis_durum_id != '" + 10 + "' && siparis_durum_id != '" + 11 + "'  ";
            MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
            DataSet ds = new DataSet();
            adap.Fill(ds, "uyekaydi");
            this.dataGridView1.DataSource = ds.Tables[0];
            db.connection.Close();
            db.connection.Close();
            MySqlDataAdapter list1 = new MySqlDataAdapter("select * from hm_talep", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView2.DataSource = read1;
            db.connection.Close();
        }
    }
}
