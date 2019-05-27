using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Bengkel_PCS
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            GantiKar.Visible = false;
            GantiMana.Visible = false;
            MasterServis.Visible = false;
            fm = new Form1();
        }
        void tampil()
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("select * from service", fm.conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            fm.conn.Close();
        }
        Form1 fm;
        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GantiKar.Visible = true;
        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GantiMana.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GantiKar.Visible = false;
            if (Ganti_Pass.Text.Equals(Ganti_CPass.Text) && Ganti_ID.TextLength!=0)
            {
                fm.conn.Open();
                OracleCommand cmd = new OracleCommand("update karyawan set password_karyawan ='" + Ganti_Pass.Text + "' where id_karyawan = '"+Ganti_ID.Text+"'", fm.conn);
                cmd.ExecuteNonQuery();
                fm.conn.Close();
                MessageBox.Show("Ganti Password Sukses");
            }
            else
            {
                MessageBox.Show("Konfirm password dan password tidak sama");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GantiMana.Visible = false;
            if (Ganti_MPass.Text.Equals(Ganti_CMPass.Text) && Ganti_MPass.TextLength != 0)
            {
                fm.conn.Open();
                OracleCommand cmd = new OracleCommand("update karyawan set password_karyawan ='" + Ganti_MPass.Text + "' where jabatan = 'MANAGER'", fm.conn);
                cmd.ExecuteNonQuery();
                fm.conn.Close();
                MessageBox.Show("Ganti Password Sukses");
            }
            else
            {
                MessageBox.Show("Konfirm password dan password tidak sama");
            }
            
        }

        private void tambahKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tambahAlatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GantiKar.Visible = false;
            GantiMana.Visible = false;
            MasterServis.Visible = false;
            MasterServis.Visible = false;
        }

        private void servisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterServis.Visible = true;
            tampil();
        }

        private void Servis_Ins_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("insert into service values('','" + ServisNama.Text + "','" + ServisHarga.Text + "','" + ServisLamaM.Text + "','" + ServisLamaD.Text + "')", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }

        private void Servis_Upd_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("update service set nama_service = '" + ServisNama.Text + "', harga_service ='" + ServisHarga.Text + "', durasi_service_jam ='" + ServisLamaM.Text + "', durasi_service_menit='" + ServisLamaD.Text + "' where id_barang = '" + ServisID.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }

        private void Servis_Del_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("delete from service where id_service = '" + ServisID.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            ServisID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            ServisNama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            ServisHarga.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            ServisLamaM.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            ServisLamaD.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
