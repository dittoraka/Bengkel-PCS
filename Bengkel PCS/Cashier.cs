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
        public Cashier()
        {
            InitializeComponent();
            fm = new Form1();
        }

        Form1 fm;
        

        private void Cashier_Load(object sender, EventArgs e)
        {
            OracleDataAdapter daa = new OracleDataAdapter();
            daa = new OracleDataAdapter("SELECT id_customer,nama_customer FROM customer ORDER BY 1", fm.conn);
            DataSet dta = new DataSet();
            daa.Fill(dta);

            comboBox2.DataSource = dta.Tables[0];
            comboBox2.DisplayMember = "nama_customer";
            comboBox2.ValueMember = "id_customer";

            daa = new OracleDataAdapter("SELECT nama_barang,harga_asli FROM barang ORDER BY 1", fm.conn);
            dta = new DataSet();
            daa.Fill(dta);

            comboBox1.DataSource = dta.Tables[0];
            comboBox1.DisplayMember = "nama_barang";
            comboBox1.ValueMember = "id_barang";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("select id_barang as gen from barang where nama_barang = '" + comboBox1.Text + "'", fm.conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox2.Text = reader["gen"] + "";
            }
        }
        int total = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);  // this line was missing
            OracleCommand cmd = new OracleCommand("select id_barang as gen from barang where nama_barang = '" + comboBox1.Text + "'", fm.conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                row.Cells[0].Value = reader["gen"] + "";
            }
            row.Cells[1].Value = date;
            row.Cells[2].Value = comboBox1.Text;
            row.Cells[3].Value = comboBox2.SelectedValue.ToString();
            row.Cells[4].Value = textBox3.Text;
            row.Cells[5].Value = comboBox1.SelectedValue.ToString();
            row.Cells[6].Value = Int32.Parse(comboBox1.SelectedValue.ToString()) * Int32.Parse(textBox3.Text);
            total += Int32.Parse(comboBox1.SelectedValue.ToString()) * Int32.Parse(textBox3.Text);

            dataGridView1.Rows.Add(row);

            label1.Text = "Rp. " + total.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nbarang = textBox4.Text;
            string stok = "";
            OracleCommand cmd = new OracleCommand("select stock as gen from barang where nama_barang = '" + nbarang + "'", fm.conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stok = reader["gen"] + "";
            }
            MessageBox.Show("Nama Barang : "+nbarang+"\n Stock : "+stok);
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
    }
}
