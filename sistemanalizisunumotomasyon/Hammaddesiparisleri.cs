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
    public partial class Hammaddesiparisleri : Form
    {
        public Hammaddesiparisleri()
        {
            InitializeComponent();
        }
        database db = new database();
        private void Hammaddesiparisleri_Load(object sender, EventArgs e)
        {

            
            MySqlDataAdapter list1 = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView1.DataSource = read1;
            db.connection.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                string hmmiktar1 = drow.Cells[7].Value.ToString();
                string hmad = drow.Cells[2].Value.ToString();
                string hmcins = drow.Cells[3].Value.ToString();
                string hmrenk = drow.Cells[4].Value.ToString();
                string hmbirim = drow.Cells[5].Value.ToString();
                string hmbirimfiyat = drow.Cells[6].Value.ToString();
                int hmmiktar = Convert.ToInt32(drow.Cells[7].Value.ToString());
                string sorgu = "Select * from hm_stok where hm_ad= '" + hmad + "' || cinsi= '" + hmcins + "' || renk= '" + hmrenk + "' || birim= '" + hmbirim + "' || birim_fiyat= '" + hmbirimfiyat + "' ";
                MySqlDataAdapter adap = new MySqlDataAdapter(sorgu, db.connection);
                DataSet ds = new DataSet();
                adap.Fill(ds, "uyekaydi");
                this.dataGridView2.DataSource = ds.Tables[0];
                db.connection.Close();
                int ilkmiktar = Convert.ToInt32(dataGridView2.Rows[0].Cells[6].Value);
                int sonmiktar = ilkmiktar + hmmiktar;



                string sorgu2 = "update hm_stok set miktar='" + sonmiktar + "' where hm_ad= '" + hmad + "' || cinsi= '" + hmcins + "' || renk= '" + hmrenk + "' || birim= '" + hmbirim + "' || birim_fiyat= '" + hmbirimfiyat + "' ";
                MySqlDataAdapter list1 = new MySqlDataAdapter("update hm_stok set miktar='" + sonmiktar + "' where hm_ad= '" + hmad + "' || cinsi= '" + hmcins + "' || renk= '" + hmrenk + "' || birim= '" + hmbirim + "' || birim_fiyat= '" + hmbirimfiyat + "'", db.connection);
                DataTable read1 = new DataTable();
                list1.Fill(read1);
                dataGridView1.DataSource = read1;
                db.connection.Close();
                db.connection.Open();
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Seçili Ürünü Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

                if (cikis == DialogResult.Yes)
                {
                    foreach (DataGridViewRow drow2 in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                    {
                        int numara = Convert.ToInt32(drow2.Cells[0].Value);
                        string sql = "DELETE FROM hm_siparisleri WHERE hm_siparis_id= '" + numara + "' ";
                        MySqlCommand komut = new MySqlCommand(sql, db.connection);
                        komut.Parameters.AddWithValue("hm_siparis_id", numara);
                        db.connection.Open();
                        komut.ExecuteNonQuery();
                        db.connection.Close();
                        MySqlDataAdapter list2 = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
                        DataTable read2 = new DataTable();
                        list2.Fill(read2);
                        dataGridView1.DataSource = read2;
                        db.connection.Close();
                    }
                }
                //this.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            depogiris depogirisac = new depogiris();
            depogirisac.Show();
            this.Close();
        }
    }

}
