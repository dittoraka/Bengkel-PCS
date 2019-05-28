using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bengkel_PCS
{

    public partial class Cashier : Form
    {
        public List<Pembelian> blist = new List<Pembelian>();
        List<string> nbarang = new List<string>();
        List<string> stok = new List<string>();
        public Cashier()
        {
            InitializeComponent();
            fm = new Form1();
        }

        Form1 fm;
        

        private void Cashier_Load(object sender, EventArgs e)
        {
            loadBarang("harga_customer");
        }

        void loadBarang(string a) {
            fm.conn.Open();
            OracleDataAdapter daa = new OracleDataAdapter("SELECT nama_barang,"+a+" FROM barang ORDER BY 1", fm.conn);
            DataSet dta = new DataSet();
            daa.Fill(dta);

            comboBox1.DataSource = dta.Tables[0];
            comboBox1.DisplayMember = "nama_barang";
            comboBox1.ValueMember = a;
            fm.conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = "";
            try
            {
                fm.conn.Open();
                OracleCommand cmd = new OracleCommand("select count(*) from h_transaksi", fm.conn);
                string jml = cmd.ExecuteScalar().ToString();

                id = "TR" + jml.PadLeft(6, '0');
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                int hg = total;
                cmd = new OracleCommand("insert into h_transaksi values('" + id + "','" + hg + "',to_date('" + date + "','yyyy-MM-dd'))", fm.conn);
                cmd.ExecuteNonQuery();
                fm.conn.Close();
                //MessageBox.Show("Sukses Memasukkan Data transaksi.");
            }
            catch (Exception)
            {
                //MessageBox.Show("Gagal Memasukkan Data transaksi.");
            }

            try
            {
                foreach (Pembelian s in blist)
                {
                    string a = "999";
                    fm.conn.Open();
                    OracleCommand cmd = new OracleCommand("insert into d_transaksi values('" + id + "','" + s.Idbarang + "','" + s.Jumlah + "','" + (s.Harga - (s.Hbeli * s.Jumlah)) + "')", fm.conn);
                    cmd.ExecuteNonQuery();
                    fm.conn.Close();

                    fm.conn.Open();
                    cmd = new OracleCommand("select stock as gen from barang where id_barang = '" + s.Idbarang + "'", fm.conn);
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) { a = reader["gen"] + ""; }
                    fm.conn.Close();

                    int suk = Convert.ToInt32(a) - s.Jumlah;
                    fm.conn.Open();
                    cmd = new OracleCommand("update barang set stock = '" + suk + "' where id_barang = '" + s.Idbarang + "'", fm.conn);
                    cmd.ExecuteNonQuery();
                    fm.conn.Close();
                }
                MessageBox.Show("Sukses Memasukkan Data Transaksi.");
                blist.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Memasukkan Data transaksi.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fm.conn.Open();
                OracleCommand cmd = new OracleCommand("select id_barang as gen from barang where nama_barang = '" + comboBox1.Text + "'", fm.conn);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader["gen"] + "";
                }
                fm.conn.Close();
            }
            catch (Exception)
            {

            }
            
        }
        int total = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            string id = "";
            string hbeli = "";
            DateTime date = DateTime.Now;
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);  // this line was missing
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("select id_barang as gen, harga_asli as gen1 from barang where nama_barang = '" + comboBox1.Text + "'", fm.conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader["gen"] + "";
                hbeli = reader["gen1"] + "";
            }
            fm.conn.Close();
            int a = Int32.Parse(comboBox1.SelectedValue.ToString());
            int b = Int32.Parse(textBox3.Text);

            row.Cells[0].Value = id;
            row.Cells[1].Value = date;
            row.Cells[2].Value = comboBox1.Text;
            row.Cells[3].Value = textBox3.Text;
            row.Cells[4].Value = comboBox1.SelectedValue.ToString();
            row.Cells[5].Value = a * b;
            total += a * b;

            dataGridView1.Rows.Add(row);
            blist.Add(new Pembelian(id,comboBox1.Text, Int32.Parse(comboBox1.SelectedValue.ToString()) * Int32.Parse(textBox3.Text), Int32.Parse(textBox3.Text),Int32.Parse(hbeli)));

            label1.Text = "Rp. " + total.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("select stock as gen,nama_barang as nama from barang where nama_barang like '%" + textBox4.Text + "%'", fm.conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stok.Add(reader["gen"] + "");
                nbarang.Add(reader["nama"] + "");
            }
            fm.conn.Close();
            for (int i = 0; i < nbarang.Count; i++)
            {
                MessageBox.Show("Nama Barang : " + nbarang[i] + "\n Stock : " + stok[i]);
            }
            nbarang.Clear();
            stok.Clear();
        }
        int idx;
        private void button5_Click(object sender, EventArgs e)
        {
            total -= Int32.Parse(dataGridView1.Rows[idx].Cells[6].Value.ToString());
            label7.Text = "Rp. " + total.ToString();
            dataGridView1.Rows.RemoveAt(idx);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Ya")
            {
                loadBarang("harga_bengkel");
            }
            else {
                loadBarang("harga_customer");
            }
        }
    }
}
