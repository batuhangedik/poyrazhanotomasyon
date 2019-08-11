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
    public partial class GelirGiderRapor : Form
    {
        public GelirGiderRapor()
        {
            InitializeComponent();
        }

        database db = new database();
        private void GelirGiderRapor_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter list4 = new MySqlDataAdapter("select * from ekstragider", db.connection);
            DataTable read4 = new DataTable();
            list4.Fill(read4);
            dataGridView3.DataSource = read4;
            db.connection.Close();
            MySqlDataAdapter list = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView2.DataSource = read;
            db.connection.Close();
            
            MySqlDataAdapter list2 = new MySqlDataAdapter("select * from satis_siparisi", db.connection);
            DataTable read2 = new DataTable();
            list2.Fill(read2);
            dataGridView1.DataSource = read2;
            db.connection.Close();
            this.WindowState = FormWindowState.Maximized;
            Int64 toplam1=0;
            Int64 toplam2 = 0;
            Int64 toplam3 = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                Int64 birim_fiyat = Convert.ToInt64(dataGridView2.Rows[i].Cells[6].Value);
                Int64 miktar = Convert.ToInt64(dataGridView2.Rows[i].Cells[7].Value);
                toplam1 = birim_fiyat * miktar + toplam1;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Int64 birim_fiyat2 = Convert.ToInt64(dataGridView1.Rows[i].Cells[7].Value);
                Int64 miktar2 = Convert.ToInt64(dataGridView1.Rows[i].Cells[8].Value);
                toplam2 = birim_fiyat2 * miktar2 + toplam2;
            }
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                Int64 ekstragider = Convert.ToInt64(dataGridView3.Rows[i].Cells[2].Value);
                
                toplam3 =  ekstragider  + toplam3;
            }
            label4.Text = toplam1+" TL";
            label10.Text = toplam3 + " TL";
            Int64 gidertoplam = toplam3 + toplam1;
            label11.Text = toplam2 + " TL";

            if (gidertoplam < toplam2)
            {
                label12.Text = (toplam2-gidertoplam)+" TL KAR";
            }
            if (gidertoplam > toplam2)
            {
                label12.Text = (gidertoplam - toplam2) + " TL ZARAR";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ekstragiderler ekstragiderac = new ekstragiderler();
            ekstragiderac.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            yonetici yoneticiac = new yonetici();
            yoneticiac.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter list4 = new MySqlDataAdapter("select * from ekstragider", db.connection);
            DataTable read4 = new DataTable();
            list4.Fill(read4);
            dataGridView3.DataSource = read4;
            db.connection.Close();
            MySqlDataAdapter list = new MySqlDataAdapter("select * from hm_siparisleri", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView2.DataSource = read;
            db.connection.Close();

            MySqlDataAdapter list2 = new MySqlDataAdapter("select * from satis_siparisi", db.connection);
            DataTable read2 = new DataTable();
            list2.Fill(read2);
            dataGridView1.DataSource = read2;
            db.connection.Close();
            this.WindowState = FormWindowState.Maximized;
            Int64 toplam1 = 0;
            Int64 toplam2 = 0;
            Int64 toplam3 = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                Int64 birim_fiyat = Convert.ToInt64(dataGridView2.Rows[i].Cells[6].Value);
                Int64 miktar = Convert.ToInt64(dataGridView2.Rows[i].Cells[7].Value);
                toplam1 = birim_fiyat * miktar + toplam1;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Int64 birim_fiyat2 = Convert.ToInt64(dataGridView1.Rows[i].Cells[7].Value);
                Int64 miktar2 = Convert.ToInt64(dataGridView1.Rows[i].Cells[8].Value);
                toplam2 = birim_fiyat2 * miktar2 + toplam2;
            }
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                Int64 ekstragider = Convert.ToInt64(dataGridView3.Rows[i].Cells[2].Value);

                toplam3 = ekstragider + toplam3;
            }
            label4.Text = toplam1 + " TL";
            label10.Text = toplam3 + " TL";
            Int64 gidertoplam = toplam3 + toplam1;
            label11.Text = toplam2 + " TL";

            if (gidertoplam < toplam2)
            {
                label12.Text = (toplam2 - gidertoplam) + " TL KAR";
            }
            if (gidertoplam > toplam2)
            {
                label12.Text = (gidertoplam - toplam2) + " TL ZARAR";
            }
        }
    }
}
