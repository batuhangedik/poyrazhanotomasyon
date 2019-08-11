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
    public partial class Stok_Kontrolu : Form
    {
        public Stok_Kontrolu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            Hammaddeİstekleri hammaddesevkac = new Hammaddeİstekleri();
            hammaddesevkac.hmyetki = stokkontrolyetki;
            hammaddesevkac.Show();
        }

        depogiris depogirisyetki = new depogiris();
        
        private void button14_Click(object sender, EventArgs e)
        {
            
            if (stokkontrolyetki == 1)
            {
                yonetici yoneticiac = new yonetici();
                yoneticiac.Show();
                this.Close();
            }
            if (stokkontrolyetki == 3)
            {
                giris girisac = new giris();
                girisac.Show();
                this.Close();
            }
        }
        database db = new database();
        public int stokkontrolyetki ;
        private void Stok_Kontrolu_Load(object sender, EventArgs e)
        {
                
                MySqlDataAdapter list = new MySqlDataAdapter("select * from hm_stok", db.connection);
                DataTable read = new DataTable();
                list.Fill(read);
                dataGridView1.DataSource = read;
                db.connection.Close();
                
                MySqlDataAdapter list1 = new MySqlDataAdapter("select * from satıs_siparisi", db.connection);
                DataTable read1 = new DataTable();
                list1.Fill(read1);
                dataGridView2.DataSource = read1;
                db.connection.Close();
                string sorgu = "Select * from satis_siparisi where siparis_durum_id Like '" + 10 + "'";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView2.DataSource = ds.Tables[0];
                db.connection.Close();
            


        }
        private void button4_Click(object sender, EventArgs e)
        {
            Hammaddesiparisleri hammaddesiparisiac = new Hammaddesiparisleri();
            hammaddesiparisiac.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ürünstokekle ürünstokekleac = new ürünstokekle();
            ürünstokekleac.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Ürünü Sevk Etmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView2.SelectedRows)  //Seçili Satırları Silme
                {
                    MessageBox.Show("geldi");
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    MySqlDataAdapter list3 = new MySqlDataAdapter("update satis_siparisi set siparis_durum_id='" + 11 + "' where siparis_id ='" + numara + "'", db.connection);
                    DataTable read3 = new DataTable();
                    list3.Fill(read3);
                    dataGridView2.DataSource = read3;
                    db.connection.Close();
                    string sorgu = "Select * from satis_siparisi where siparis_durum_id Like '" + 10 + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                    DataSet ds = new DataSet();
                    adap.Fill(ds, "uyekaydi");
                    this.dataGridView2.DataSource = ds.Tables[0];
                    db.connection.Close();
                }
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {

            MySqlDataAdapter list = new MySqlDataAdapter("select * from hm_stok", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();

            MySqlDataAdapter list1 = new MySqlDataAdapter("select * from satıs_siparisi", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView2.DataSource = read1;
            db.connection.Close();
            string sorgu = "Select * from satis_siparisi where siparis_durum_id Like '" + 10 + "'";
            MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
            DataSet ds = new DataSet();
            adap.Fill(ds, "uyekaydi");
            this.dataGridView2.DataSource = ds.Tables[0];
            db.connection.Close();
        }
    }
}
