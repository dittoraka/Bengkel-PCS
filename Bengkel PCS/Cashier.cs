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

            daa = new OracleDataAdapter("SELECT id_barang,nama_barang FROM barang ORDER BY 1", fm.conn);
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
    }
}
