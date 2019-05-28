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
            TambahKaryawan.Visible = false;
            MasterAlat.Visible = false;
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
        void tampil1()
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("select id_karyawan,nama_karyawan,password_karyawan,to_char(dob_karyawan,'MM/DD/YYYY')as\"dob_karyawan\",spesialis,to_char(tgl_join,'MM/DD/YYYY')as\"tgl_join\",jabatan from karyawan", fm.conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            fm.conn.Close();
        }
        void tampil2()
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("select * from alat", fm.conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
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
            TambahKaryawan.Visible = true;
            tampil1();
        }

        private void tambahAlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterAlat.Visible = true;
            tampil2();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GantiKar.Visible = false;
            GantiMana.Visible = false;
            MasterServis.Visible = false;
            MasterServis.Visible = false;
            TambahKaryawan.Visible = false;
            MasterAlat.Visible = false;
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
            MessageBox.Show("Tambah Servis Sukses");
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

        private void Selesai_Click(object sender, EventArgs e)
        {
            if(KarNama.TextLength != 0 && KarPassword.TextLength != 0 && KarJabatan.TextLength != 0)
            {
                fm.conn.Open();
                OracleCommand cmd = new OracleCommand("insert into karyawan values('','"+KarNama.Text+"','"+KarPassword.Text+"',to_date('"+KarDOB.Value.Day.ToString()+"-"+KarDOB.Value.Month.ToString()+"-"+KarDOB.Value.Year.ToString()+"','DD-MM-YY'),'"+KarSpecial.Text+ "',to_date('" + KarJoin.Value.Day.ToString() + "-" + KarJoin.Value.Month.ToString() + "-" + KarJoin.Value.Year.ToString() + "','DD-MM-YY'),'" + KarJabatan.Text+"')", fm.conn);
                cmd.ExecuteNonQuery();
                fm.conn.Close();
                MessageBox.Show("Tambah Karyawan Sukses");
                tampil1();
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("update karyawan set nama_karyawan = '" + KarNama.Text + "', password_karyawan ='" + KarPassword.Text + "', dob_karyawan =to_date('" + KarDOB.Value.Day.ToString() + "-" + KarDOB.Value.Month.ToString() + "-" + KarDOB.Value.Year.ToString() + "','DD-MM-YY'), spesialis ='" + KarSpecial.Text + "', tgl_join =to_date('" + KarJoin.Value.Day.ToString() + "-" + KarJoin.Value.Month.ToString() + "-" + KarJoin.Value.Year.ToString() + "','DD-MM-YY'), jabatan ='" + KarJabatan.Text + "' where id_karyawan = '" + KarID.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("delete from karyawan where id_karyawan = '" + KarID.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil1();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            KarID.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            KarNama.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            KarPassword.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            string[] tgl = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString().Split('/');
            KarDOB.Value = new DateTime(int.Parse(tgl[2]), int.Parse(tgl[0]), int.Parse(tgl[1]));
            KarSpecial.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            tgl = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString().Split('/');
            KarJoin.Value = new DateTime(int.Parse(tgl[2]), int.Parse(tgl[0]), int.Parse(tgl[1]));
            KarJabatan.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void AlatIns_Click(object sender, EventArgs e)
        {
            
        }

        private void AlatUpd_Click(object sender, EventArgs e)
        {
            
        }

        private void AlatDel_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            AlatID.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            AlatNama.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            AlatJuml.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("insert into alat values('','" + AlatNama.Text + "','" + AlatJuml.Value + "','B')", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
            MessageBox.Show("Tambah Alat Sukses");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("update alat set nama_alat = '" + AlatNama.Text + "', banyak_alat ='" + AlatJuml.Value + "' where id_alat = '" + AlatID.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fm.conn.Open();
            OracleCommand cmd = new OracleCommand("delete from alat where id_alat = '" + AlatID.Text + "'", fm.conn);
            cmd.ExecuteNonQuery();
            fm.conn.Close();
            tampil();
        }
    }
}
