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
    public partial class depoekle : Form
    {
        public depoekle()
        {
            InitializeComponent();
        }
        database db = new database();
        private void depoekle_Load(object sender, EventArgs e)
        {
            
            #region veriçekme
            //db.connection.Open();
            MySqlDataAdapter list = new MySqlDataAdapter("select depo_yonetimi_id,isim_soyisim,sifre,cep_no,maas,tc_no from depoyonetimi", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
            db.connection.Close();
            #endregion

        }


        #region ekle
        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlCommand add = new MySqlCommand("insert into depoyonetimi(isim_soyisim,sifre,cep_no,maas,tc_no) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "','" + txt_maas.Text + "','" + txt_tx_no.Text + "')", db.connection);
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
            { }//label10.Text = "Kullanici Başarıyla Eklenmiştir";
            else
            { } //label10.Text = "Kullanici Malesef Eklenemedi.Hata Numarasi(1)";
            MySqlDataAdapter list = new MySqlDataAdapter("select * from depoyonetimi", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();

        }
        #endregion
        #region sil
        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Ürünü Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM depoyonetimi WHERE depo_yonetimi_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("depo_yonetimi_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from depoyonetimi", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                    //tekrar çekme

                }
            }
        }
        #endregion
        #region guncelleye geç
        private void button4_Click(object sender, EventArgs e)
        {
            // db.connection.Open();
            // MySqlCommand dnl = new MySqlCommand("update user set firstname = '" +textBox5 + "' where id = '" +textBox9 + "'", db.connection);

            // if (dnl.ExecuteNonQuery() == 1)
            // {
            //     label4.Text = "Kullanıcı Bilgileri Başarıyla Güncellenmiştir.";
            // }
            // else
            // {
            //     label4.Text = "Kullanıcı Bilgileri Malesef Güncellenemedi(Hata kodu 1)";
            // }
            //db.connection.Close();

            depoguncelle depognc = new depoguncelle();
            depognc.Show();

            //this.Hide();


        }
        #endregion
        #region refresh
        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
            MySqlDataAdapter list = new MySqlDataAdapter("select depo_yonetimi_id,isim_soyisim,sifre,cep_no,maas,tc_no from depoyonetimi", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();

        }




        #endregion


    }
}
