﻿using System;
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
    public partial class kaliteguncellecs : Form
    {
        public kaliteguncellecs()
        {
            InitializeComponent();
        }
        database db = new database();
        private void button1_Click(object sender, EventArgs e)
        {
            //guncelle
            db.connection.Open(); //Müşteri ID'si ile çektiğimiz veriyi güncelliyoruz.
            string query_Güncelle = "Update kalite_kontrol set isim_soyisim=@txt_kul_adısoyadı,sifre=@txt_sifre,maas=@txt_maas,tc_no=@txt_tcno,cep_no=@txt_telno where  kalite_kontrol_id=@kalite_kontrol_id";
            MySqlCommand cmd = new MySqlCommand(query_Güncelle, db.connection);
            cmd.Parameters.AddWithValue("@kalite_kontrol_id", Convert.ToInt32(txt_kul_id.Text.ToString()));
            cmd.Parameters.AddWithValue("@txt_kul_adısoyadı", txt_kul_adısoyadı.Text);
            cmd.Parameters.AddWithValue("@txt_sifre", txt_sifre.Text);
            cmd.Parameters.AddWithValue("@txt_maas", txt_maas.Text);
            cmd.Parameters.AddWithValue("@txt_tcno", txt_tcno.Text);
            cmd.Parameters.AddWithValue("@txt_telno", txt_telno.Text);
            cmd.ExecuteNonQuery();
            db.connection.Close();
            MessageBox.Show("Bilgiler Güncellendi");
            this.Close();
        }

        //private void ara_Click(object sender, EventArgs e)
        //{
        //    db.connection.Open();
        //    string query_Ara = "Select * from kalite_kontrol where kalite_kontrol_id=@kalite_kontrol_id";//yonetici_id sine göre veri geliyor.
        //    MySqlCommand cmd = new MySqlCommand(query_Ara, db.connection);
        //    cmd.Parameters.AddWithValue("@kalite_kontrol_id", txt_kul_id.Text);
        //    //MID parametremize textbox'dan girilen değer geliyor.
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {//formdaki textboxlara, datareader ile gelen verileri aktardık.
        //        lbl_kul_id.Text = dr["kalite_kontrol_id"].ToString();
        //        txt_kul_adısoyadı.Text = dr["isim_soyisim"].ToString();
        //        txt_sifre.Text = dr["sifre"].ToString();
        //        txt_telno.Text = dr["cep_no"].ToString();
        //        txt_maas.Text = dr["maas"].ToString();
        //        txt_tcno.Text = dr["tc_no"].ToString();
        //    }
        //    else
        //        MessageBox.Show("Bu Numarada Bir kullanıcı Bulunamadı.");
        //    db.connection.Close();
        //}
        private void ara_Click(object sender, EventArgs e)
        {
            db.connection.Open();
            string query_Ara = "Select * from kalite_kontrol where kalite_kontrol_id=@kalite_kontrol_id";//yonetici_id sine göre veri geliyor.
            MySqlCommand cmd = new MySqlCommand(query_Ara, db.connection);
            cmd.Parameters.AddWithValue("@kalite_kontrol_id", txt_kul_id.Text);
            //MID parametremize textbox'dan girilen değer geliyor.
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {//formdaki textboxlara, datareader ile gelen verileri aktardık.
                lbl_kul_id.Text = dr["kalite_kontrol_id"].ToString();
                txt_kul_adısoyadı.Text = dr["isim_soyisim"].ToString();
                txt_sifre.Text = dr["sifre"].ToString();
                txt_telno.Text = dr["cep_no"].ToString();
                txt_maas.Text = dr["maas"].ToString();
                txt_tcno.Text = dr["tc_no"].ToString();
            }
            else
                MessageBox.Show("Bu Numarada Bir kullanıcı Bulunamadı.");
            db.connection.Close();
        }


    }
}
