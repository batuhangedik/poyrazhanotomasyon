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
    public partial class ekstragiderler : Form
    {
        public ekstragiderler()
        {
            InitializeComponent();
        }

        private void ekstragiderler_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter list1 = new MySqlDataAdapter("select * from ekstragider", db.connection);
            DataTable read1 = new DataTable();
            list1.Fill(read1);
            dataGridView1.DataSource = read1;
            db.connection.Close();
        }
        database db=new database();
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili Gideri Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (cikis == DialogResult.Yes)
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
                {
                    int numara = Convert.ToInt32(drow.Cells[0].Value);
                    string sql = "DELETE FROM ekstragider WHERE gider_id= '" + numara + "' ";
                    MySqlCommand komut = new MySqlCommand(sql, db.connection);
                    komut.Parameters.AddWithValue("gider_id", numara);
                    db.connection.Open();
                    komut.ExecuteNonQuery();
                    db.connection.Close();
                    MySqlDataAdapter list = new MySqlDataAdapter("select * from ekstragider", db.connection);
                    DataTable read = new DataTable();
                    list.Fill(read);
                    dataGridView1.DataSource = read;
                    db.connection.Close();
                }
            }
        }
        int sid;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    sid = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);

                }
                sid++;
            }
            else
                sid = 0;
            MySqlCommand add = new MySqlCommand("insert into ekstragider(gider_id,gider_tanim,ucret) VALUES('" + sid + "','" + textBox1.Text + "',   '" + textBox2.Text + "')", db.connection);
            db.connection.Open();
            if (add.ExecuteNonQuery() == 1)
            { }
            else
            { }
            MySqlDataAdapter list = new MySqlDataAdapter("select * from ekstragider", db.connection);
            DataTable read = new DataTable();
            list.Fill(read);
            dataGridView1.DataSource = read;
            db.connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
