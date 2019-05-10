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
    public partial class Inventory : Form
    {
        Form1 fm;
        int baris = -1;
        public Inventory()
        {
            InitializeComponent();
            fm = new Form1();
        }

        public void tampil()
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("select * from barang", fm.conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            fm.conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            baris = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            numericUpDown1.Value = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int harga = Int32.Parse(textBox3.Text) * 10 / 100;
            int cust = Int32.Parse(textBox3.Text) + harga;
            int bengkel = Int32.Parse(textBox3.Text) - harga;

            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("insert into barang values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + cust.ToString() + "','" + bengkel.ToString() + "','" + numericUpDown1.Value.ToString() + "')", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int harga = Int32.Parse(textBox3.Text) * 10 / 100;
            int cust = Int32.Parse(textBox3.Text) + harga;
            int bengkel = Int32.Parse(textBox3.Text) - harga;

            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("update barang set nama_barang = '" + textBox2.Text + "', harga_asli ='" + textBox3.Text + "', harga_customer='" + cust.ToString() + "', harga_bengkel='" + bengkel.ToString() + "', stock='" + numericUpDown1.Value.ToString() + "' where id_barang = '" + textBox1.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int harga = Int32.Parse(textBox3.Text) * 10 / 100;
            int cust = Int32.Parse(textBox3.Text) + harga;
            int bengkel = Int32.Parse(textBox3.Text) - harga;

            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("update barang set nama_barang = '" + textBox2.Text + "', harga_asli ='" + textBox3.Text + "', harga_customer='" + cust.ToString() + "', harga_bengkel='" + bengkel.ToString() + "', stock='" + numericUpDown1.Value.ToString() + "' where id_barang = '" + textBox1.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            tampil();
        }
    }
}
