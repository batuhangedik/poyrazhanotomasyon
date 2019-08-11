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
    public partial class uretimekle : Form
    {
        public uretimekle()
        {
            InitializeComponent();
        }
        database db = new database();


        private void uretimekle_Load(object sender, EventArgs e)
        {
            //baglanti

            if (db.control() == "true")
                label1.Text = "connected";
            else
                MessageBox.Show(db.control());
            #region veriçekme
            //db.connection.Open();
            MySqlDataAdapter list = new MySqlDataAdapter("select uretim_departman_id,isim_soyisim,sifre,cep_no,maas,tc_no from uretimdepartmani", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();

            #endregion
        }

        #region ekle
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand add = new MySqlCommand("insert into uretimdepartmani(isim_soyisim,sifre,cep_no,maas,tc_no) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "','" + txt_maas.Text + "','" + txt_tx_no.Text + "')", db.connection);
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
                label2.Text = "Kullanici Başarıyla Eklenmiştir";
            else
                label2.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select uretim_departman_id,isim_soyisim,sifre,cep_no,maas,tc_no from uretimdepartmani", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();

        }
        #endregion

        #region sil
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Ürünü Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM uretimdepartmani WHERE uretim_departman_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("uretim_departman_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from uretimdepartmani", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                    //tekrar çekme

                }
            }
        }
        #endregion

        #region guncelleye gec
        private void button3_Click(object sender, EventArgs e)
        {
            uretimguncelle uretgnc = new uretimguncelle();
            uretgnc.Show();
        }
        #endregion
        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
            MySqlDataAdapter list = new MySqlDataAdapter("select uretim_departman_id,isim_soyisim,sifre,cep_no,maas,tc_no from uretimdepartmani", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }


    }
}
